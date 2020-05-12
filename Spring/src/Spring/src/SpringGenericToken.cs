using System.Text;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Text;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class SpringGenericToken: LeafElementBase, ITokenNode
    {
        private readonly string _text;
        private readonly SpringTokenType _tokenType;

        public SpringGenericToken(string text, SpringTokenType tokenType)
        {
            _text = text;
            _tokenType = tokenType;
        }

        public override int GetTextLength()
        {
            return _text.Length;
        }

        public override StringBuilder GetText(StringBuilder to)
        {
            return to.Append(_text);
        }

        public override IBuffer GetTextAsBuffer()
        {
            return new StringBuffer(_text);
        }

        public override string GetText()
        {
            return _text;
        }

        public override string ToString()
        {
            return "SpringGenericToken(type={0})(string={1})".FormatEx(_tokenType, _text);
        }

        public override NodeType NodeType => _tokenType;
        public override PsiLanguageType Language => SpringLanguage.Instance;
        public TokenNodeType GetTokenType()
        {
            return _tokenType;
        }
    }
}