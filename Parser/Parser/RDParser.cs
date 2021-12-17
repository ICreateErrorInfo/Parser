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
        private List<Token> _tokens;
        private Token nextToken;
        private int tokenIndex = 0;
        public TreeNode resultTree;

        public RDParser()
        {
            _tokens = new List<Token>();
        }

        public double eval()
        {
            return resultTree.eval();
        }
        public bool solve()
        {
            return resultTree.solve(ref resultTree);
        }
        public void Parse(List<Token> tokens)
        {
            _tokens = tokens;

            scanToken();
            resultTree = ParseEquasion();
            if(nextToken.TokenType != TokenType.SequenceTerminator)
            {
                throw new Exception();
            }
        }


        public TreeNode ParseEquasion()
        {
            TreeNode a = ParseExpression();

            if(nextToken.TokenType == TokenType.equals)
            {
                scanToken();
                return new Equation(a, ParseExpression());
            }
            else
            {
                return a;
            }
        }
        public TreeNode ParseExpression()
        {
            TreeNode a;
            a = ParseTerm();

            while (true)
            {
                if (nextToken.TokenType == TokenType.plus)
                {
                    scanToken();
                    var b = ParseTerm();
                    a = new Add(a,b);
                }
                else if (nextToken.TokenType == TokenType.minus)
                {
                    scanToken();
                    var b = ParseTerm();
                    a = new Sub(a, b);
                }
                else
                {
                    return a;
                }
            }
        }
        public TreeNode ParseTerm()
        {
            var a = parseFactor();

            while (true)
            {
                if(nextToken.TokenType == TokenType.multiply)
                {
                    scanToken();
                    var b = parseFactor();
                    a = new Mult(a,b);
                }
                else if(nextToken.TokenType == TokenType.divide)
                {
                    scanToken();
                    var b = parseFactor();
                    a = new Div(a, b);
                }
                else if (nextToken.TokenType == TokenType.power)
                {
                    scanToken();
                    var b = parseFactor();
                    a = new Pow(a, b);
                }
                else
                {
                    return a;
                }
            }
        }
        public TreeNode parseFactor()
        {
            switch (nextToken.TokenType)
            {
                case TokenType.Number:
                    var value = Convert.ToDouble(nextToken.Value);
                    scanToken();
                    return new Number(value);
                case TokenType.OpenParentheses:
                    scanToken();
                    var a = ParseExpression();
                    if (a == null) return null;
                    if (nextToken.TokenType == TokenType.CloseParentheses)
                    {
                        scanToken();
                        return a;
                    }
                    else
                    {
                        return null;
                    }
                case TokenType.minus:
                    scanToken();
                    return new Negate(parseFactor());
                case TokenType.PI:
                    scanToken();
                    return new Number(Math.PI);
                case TokenType.EulersNumber:
                    scanToken();
                    return new Number(Math.E);
                case TokenType.varible:
                    var symbol = nextToken.Value;
                    scanToken();
                    return new Variable(symbol);
            }

            return null;
        }

        public void scanToken()
        {
            nextToken = _tokens[tokenIndex++];
        }
    }
}
