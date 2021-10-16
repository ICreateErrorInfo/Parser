using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parser
{
    class Exp
    {
        public string regex;
        public string type;

        public Exp(string exp, string type)
        {
            this.regex = exp;
            this.type = type;
        }
    }
    public class Tokenizer
    {
        Exp[] spec =
        {
            new(@"^\d+", "NUMBER"),

            new("^\"(?<text>[^\"]*)\"", "STRING"),
            new("'[^']*'", "STRING")
        };

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

            foreach(Exp exp in spec)
            {
                ASTNode tokenValue = _match(exp.regex, _string);

                if(tokenValue == null)
                {
                    continue;
                }

                return new ASTNode(
                    type: exp.type,
                    value: tokenValue.value
                    );
            }

            return null;
        }

        private ASTNode _match(string regexp, string str)
        {
            MatchCollection matched = Regex.Matches(str, regexp);
            if (matched != null && matched.Count != 0)
            {
                _cursor += matched.Count;
                return new ASTNode(
                    type: "STRING",
                    value: matched[0].Groups["text"].Value
                );
            }
            else
            {
                return null;
            }
        }
    }
}
