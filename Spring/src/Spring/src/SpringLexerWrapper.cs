using Antlr4.Runtime;

namespace JetBrains.ReSharper.Plugins.Spring
{
    using Psi.Parsing;
    using Text;
    public class SpringLexerWrapper : ILexer<int>
    {
        private readonly SpringLexer _springLexer;
        private IToken _token;
        private int _currentPosition;

        public SpringLexerWrapper(IBuffer buffer)
        {
            Buffer = buffer;
            _currentPosition = 0;
            _springLexer = new SpringLexer(new AntlrInputStream(Buffer.GetText()));
        }


        public void Start()
        {
            Advance();
        }

        public void Advance()
        {
            _token = _springLexer.NextToken();
            _currentPosition++;
        }

        public int CurrentPosition
        {
            get => _currentPosition;
            set
            {
                _springLexer.Reset();
                _currentPosition = 0;
                while (_currentPosition < value)
                {
                    _token = _springLexer.NextToken();
                    _currentPosition++;
                }
            }
        }

        object ILexer.CurrentPosition
        {
            get => CurrentPosition;
            set => CurrentPosition = (int) value;
        }

        public TokenNodeType TokenType => SpringTokenType.FromAntlr(_token.Type);
        public int TokenStart => _token.StartIndex;
        public int TokenEnd => _token.StopIndex + 1;
        public IBuffer Buffer { get; }
    }
}