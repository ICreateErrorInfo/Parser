using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Variable : TreeNode
    {
        public static Dictionary<string, double> varibleValues = new Dictionary<string, double>();
        public string symbol;

        public Variable(string symbol)
        {
            this.symbol = symbol;
        }

        public override double eval()
        {
            if (varibleValues.ContainsKey(symbol))
            {
                return varibleValues[symbol];
            }
            throw new Exception();
        }
        public override bool solve(ref TreeNode treeNode)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{symbol}";
        }
    }
}
