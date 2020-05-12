grammar SpringLang;

program
    : (funDef)* block EOF
    | EOF
    ;

funDef
    : FUN identifierDecl LPAR functionParameterList? RPAR (localVariables)? blockWithBraces
    ;

localVariables
    : LOCAL localVariableList
    ;

localVariableList
    : identifierDecl (COMMA identifierDecl)*
    ;

identifierDecl
    : IDENT 
    ;

functionParameterList
    : identifierDecl (COMMA identifierDecl)*
    ;

block
    : statement (SEMI statement)*
    ;

blockWithBraces
    : LCURL block RCURL
    | LCURL RCURL
    ;

statement
    : stmtCall
    | stmtFor
    | stmtWhile
    | stmtRepeat
    | stmtCase
    | stmtIf
    | stmtAssignment
    | stmtReturn
    | stmtSkip
    ;

stmtCall
    : functionCall
    ;

loopBlock
    : DO (block)? OD
    ;

stmtFor
    : FOR statement COMMA expression COMMA statement loopBlock
    ;

stmtWhile
    : WHILE expression loopBlock
    ;

stmtRepeat
    : REPEAT (block)? UNTIL
    ;

stmtCase
    : CASE expression OF caseList ESAC
    ;

caseList
    : caseListElement (BAR caseListElement)*
    ;

caseListElement
    : casePattern ARROW block
    ;

casePattern
    : WILDCARD
    | identifierDecl
    | TAG (casePatternList)?
    ;

casePatternList
    : casePattern (COMMA casePattern)*
    ;

stmtIf
    : IF expression THEN block (elifBranch)* (elseBranch)? FI
    ;

elifBranch
    : ELIF expression THEN block
    ;

elseBranch
    : ELSE block
    ;

stmtAssignment
    : identifier (arrayIndex)? ASSIGN expression
    ;

arrayIndex
    : (LBRACK expression RBRACK)+
    ;

stmtReturn
    : RETURN (expression)?
    ;

stmtSkip
    : SKIP_KW
    ;


atomExpression 
    : identifier
    | functionCall
    | array
    | number
    | sExpr
    | atomExpression arrayIndex
    | atomExpression DOT LENGTH
    ;
    
expression
    : expression OP_MUL expression
    | expression OP_ADD expression
    | expression OP_CMP expression
    | expression OP_EQ expression
    | expression OP_CONJ expression
    | expression OP_DISJ expression
    | LPAR expression RPAR
    | (OP_ADD)? atomExpression
    ;
    

functionCall
    : identifier LPAR expressionList RPAR
    ;

expressionList
    : expression (COMMA expression)*;

sExpr
    : TAG (LPAR expressionList RPAR)?
    ;

array
    : LBRACK arrayElementList RBRACK
    ;

arrayElementList
    : expression (COMMA expression)*
    ;
TAG
    : TIC IDENT 
    ;

identifier
    : IDENT
    ;

number
    : DECIMAL
    ;

IF : 'if';
THEN : 'then';
ELIF : 'elif';
ELSE : 'else';
FI : 'fi';
FOR : 'for';
WHILE : 'while';
DO : 'do';
OD : 'od';
CASE : 'case';
ESAC : 'esac';
REPEAT : 'repeat';
UNTIL : 'until';
LOCAL : 'local';
OF : 'OF';
LENGTH : 'length';
RETURN : 'return';
SKIP_KW : 'skip';
FUN : 'fun';


ASSIGN : ':=';

OP_DISJ : '!!';
OP_CONJ : '&&';
OP_EQ : ('=='|'!=');
OP_CMP : '<' | '>' | '<=' | '>=' | '==' | '!=';
OP_ADD : [+-];
OP_MUL : ('*'|'/'|'%');

IDENT : ('a' .. 'z' | 'A' .. 'Z') ('a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_')*;

DECIMAL : ('0' .. '9')+;

TIC : '\'';
DOT : '.';
COMMA : ',';
WILDCARD : '_';
ARROW : '->';
SEMI : ';';
BAR : '|';

LBRACK : '[';
RBRACK : ']';

LPAR : '(';
RPAR: ')';


LCURL : '{';
RCURL: '}';


WS : [ \t\r\n] -> channel(HIDDEN);


COMMENT_1 : '//'(~[\r\n])*;

COMMENT_2 : '(*' .*? '*)';

UNKNOWN : . ;

