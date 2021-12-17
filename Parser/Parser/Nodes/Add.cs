using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Add : TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public Add(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
        }

        public override double eval()
        {
            return left.eval() + right.eval();
        }

        public override bool solve(ref TreeNode treeNode)
        {
            if(left.solve(ref treeNode))
            {
                treeNode = new Sub(treeNode, right);
                return true;
            }
            else if (right.solve(ref treeNode))
            {
                treeNode = new Sub(treeNode, left);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"({left.ToString()} + {right.ToString()})";
        }
    }
}
