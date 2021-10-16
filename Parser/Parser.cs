using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parser
{
    public class Parser
    {
        private string _string;
        private Tokenizer _tokenizer;
        private ASTNode _lookahead;

        public Parser()
        {
            _string = "";
            _tokenizer = new Tokenizer();
        }

        //Parses a string into an AST
        public ASTNode Parse(string s)
        {
            _string = s;
            _tokenizer.init(s);

            _lookahead = _tokenizer.getNextToken();

            return Program();
        }

        private ASTNode Program()
        {
            return new ASTNode(
                type: "Program",
                value: Literal()
                );
        }

        private ASTNode Literal()
        {
            switch (_lookahead.type)
            {
                case "NUMBER":
                    return NumericLiteral();
                case "STRING":
                    return StringLiteral();
            }

            throw new Exception("Literal: unexpected literal production");
        }

        private ASTNode StringLiteral()
        {
            ASTNode token = _eat("STRING");
            return new ASTNode(
                type: "StringLiteral",
                value: token.value
            );
        }

        private ASTNode NumericLiteral()
        {
            ASTNode token = _eat("NUMBER");
            return new ASTNode(
                type: "NumericLiteral",
                value: Convert.ToInt32(token.value)
            );
        }

        private ASTNode _eat(string tokenType)
        {
            ASTNode token = _lookahead;

            if(token == null)
            {
                throw new Exception($"Unexpected end of input, expected: {tokenType}");
            }

            if(token.type != tokenType)
            {
                throw new Exception($"Unexpected token: {token.value}, expected: {tokenType}");
            }

            _lookahead = _tokenizer.getNextToken();

            return token;
        }
    }
}
