using System.Collections.Generic;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class SpringTokenType : TokenNodeType
    {
        private static readonly Dictionary<int, SpringTokenType> FromAntlrDict = new Dictionary<int, SpringTokenType>();
        
        public static SpringTokenType IF = new SpringTokenType("IF", 1);
        public static SpringTokenType THEN = new SpringTokenType("THEN", 2);
        public static SpringTokenType ELIF = new SpringTokenType("ELIF", 3);
        public static SpringTokenType ELSE = new SpringTokenType("ELSE", 4);
        public static SpringTokenType FI = new SpringTokenType("FI", 5);
        public static SpringTokenType FOR = new SpringTokenType("FOR", 6);
        public static SpringTokenType WHILE = new SpringTokenType("WHILE", 7);
        public static SpringTokenType DO = new SpringTokenType("DO", 8);
        public static SpringTokenType OD = new SpringTokenType("OD", 9);
        public static SpringTokenType CASE = new SpringTokenType("CASE", 10);
        public static SpringTokenType ESAC = new SpringTokenType("ESAC", 11);
        public static SpringTokenType REPEAT = new SpringTokenType("REPEAT", 12);
        public static SpringTokenType UNTIL = new SpringTokenType("UNTIL", 13);
        public static SpringTokenType LOCAL = new SpringTokenType("LOCAL", 14);
        public static SpringTokenType OF = new SpringTokenType("OF", 15);
        public static SpringTokenType LENGTH = new SpringTokenType("LENGTH", 16);
        public static SpringTokenType RETURN = new SpringTokenType("RETURN", 17);
        public static SpringTokenType SKIP_KW = new SpringTokenType("SKIP_KW", 18);
        public static SpringTokenType FUN = new SpringTokenType("FUN", 19);
        public static SpringTokenType ASSIGN = new SpringTokenType("ASSIGN", 20);
        public static SpringTokenType OP_DISJ = new SpringTokenType("OP_DISJ", 21);
        public static SpringTokenType OP_CONJ = new SpringTokenType("OP_CONJ", 22);
        public static SpringTokenType OP_EQ = new SpringTokenType("OP_EQ", 23);
        public static SpringTokenType OP_CMP = new SpringTokenType("OP_CMP", 24);
        public static SpringTokenType OP_ADD = new SpringTokenType("OP_ADD", 25);
        public static SpringTokenType OP_MUL = new SpringTokenType("OP_MUL", 26);
        public static SpringTokenType IDENT = new SpringTokenType("IDENT", 27);
        public static SpringTokenType DECIMAL = new SpringTokenType("DECIMAL", 28);
        public static SpringTokenType TIC = new SpringTokenType("TIC", 29);
        public static SpringTokenType DOT = new SpringTokenType("DOT", 30);
        public static SpringTokenType COMMA = new SpringTokenType("COMMA", 31);
        public static SpringTokenType WILDCARD = new SpringTokenType("WILDCARD", 32);
        public static SpringTokenType ARROW = new SpringTokenType("ARROW", 33);
        public static SpringTokenType SEMI = new SpringTokenType("SEMI", 34);
        public static SpringTokenType BAR = new SpringTokenType("BAR", 35);
        public static SpringTokenType LBRACK = new SpringTokenType("LBRACK", 36);
        public static SpringTokenType RBRACK = new SpringTokenType("RBRACK", 37);
        public static SpringTokenType LPAR = new SpringTokenType("LPAR", 38);
        public static SpringTokenType RPAR = new SpringTokenType("RPAR", 39);
        public static SpringTokenType LCURL = new SpringTokenType("LCURL", 40);
        public static SpringTokenType RCURL = new SpringTokenType("RCURL", 41);
        public static SpringTokenType WS = new SpringTokenType("WS", 42);
        public static SpringTokenType COMMENT_1 = new SpringTokenType("COMMENT_1", 43);
        public static SpringTokenType COMMENT_2 = new SpringTokenType("COMMENT_2", 44);
        public static SpringTokenType UNKNOWN = new SpringTokenType("UNKNOWN", 45);
        
        private static readonly HashSet<SpringTokenType> Keywords = 
            new HashSet<SpringTokenType> {IF, THEN, ELIF, ELSE, FI, FOR, WHILE, DO, OD, 
                CASE, OF, ESAC, REPEAT, UNTIL, FUN, LOCAL, RETURN, SKIP_KW};

        public static SpringTokenType FromAntlr(int tokenType)
        {
            return FromAntlrDict.GetValueSafe(tokenType);
        }


        private SpringTokenType(string s, int index) : base(s, index)
        {
            FromAntlrDict.Add(index, this);

        }

        public override LeafElementBase Create(IBuffer buffer, TreeOffset startOffset, TreeOffset endOffset)
        {
            return new SpringGenericToken(buffer.GetText(new TextRange(startOffset.Offset, endOffset.Offset)), this);
        }

        public override bool IsWhitespace => this == WS;
        public override bool IsComment => this == COMMENT_1 || this == COMMENT_2;
        public override bool IsStringLiteral => false;
        public override bool IsConstantLiteral => this == DECIMAL;
        public override bool IsIdentifier => this == IDENT;
        public override bool IsKeyword => Keywords.Contains(this);

        public override string TokenRepresentation { get; }
    }
}