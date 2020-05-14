using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ICSharpCode.NRefactory.CSharp;
using JetBrains.Application.PersistentMap;
using JetBrains.Application.Settings;
using JetBrains.Core;
using JetBrains.DocumentModel;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Feature.Services.SelectEmbracingConstruct;
using JetBrains.ReSharper.I18n.Services.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Parsing;
using JetBrains.ReSharper.Psi.ExtensionsAPI;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.TreeBuilder;
using JetBrains.ReSharper.Refactorings.UseBaseType.Dependencies;
using JetBrains.Text;
using NodeType = JetBrains.ReSharper.Psi.ExtensionsAPI.Tree.NodeType;

namespace JetBrains.ReSharper.Plugins.Spring
{
    internal class SpringParser : IParser
    {
        private readonly ILexer myLexer;

        public SpringParser(ILexer lexer)
        {
            myLexer = lexer;
        }

        public IFile ParseFile()
        {
            using (var def = Lifetime.Define())
            {
                var builder = new PsiBuilder(myLexer, SpringFileNodeType.Instance, new TokenFactory(), def.Lifetime);
                
                SpringLangLexer antlrLexer = new SpringLangLexer(new AntlrInputStream(myLexer.Buffer.GetText()));
                SpringLangParser antlrParser = new SpringLangParser(new CommonTokenStream(antlrLexer));
                
                BuilderVisitor visitor = new BuilderVisitor(builder);
                
                visitor.Visit(antlrParser.program());
                
                // ParseBlock(builder);

                var file = (IFile)builder.BuildTree();

                var stringBuilder = new StringBuilder();
                DebugUtil.DumpPsi(new StringWriter(stringBuilder), file);
                stringBuilder.ToString();
               
                return file;
            }
        }

        private class BuilderVisitor : SpringLangBaseVisitor<Unit>
        {

            private PsiBuilder _psiBuilder;
            private SpringIdentifierScope _scope = new SpringIdentifierScope();
            public BuilderVisitor(PsiBuilder psiBuilder)
            {
                _psiBuilder = psiBuilder;
            }

            private int _enter(int lexeme) {
               _psiBuilder.ResetCurrentLexeme(lexeme, lexeme);
               return _psiBuilder.Mark();
            }

            private void _leave(int lexeme, int marker, NodeType nodeType, RuleContext context)
            {
               _psiBuilder.ResetCurrentLexeme(lexeme, lexeme);
               _psiBuilder.Done(marker, nodeType, context);
            }

            public override Unit VisitProgram(SpringLangParser.ProgramContext context)
            {
                var nodeType = SpringFileNodeType.Instance;
                var marker = _enter(context.SourceInterval.a);
                base.VisitChildren(context);
                _leave(MaxTokenIndexConsumed, marker, nodeType, context);
                return Unit.Instance;
            }

            private Unit _Visit(ParserRuleContext context)
            {
                var nodeType = SpringCompositeNodeType.FromAntlr(context.RuleIndex);
                
                if (nodeType is null)
                {
                    return base.VisitChildren(context);
                }
                
                var interval = context.SourceInterval;
                var marker = _enter(interval.a);
                
                base.VisitChildren(context);
                _leave(interval.b + 1, marker, nodeType, context);
                return Unit.Instance;
            }

            public override Unit VisitFunDef(SpringLangParser.FunDefContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitLocalVariables(SpringLangParser.LocalVariablesContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitLocalVariableList(SpringLangParser.LocalVariableListContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitIdentifierDecl(SpringLangParser.IdentifierDeclContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitFunctionParameterList(SpringLangParser.FunctionParameterListContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitBlock(SpringLangParser.BlockContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitBlockWithBraces(SpringLangParser.BlockWithBracesContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStatement(SpringLangParser.StatementContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtCall(SpringLangParser.StmtCallContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitLoopBlock(SpringLangParser.LoopBlockContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtFor(SpringLangParser.StmtForContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtWhile(SpringLangParser.StmtWhileContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtRepeat(SpringLangParser.StmtRepeatContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtCase(SpringLangParser.StmtCaseContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitCaseList(SpringLangParser.CaseListContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitCaseListElement(SpringLangParser.CaseListElementContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitCasePattern(SpringLangParser.CasePatternContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitCasePatternList(SpringLangParser.CasePatternListContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtIf(SpringLangParser.StmtIfContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitElifBranch(SpringLangParser.ElifBranchContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitElseBranch(SpringLangParser.ElseBranchContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtAssignment(SpringLangParser.StmtAssignmentContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitArrayIndex(SpringLangParser.ArrayIndexContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtReturn(SpringLangParser.StmtReturnContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitStmtSkip(SpringLangParser.StmtSkipContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitAtomExpression(SpringLangParser.AtomExpressionContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitExpression(SpringLangParser.ExpressionContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitFunctionCall(SpringLangParser.FunctionCallContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitExpressionList(SpringLangParser.ExpressionListContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitSExpr(SpringLangParser.SExprContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitArray(SpringLangParser.ArrayContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitArrayElementList(SpringLangParser.ArrayElementListContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitIdentifier(SpringLangParser.IdentifierContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitNumber(SpringLangParser.NumberContext context)
            {
                return _Visit(context);
            }

            public override Unit VisitTerminal(ITerminalNode node)
            {
                MaxTokenIndexConsumed = Math.Max(node.Symbol.TokenIndex, MaxTokenIndexConsumed);
                return base.VisitTerminal(node);
            }

            public int MaxTokenIndexConsumed { get; private set; }
        }
    }

    [DaemonStage]
    class SpringDaemonStage : DaemonStageBase<SpringFile>
    {
        protected override IDaemonStageProcess CreateDaemonProcess(IDaemonProcess process, DaemonProcessKind processKind, SpringFile file,
            IContextBoundSettingsStore settingsStore)
        {
            return new SpringDaemonProcess(process, file);
        }

        internal class SpringDaemonProcess : IDaemonStageProcess
        {
            private readonly SpringFile myFile;
            public SpringDaemonProcess(IDaemonProcess process, SpringFile file)
            {
                myFile = file;
                DaemonProcess = process;
            }

            public void Execute(Action<DaemonStageResult> committer)
            {
                var highlightings = new List<HighlightingInfo>();
                foreach (var treeNode in myFile.Descendants())
                {
                    if (treeNode is PsiBuilderErrorElement error)
                    {
                        var range = error.GetDocumentRange();
                        highlightings.Add(new HighlightingInfo(range, new CSharpSyntaxError(error.ErrorDescription, range)));
                    }

                    if (treeNode is Spring_Identifier id)
                    {
                        foreach (var reference in id.GetFirstClassReferences())
                        {
                            if (!reference.Resolve().Info.ResolveErrorType.IsAcceptable)
                            {
                                var range = id.GetDocumentRange();
                                highlightings.Add(new HighlightingInfo(range, new CSharpSyntaxError("??", range)));
                                
                            }
                            
                        } 
                            
                        
                    }
                }
                
                var result = new DaemonStageResult(highlightings);
                committer(result);
            }

            public IDaemonProcess DaemonProcess { get; }
        }

        protected override IEnumerable<SpringFile> GetPsiFiles(IPsiSourceFile sourceFile)
        {
            yield return (SpringFile)sourceFile.GetDominantPsiFile<SpringLanguage>();
        }
    } 

    internal class TokenFactory : IPsiBuilderTokenFactory
    {
        public LeafElementBase CreateToken(TokenNodeType tokenNodeType, IBuffer buffer, int startOffset, int endOffset)
        {
            return tokenNodeType.Create(buffer, new TreeOffset(startOffset), new TreeOffset(endOffset));
        }
    }

    [ProjectFileType(typeof (SpringProjectFileType))]
    public class SelectEmbracingConstructProvider : ISelectEmbracingConstructProvider
    {
        public bool IsAvailable(IPsiSourceFile sourceFile)
        {
            return sourceFile.LanguageType.Is<SpringProjectFileType>();
        }

        public ISelectedRange GetSelectedRange(IPsiSourceFile sourceFile, DocumentRange documentRange)
        {
            var file = (SpringFile) sourceFile.GetDominantPsiFile<SpringLanguage>();
            var node = file.FindNodeAt(documentRange);
            return new SpringTreeNodeSelection(file, node);
        }

        public class SpringTreeNodeSelection : TreeNodeSelection<SpringFile>
        {
            public SpringTreeNodeSelection(SpringFile fileNode, ITreeNode node) : base(fileNode, node)
            {
            }

            public override ISelectedRange Parent => new SpringTreeNodeSelection(FileNode, TreeNode.Parent);
        }
    }
}
