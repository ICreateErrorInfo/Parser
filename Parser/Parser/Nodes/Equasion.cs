using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Equasion : TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public Equasion(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
        }

        public override double eval()
        {
            TreeNode equasion = new Equasion(null, null);

            if(left.GetType() == typeof(Varible))
            {
                Varible.varibleValues.Add(((Varible)left).symbol, right.eval());
                return left.eval();
            }
            else if(right.GetType() == typeof(Varible))
            {
                Varible.varibleValues.Add(((Varible)right).symbol, left.eval());
                return right.eval();
            }
            if(solve(ref equasion))
            {
                return equasion.eval();
            }

            throw new Exception();
        }
        public override bool solve(ref TreeNode treeNode)
        {
            if (left.solve(ref right))
            {
                Console.WriteLine("Left:" + right.ToString());
                left = new Varible("x");
                treeNode = new Equasion(right, left);
                return true;
            }
            if (right.solve(ref left))
            {
                Console.WriteLine("Left:" + left.ToString());
                right = new Varible("x");
                treeNode = new Equasion(right, left);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{left.ToString()} = {right.ToString()}";
        }
    }
}
