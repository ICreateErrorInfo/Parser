using Parser.Lexer;
using Parser.Parser.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser
{
    public class RDParser
    {
        public List<TreeNode> nodes;
        private List<Token> _tokens;
        private Token nextToken;
        private int tokenIndex = 0;

        public RDParser()
        {
            nodes = new List<TreeNode>();
            _tokens = new List<Token>();
        }

        public void parse(List<Token> tokens)
        {
            _tokens = tokens;

            scanToken();
            nodes.Add(parseE());
            if(nextToken.TokenType != TokenType.SequenceTerminator)
            {
                throw new Exception();
            }
        }

        public TreeNode parseE()
        {
            TreeNode a;
            a = parseT();

            while (true)
            {
                if (nextToken.TokenType == TokenType.plus)
                {
                    scanToken();
                    var b = parseT();
                    a = new Add(a,b);
                }
                else if (nextToken.TokenType == TokenType.minus)
                {
                    scanToken();
                    var b = parseT();
                    a = new Sub(a, b);
                }
                else
                {
                    return a;
                }
            }
        }
        public TreeNode parseT()
        {
            var a = parseF();

            while (true)
            {
                if(nextToken.TokenType == TokenType.multiply)
                {
                    scanToken();
                    var b = parseF();
                    a = new Mult(a,b);
                }
                else if(nextToken.TokenType == TokenType.divide)
                {
                    scanToken();
                    var b = parseF();
                    a = new Div(a, b);
                }
                else
                {
                    return a;
                }
            }
        }
        public TreeNode parseF()
        {
            switch (nextToken.TokenType)
            {
                case TokenType.Number:
                    var value = Convert.ToDouble(nextToken.Value);
                    scanToken();
                    return new Number(value);
                case TokenType.minus:
                    scanToken();
                    return new Negate(parseF());
            }

            return null;
        }

        public void scanToken()
        {
            nextToken = _tokens[tokenIndex++];
        }
    }
}
