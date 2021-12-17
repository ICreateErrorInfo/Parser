using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Negate : TreeNode
    {
        public TreeNode arg;

        public Negate(TreeNode arg)
        {
            this.arg = arg;
        }

        public override double eval()
        {
            return -arg.eval();
        }
        public override bool solve(ref TreeNode treeNode)
        {
            throw new NotImplementedException("No negate");
            return arg.solve(ref treeNode);
        }

        public override string ToString()
        {
            return $"(-{arg.ToString()})";
        }
    }
}
