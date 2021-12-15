using System.Collections.Generic;

namespace Parser.Lexer
{
    public enum TokenType
    {
        Add,
        Sub,
        Number,
        SequenceTerminator,
        Invalid
    }

    static class TokenTypeRegex
    {
        public static List<TokenRegex> RegexList = new List<TokenRegex>()
        {
            new TokenRegex(TokenType.Number, "^\\d+"),
            new TokenRegex(TokenType.Add,    "^\\+"),
            new TokenRegex(TokenType.Sub,    "^\\-"),
        };
    }
}
