namespace Parser.Lexer
{
    public class Token
    {
        public TokenType TokenType;
        public string Value;


        public Token(TokenType tokenType)
        {
            TokenType = tokenType;
            Value = string.Empty;
        }
        public Token(TokenType tokenType, string value)
        {
            TokenType = tokenType;
            Value = value;
        }
    }
}
