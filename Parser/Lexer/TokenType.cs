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
        OpenParentheses,
        CloseParentheses,
        power,
        PI,
        equals,
        varible,
        EulersNumber,
        SequenceTerminator,
        Invalid
    }

    static class TokenTypeRegex
    {
        public static List<TokenDefinition> RegexList = new List<TokenDefinition>()
        {
            new TokenDefinition(TokenType.Number,            "^\\d+(?:\\.\\d+)?"),
            new TokenDefinition(TokenType.plus,              "^\\+"),
            new TokenDefinition(TokenType.minus,             "^\\-"),
            new TokenDefinition(TokenType.multiply,          "^\\*"),
            new TokenDefinition(TokenType.divide,            "^\\/"),
            new TokenDefinition(TokenType.OpenParentheses,   "^\\("),
            new TokenDefinition(TokenType.CloseParentheses,  "^\\)"),
            new TokenDefinition(TokenType.power,             "^\\^"),
            new TokenDefinition(TokenType.PI,                "^(pi|Pi|PI)"),
            new TokenDefinition(TokenType.EulersNumber,      "^e"),
            new TokenDefinition(TokenType.equals,            "^="),
            new TokenDefinition(TokenType.varible,           "^[a-z]"),
        };
    }
}
