using System.Text.RegularExpressions;

namespace Parser.Lexer
{
    class TokenRegex
    {
        private Regex _regex;
        private readonly TokenType _returnTokenType;

        public TokenRegex(TokenType returnTokenType, string regexPattern)
        {
            _regex = new Regex(regexPattern);
            _returnTokenType = returnTokenType;
        }

        public TokenMatch Match(string inputString)
        {
            var match = _regex.Match(inputString);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != inputString.Length)
                {
                    remainingText = inputString.Substring(match.Length);
                }

                return new TokenMatch
                {
                    IsMatch = true,
                    RemainingText = remainingText,
                    TokenType = _returnTokenType,
                    Value = match.Value
                };
            }
            else
            {
                return new TokenMatch() { IsMatch = false };
            }
        }
    }
}
