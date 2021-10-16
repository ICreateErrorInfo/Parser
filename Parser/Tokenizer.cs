using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parser
{
    public class Tokenizer
    {
        string _string;
        int _cursor;

        public void init(string s)
        {
            _string = s;
            _cursor = 0;
        }

        private bool hasMoreTokens()
        {
            return _cursor < _string.Length;
        }

        public ASTNode getNextToken()
        {
            if (!hasMoreTokens())
            {
                return null;
            }

            char[] str = _string.ToCharArray();

            MatchCollection matched = Regex.Matches(_string, @"^\d+");
            if(matched != null && matched.Count != 0)
            {
                _cursor += matched.Count;
                return new ASTNode(
                    type: "NUMBER",
                    value: matched[0].ToString()
                );
            }

            matched = Regex.Matches(_string, "^\"[^\"]*\"");
            if (matched != null && matched.Count != 0)
            {
                _cursor += matched.Count;
                return new ASTNode(
                    type: "STRING",
                    value: matched[0].ToString()
                );
            }

            matched = Regex.Matches(_string, "'[^']*'");
            if (matched != null && matched.Count != 0)
            {
                _cursor += matched.Count;
                return new ASTNode(
                    type: "STRING",
                    value: matched[0].ToString()
                );
            }

            return null;
        }
    }
}
