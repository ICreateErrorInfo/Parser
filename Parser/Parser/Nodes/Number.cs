using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Number : TreeNode
    {
        public double Num;

        public Number(double number)
        {
            Num = number;
        }

        public override double eval()
        {
            return Num;
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
}
