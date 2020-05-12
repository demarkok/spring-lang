using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;

namespace JetBrains.ReSharper.Plugins.Spring
{

    public class SpringFile : FileElementBase
    {
        public override NodeType NodeType => SpringFileNodeType.Instance;

        public override PsiLanguageType Language => SpringLanguage.Instance;
    }

    public abstract class SpringNode : CompositeElement
    {
        public override PsiLanguageType Language => SpringLanguage.Instance;
    }

    public class Spring_FunDef : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUN_DEF;
    }

    public class Spring_LocalVariables : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.LOCAL_VARIABLES;
    }

    public class Spring_LocalVariableList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.LOCAL_VARIABLE_LIST;
    }

    public class Spring_IdentifierDecl : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.IDENTIFIER_DECL;
    }

    public class Spring_FunctionParameterList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUNCTION_PARAMETER_LIST;
    }

    public class Spring_Block : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.BLOCK;
    }

    public class Spring_BlockWithBraces : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.BLOCK_WITH_BRACES;
    }

    public class Spring_Statement : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STATEMENT;
    }

    public class Spring_StmtCall : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_CALL;
    }

    public class Spring_LoopBlock : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.LOOP_BLOCK;
    }

    public class Spring_StmtFor : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_FOR;
    }

    public class Spring_StmtWhile : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_WHILE;
    }

    public class Spring_StmtRepeat : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_REPEAT;
    }

    public class Spring_StmtCase : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_CASE;
    }

    public class Spring_CaseList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_LIST;
    }

    public class Spring_CaseListElement : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_LIST_ELEMENT;
    }

    public class Spring_CasePattern : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_PATTERN;
    }

    public class Spring_CasePatternList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.CASE_PATTERN_LIST;
    }

    public class Spring_StmtIf : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_IF;
    }

    public class Spring_ElifBranch : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ELIF_BRANCH;
    }

    public class Spring_ElseBranch : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ELSE_BRANCH;
    }

    public class Spring_StmtAssignment : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_ASSIGNMENT;
    }

    public class Spring_ArrayIndex : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ARRAY_INDEX;
    }

    public class Spring_StmtReturn : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_RETURN;
    }

    public class Spring_StmtSkip : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.STMT_SKIP;
    }

    public class Spring_AtomExpression : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ATOM_EXPRESSION;
    }

    public class Spring_Expression : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.EXPRESSION;
    }

    public class Spring_FunctionCall : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.FUNCTION_CALL;
    }

    public class Spring_ExpressionList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.EXPRESSION_LIST;
    }

    public class Spring_SExpr : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.S_EXPR;
    }

    public class Spring_Array : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ARRAY;
    }

    public class Spring_ArrayElementList : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.ARRAY_ELEMENT_LIST;
    }

    public class Spring_Identifier : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.IDENTIFIER;
    }

    public class Spring_Number : SpringNode
    {
        public override NodeType NodeType => SpringCompositeNodeType.NUMBER;
    }
}
    
    
