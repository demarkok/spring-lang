using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.TreeBuilder;

namespace JetBrains.ReSharper.Plugins.Spring
{
    internal class SpringFileNodeType : CompositeNodeWithArgumentType
    {
        public SpringFileNodeType(string s, int index) : base(s, index)
        {
        }

        public static readonly SpringFileNodeType Instance = new SpringFileNodeType("Spring_FILE", 0);

        public override CompositeElement Create(object o)
        {
            return new SpringFile((RuleContext) o);
        }
        
        public override CompositeElement Create()
        {
            throw new InvalidOperationException("RuleContext is required to construct SpringNode");
        }
    }

    internal class SpringCompositeNodeType : CompositeNodeWithArgumentType
    {
        
        private static readonly Dictionary<int, SpringCompositeNodeType> FromAntlrDict = new Dictionary<int, SpringCompositeNodeType>();
        
        public static readonly SpringCompositeNodeType FUN_DEF = new SpringCompositeNodeType("FUN_DEF", 1);
        public static readonly SpringCompositeNodeType LOCAL_VARIABLES = new SpringCompositeNodeType("LOCAL_VARIABLES", 2);
        public static readonly SpringCompositeNodeType LOCAL_VARIABLE_LIST = new SpringCompositeNodeType("LOCAL_VARIABLE_LIST", 3);
        public static readonly SpringCompositeNodeType IDENTIFIER_DECL = new SpringCompositeNodeType("IDENTIFIER_DECL", 4);
        public static readonly SpringCompositeNodeType FUNCTION_PARAMETER_LIST = new SpringCompositeNodeType("FUNCTION_PARAMETER_LIST", 5);
        public static readonly SpringCompositeNodeType BLOCK = new SpringCompositeNodeType("BLOCK", 6);
        public static readonly SpringCompositeNodeType BLOCK_WITH_BRACES = new SpringCompositeNodeType("BLOCK_WITH_BRACES", 7);
        public static readonly SpringCompositeNodeType STATEMENT = new SpringCompositeNodeType("STATEMENT", 8);
        public static readonly SpringCompositeNodeType STMT_CALL = new SpringCompositeNodeType("STMT_CALL", 9);
        public static readonly SpringCompositeNodeType LOOP_BLOCK = new SpringCompositeNodeType("LOOP_BLOCK", 10);
        public static readonly SpringCompositeNodeType STMT_FOR = new SpringCompositeNodeType("STMT_FOR", 11);
        public static readonly SpringCompositeNodeType STMT_WHILE = new SpringCompositeNodeType("STMT_WHILE", 12);
        public static readonly SpringCompositeNodeType STMT_REPEAT = new SpringCompositeNodeType("STMT_REPEAT", 13);
        public static readonly SpringCompositeNodeType STMT_CASE = new SpringCompositeNodeType("STMT_CASE", 14);
        public static readonly SpringCompositeNodeType CASE_LIST = new SpringCompositeNodeType("CASE_LIST", 15);
        public static readonly SpringCompositeNodeType CASE_LIST_ELEMENT = new SpringCompositeNodeType("CASE_LIST_ELEMENT", 16);
        public static readonly SpringCompositeNodeType CASE_PATTERN = new SpringCompositeNodeType("CASE_PATTERN", 17);
        public static readonly SpringCompositeNodeType CASE_PATTERN_LIST = new SpringCompositeNodeType("CASE_PATTERN_LIST", 18);
        public static readonly SpringCompositeNodeType STMT_IF = new SpringCompositeNodeType("STMT_IF", 19);
        public static readonly SpringCompositeNodeType ELIF_BRANCH = new SpringCompositeNodeType("ELIF_BRANCH", 20);
        public static readonly SpringCompositeNodeType ELSE_BRANCH = new SpringCompositeNodeType("ELSE_BRANCH", 21);
        public static readonly SpringCompositeNodeType STMT_ASSIGNMENT = new SpringCompositeNodeType("STMT_ASSIGNMENT", 22);
        public static readonly SpringCompositeNodeType ARRAY_INDEX = new SpringCompositeNodeType("ARRAY_INDEX", 23);
        public static readonly SpringCompositeNodeType STMT_RETURN = new SpringCompositeNodeType("STMT_RETURN", 24);
        public static readonly SpringCompositeNodeType STMT_SKIP = new SpringCompositeNodeType("STMT_SKIP", 25);
        public static readonly SpringCompositeNodeType ATOM_EXPRESSION = new SpringCompositeNodeType("ATOM_EXPRESSION", 26);
        public static readonly SpringCompositeNodeType EXPRESSION = new SpringCompositeNodeType("EXPRESSION", 27);
        public static readonly SpringCompositeNodeType FUNCTION_CALL = new SpringCompositeNodeType("FUNCTION_CALL", 28);
        public static readonly SpringCompositeNodeType EXPRESSION_LIST = new SpringCompositeNodeType("EXPRESSION_LIST", 29);
        public static readonly SpringCompositeNodeType S_EXPR = new SpringCompositeNodeType("S_EXPR", 30);
        public static readonly SpringCompositeNodeType ARRAY = new SpringCompositeNodeType("ARRAY", 31);
        public static readonly SpringCompositeNodeType ARRAY_ELEMENT_LIST = new SpringCompositeNodeType("ARRAY_ELEMENT_LIST", 32);
        public static readonly SpringCompositeNodeType IDENTIFIER = new SpringCompositeNodeType("IDENTIFIER", 33);
        public static readonly SpringCompositeNodeType NUMBER = new SpringCompositeNodeType("NUMBER", 34);
        public static readonly SpringCompositeNodeType FUNCTION_IDENTIFIER = new SpringCompositeNodeType("FUNCTION_IDENTIFIER", 35);
        public static readonly SpringCompositeNodeType FUNCTION_IDENTIFIER_DECL = new SpringCompositeNodeType("FUNCTION_IDENTIFIER_DECL", 36);

        public static SpringCompositeNodeType FromAntlr(int ruleIndex)
        {
            return FromAntlrDict.GetValueSafe(ruleIndex);
        }
        
        public SpringCompositeNodeType(string s, int index) : base(s, index)
        {
            FromAntlrDict.Add(index, this);
        }

        public override CompositeElement Create(object o)
        {
            var c = (RuleContext) o;
            if (this == FUN_DEF) return new Spring_FunDef(c);
            if (this == LOCAL_VARIABLES) return new Spring_LocalVariables(c);
            if (this == LOCAL_VARIABLE_LIST) return new Spring_LocalVariableList(c);
            if (this == IDENTIFIER_DECL) return new Spring_IdentifierDecl(c);
            if (this == FUNCTION_PARAMETER_LIST) return new Spring_FunctionParameterList(c);
            if (this == BLOCK) return new Spring_Block(c);
            if (this == BLOCK_WITH_BRACES) return new Spring_BlockWithBraces(c);
            if (this == STATEMENT) return new Spring_Statement(c);
            if (this == STMT_CALL) return new Spring_StmtCall(c);
            if (this == LOOP_BLOCK) return new Spring_LoopBlock(c);
            if (this == STMT_FOR) return new Spring_StmtFor(c);
            if (this == STMT_WHILE) return new Spring_StmtWhile(c);
            if (this == STMT_REPEAT) return new Spring_StmtRepeat(c);
            if (this == STMT_CASE) return new Spring_StmtCase(c);
            if (this == CASE_LIST) return new Spring_CaseList(c);
            if (this == CASE_LIST_ELEMENT) return new Spring_CaseListElement(c);
            if (this == CASE_PATTERN) return new Spring_CasePattern(c);
            if (this == CASE_PATTERN_LIST) return new Spring_CasePatternList(c);
            if (this == STMT_IF) return new Spring_StmtIf(c);
            if (this == ELIF_BRANCH) return new Spring_ElifBranch(c);
            if (this == ELSE_BRANCH) return new Spring_ElseBranch(c);
            if (this == STMT_ASSIGNMENT) return new Spring_StmtAssignment(c);
            if (this == ARRAY_INDEX) return new Spring_ArrayIndex(c);
            if (this == STMT_RETURN) return new Spring_StmtReturn(c);
            if (this == STMT_SKIP) return new Spring_StmtSkip(c);
            if (this == ATOM_EXPRESSION) return new Spring_AtomExpression(c);
            if (this == EXPRESSION) return new Spring_Expression(c);
            if (this == FUNCTION_CALL) return new Spring_FunctionCall(c);
            if (this == EXPRESSION_LIST) return new Spring_ExpressionList(c);
            if (this == S_EXPR) return new Spring_SExpr(c);
            if (this == ARRAY) return new Spring_Array(c);
            if (this == ARRAY_ELEMENT_LIST) return new Spring_ArrayElementList(c);
            if (this == IDENTIFIER) return new Spring_Identifier(c);
            if (this == NUMBER) return new Spring_Number(c);
            if (this == FUNCTION_IDENTIFIER) return new Spring_FunctionIdentifier(c);
            if (this == FUNCTION_IDENTIFIER_DECL) return new Spring_FunctionIdentifierDecl(c);

            throw new InvalidOperationException();
        }

        public override CompositeElement Create()
        {
            throw new InvalidOperationException("RuleContext is required to construct SpringNode");
        }
    }
}