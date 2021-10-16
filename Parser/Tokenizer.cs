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
            new(@"^\s+", null),

            new(@"^\d+"       , "NUMBER"),

            new("^\"[^\"]*\"" , "STRING"),
            new("^'[^']*'"    , "STRING") 
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
            return _cursor < _string.Length - 1;
        }

        public ASTNode getNextToken()
        {
            if (!hasMoreTokens())
            {
                return null;
            }

            string str = _string.Substring(_cursor, _string.Length - _cursor);

            foreach(Exp exp in spec)
            {
                ASTNode tokenValue = _match(exp, str);

                if(tokenValue == null)
                {
                    continue;
                }

                if(exp.type == null)
                {
                    return getNextToken();
                }

                return tokenValue;
            }

            throw new Exception($"Unexpected token: {str[0]}");
        }

        private ASTNode _match(Exp regexp, string str)
        {
            MatchCollection matched = Regex.Matches(str, regexp.regex);
            if (matched != null && matched.Count != 0)
            {
                _cursor += matched[0].Value.Length;
                return new ASTNode(
                    type: regexp.type,
                    value: matched[0].Value
                );
            }
            else
            {
                return null;
            }
        }
    }
}
