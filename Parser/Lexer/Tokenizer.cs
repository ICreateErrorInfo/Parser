using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parser.Lexer
{
    public class Tokenizer
    {
        private List<TokenDefinition> _tokenDefinitions;

        public Tokenizer()
        {
            _tokenDefinitions = TokenTypeRegex.RegexList;
        }

        public List<Token> Tokenize(string Input)
        {
            var tokens = new List<Token>();
            string remainingText = Input;

            while (!string.IsNullOrWhiteSpace(remainingText))
            {
                var match = FindMatch(remainingText);
                if (match.IsMatch)
                {
                    tokens.Add(new Token(match.TokenType, match.Value));
                    remainingText = match.RemainingText;
                }
                else
                {
                    if (IsWhitespace(remainingText))
                    {
                        remainingText = remainingText.Substring(1);
                    }
                    else
                    {
                        var invalidTokenMatch = CreateInvalidTokenMatch(remainingText);
                        tokens.Add(new Token(invalidTokenMatch.TokenType, invalidTokenMatch.Value));
                        remainingText = invalidTokenMatch.RemainingText;
                    }
                }
            }

            tokens.Add(new Token(TokenType.SequenceTerminator, string.Empty));

            return tokens;
        }

        private TokenMatch FindMatch(string text)
        {
            foreach (var tokenDefinition in _tokenDefinitions)
            {
                var match = tokenDefinition.Match(text);
                if (match.IsMatch)
                {
                    return match;
                }
            }

            return new TokenMatch()
            { 
                IsMatch = false 
            };
        }
        private bool IsWhitespace(string text)
        {
            return Regex.IsMatch(text, "^\\s+");
        }
        private TokenMatch CreateInvalidTokenMatch(string text)
        {
            var match = Regex.Match(text, "(^\\S+\\s)|^\\S+");
            if (match.Success)
            {
                return new TokenMatch()
                {
                    IsMatch = true,
                    RemainingText = text.Substring(match.Length),
                    TokenType = TokenType.Invalid,
                    Value = match.Value.Trim()
                };
            }

            throw new Exception("Failed to generate invalid token");
        }
    }
}
