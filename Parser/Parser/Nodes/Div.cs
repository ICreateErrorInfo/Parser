using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Div : TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public Div(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
        }

        public override double eval()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"({left.ToString()} / {right.ToString()})";
        }
    }
}
