namespace Parser.Lexer
{
    struct TokenMatch
    {
        public bool IsMatch;
        public TokenType TokenType;
        public string Value;
        public string RemainingText;
    }
}
