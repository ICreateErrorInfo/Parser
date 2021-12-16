using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Pow : TreeNode
    {
        public TreeNode basis;
        public TreeNode exponent;

        public Pow(TreeNode basis, TreeNode exponent)
        {
            this.basis = basis;
            this.exponent = exponent;
        }

        public override double eval()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"({basis.ToString()}^{exponent.ToString()})";
        }
    }
}
