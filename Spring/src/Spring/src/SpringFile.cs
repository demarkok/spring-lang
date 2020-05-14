using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Antlr4.Runtime;
using JetBrains.ReSharper.ExternalSources.Resources;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Impl.CodeStyle.MemberReordering;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.PsiGen.Util;
using JetBrains.Util;
using Xunit;
using Xunit.Sdk;

namespace JetBrains.ReSharper.Plugins.Spring
{

    public class SpringFile : FileElementBase
    {

        public HashSet<Spring_FunctionIdentifierDecl> DeclaredFunctions()
        {
            return new HashSet<Spring_FunctionIdentifierDecl>(this.Descendants().OfType<Spring_FunctionIdentifierDecl>().Collect());
        }
        
        private RuleContext _context;
        public SpringFile(RuleContext context)
        {
            _context = context;
        }
        
        public override NodeType NodeType => SpringFileNodeType.Instance;

        public override PsiLanguageType Language => SpringLanguage.Instance;
    }

    public abstract class SpringNode : CompositeElement
    {
        protected RuleContext _context;

        protected SpringNode(RuleContext context)
        {
            _context = context;
        }

        public override PsiLanguageType Language => SpringLanguage.Instance;
    }


    public abstract class SpringDeclaration : SpringNode, IDeclaration
    {
        public void SetName(string name)
        {
        }

        public TreeTextRange GetNameRange() => FirstChild.GetTreeTextRange();

        public bool IsSynthetic() => false;

        public IDeclaredElement DeclaredElement { get; set; }
        public string DeclaredName => _context.GetText();
        public XmlNode GetXMLDoc(bool inherit) => null;

        protected SpringDeclaration(RuleContext context) : base(context)
        {
            DeclaredElement = new IdentifierDeclaredElement(this);
        }

        
    }
    

    public interface IDeclaringVariables
    {
        HashSet<Spring_IdentifierDecl> DeclaredVariables();
    }
    

    public class Spring_FunDef : SpringNode, IDeclaringVariables
    {
        
        public override NodeType NodeType => SpringCompositeNodeType.FUN_DEF;

        public Spring_FunDef(RuleContext context) : base(context)
        {
        }

        public HashSet<Spring_IdentifierDecl> DeclaredVariables()
        {
            
            // VERY BAD DESIGN. TODO: refactor
            var funParameters = this.Children()
                .FirstOrDefault((x => x.NodeType == SpringCompositeNodeType.FUNCTION_PARAMETER_LIST))
                ?.Descendants().OfType<Spring_IdentifierDecl>()
                .Collect();
            
            
            var localVariables = this.Children()
                .FirstOrDefault(x => x.NodeType == SpringCompositeNodeType.LOCAL_VARIABLES)
                ?.Descendants().OfType<Spring_IdentifierDecl>()
                .Collect();
            
            var declaredVariables = new HashSet<Spring_IdentifierDecl>();

            if (funParameters != null)
                declaredVariables.addAll(funParameters);
            
            if (localVariables != null)
                declaredVariables.addAll(localVariables);
            
            return declaredVariables;
        }
    }

    public class Spring_LocalVariables : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.LOCAL_VARIABLES;

        public Spring_LocalVariables(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_LocalVariableList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.LOCAL_VARIABLE_LIST;

        public Spring_LocalVariableList(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_IdentifierDecl : SpringDeclaration
    {
        public override NodeType NodeType => SpringCompositeNodeType.IDENTIFIER_DECL;
        
        public Spring_IdentifierDecl(RuleContext context) : base(context)
        {
            DeclaredElement = new IdentifierDeclaredElement(this);
        }
    }

    public class Spring_FunctionParameterList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUNCTION_PARAMETER_LIST;

        public Spring_FunctionParameterList(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_Block : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.BLOCK;

        public Spring_Block(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_BlockWithBraces : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.BLOCK_WITH_BRACES;

        public Spring_BlockWithBraces(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_Statement : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STATEMENT;

        public Spring_Statement(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtCall : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_CALL;

        public Spring_StmtCall(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_LoopBlock : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.LOOP_BLOCK;

        public Spring_LoopBlock(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtFor : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_FOR;

        public Spring_StmtFor(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtWhile : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_WHILE;

        public Spring_StmtWhile(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtRepeat : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_REPEAT;

        public Spring_StmtRepeat(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtCase : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_CASE;

        public Spring_StmtCase(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_CaseList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_LIST;

        public Spring_CaseList(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_CaseListElement : SpringNode, IDeclaringVariables
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_LIST_ELEMENT;

        public Spring_CaseListElement(RuleContext context) : base(context)
        {
        }

        public HashSet<Spring_IdentifierDecl> DeclaredVariables()
        {
            
            return new HashSet<Spring_IdentifierDecl>(
                this.Children()
                    .FirstOrDefault(x => x.NodeType == SpringCompositeNodeType.CASE_PATTERN)
                    .Descendants().OfType<Spring_IdentifierDecl>()
                    .Collect());
        }
    }

    public class Spring_CasePattern : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_PATTERN;

        public Spring_CasePattern(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_CasePatternList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_PATTERN_LIST;

        public Spring_CasePatternList(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtIf : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_IF;

        public Spring_StmtIf(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_ElifBranch : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ELIF_BRANCH;

        public Spring_ElifBranch(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_ElseBranch : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ELSE_BRANCH;

        public Spring_ElseBranch(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtAssignment : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_ASSIGNMENT;

        public Spring_StmtAssignment(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_ArrayIndex : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ARRAY_INDEX;

        public Spring_ArrayIndex(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtReturn : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_RETURN;

        public Spring_StmtReturn(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_StmtSkip : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_SKIP;

        public Spring_StmtSkip(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_AtomExpression : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ATOM_EXPRESSION;

        public Spring_AtomExpression(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_Expression : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.EXPRESSION;

        public Spring_Expression(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_FunctionCall : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUNCTION_CALL;

        public Spring_FunctionCall(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_ExpressionList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.EXPRESSION_LIST;

        public Spring_ExpressionList(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_SExpr : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.S_EXPR;

        public Spring_SExpr(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_Array : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ARRAY;

        public Spring_Array(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_ArrayElementList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ARRAY_ELEMENT_LIST;

        public Spring_ArrayElementList(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_Identifier : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.IDENTIFIER;

        public Spring_Identifier(RuleContext context) : base(context)
        {
        }

        public override ReferenceCollection GetFirstClassReferences()
        {
            return new ReferenceCollection(new IdentifierReference(this));
        }
    }

    public class Spring_Number : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.NUMBER;

        public Spring_Number(RuleContext context) : base(context)
        {
        }
    }

    public class Spring_FunctionIdentifier : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUNCTION_IDENTIFIER;
        
        public Spring_FunctionIdentifier(RuleContext context) : base(context)
        {
        }


        public override ReferenceCollection GetFirstClassReferences()
        {
            return new ReferenceCollection(new FunctionIdentifierReference(this));
        }
    }


    public class Spring_FunctionIdentifierDecl : SpringDeclaration 
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUNCTION_IDENTIFIER_DECL;
        
        public Spring_FunctionIdentifierDecl(RuleContext context) : base(context)
        {
        }
    }

}
    



        



    
