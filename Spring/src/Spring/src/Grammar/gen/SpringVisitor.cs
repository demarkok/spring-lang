//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/Ilya.Kaysin/Dropbox/AU/5/IDE/spring-lang/Spring/src/Spring/src/Grammar/Spring.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="SpringParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface ISpringVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] SpringParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.funDef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunDef([NotNull] SpringParser.FunDefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.localVariables"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocalVariables([NotNull] SpringParser.LocalVariablesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.localVariableList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocalVariableList([NotNull] SpringParser.LocalVariableListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.functionParameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionParameterList([NotNull] SpringParser.FunctionParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] SpringParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.blockWithBraces"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockWithBraces([NotNull] SpringParser.BlockWithBracesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] SpringParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtCall([NotNull] SpringParser.StmtCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.loopBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopBlock([NotNull] SpringParser.LoopBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtFor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtFor([NotNull] SpringParser.StmtForContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtWhile"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtWhile([NotNull] SpringParser.StmtWhileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtRepeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtRepeat([NotNull] SpringParser.StmtRepeatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtCase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtCase([NotNull] SpringParser.StmtCaseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.caseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseList([NotNull] SpringParser.CaseListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.caseListElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCaseListElement([NotNull] SpringParser.CaseListElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.casePattern"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCasePattern([NotNull] SpringParser.CasePatternContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.casePatternList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCasePatternList([NotNull] SpringParser.CasePatternListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtIf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtIf([NotNull] SpringParser.StmtIfContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.elifBranch"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElifBranch([NotNull] SpringParser.ElifBranchContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.elseBranch"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseBranch([NotNull] SpringParser.ElseBranchContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtAssignment([NotNull] SpringParser.StmtAssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.arrayIndex"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayIndex([NotNull] SpringParser.ArrayIndexContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtReturn"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtReturn([NotNull] SpringParser.StmtReturnContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.stmtSkip"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmtSkip([NotNull] SpringParser.StmtSkipContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.atomExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtomExpression([NotNull] SpringParser.AtomExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] SpringParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] SpringParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionList([NotNull] SpringParser.ExpressionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.sExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSExpr([NotNull] SpringParser.SExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray([NotNull] SpringParser.ArrayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.arrayElementList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayElementList([NotNull] SpringParser.ArrayElementListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTag([NotNull] SpringParser.TagContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] SpringParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SpringParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] SpringParser.NumberContext context);
}
