using System.Collections.Generic;

namespace Parser.Lexer
{
    public enum TokenType
    {
        plus,
        minus,
        multiply,
        divide,
        Number,
        SequenceTerminator,
        Invalid
    }

    static class TokenTypeRegex
    {
        public static List<TokenDefinition> RegexList = new List<TokenDefinition>()
        {
            new TokenDefinition(TokenType.Number,   "^\\d+(?:\\.\\d+)?"),
            new TokenDefinition(TokenType.plus,     "^\\+"),
            new TokenDefinition(TokenType.minus,    "^\\-"),
            new TokenDefinition(TokenType.multiply, "^\\*"),
            new TokenDefinition(TokenType.divide,   "^\\/"),
        };
    }
}
