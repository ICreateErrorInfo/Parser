using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser.Nodes
{
    public class Equation : TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public Equation(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
        }

        public override double eval()
        {
            TreeNode equasion = new Equation(null, null);

            if(left.GetType() == typeof(Variable))
            {
                Variable.varibleValues.Add(((Variable)left).symbol, right.eval());
                return left.eval();
            }
            else if(right.GetType() == typeof(Variable))
            {
                Variable.varibleValues.Add(((Variable)right).symbol, left.eval());
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
                left = new Variable("x");
                treeNode = new Equation(right, left);
                return true;
            }
            if (right.solve(ref left))
            {
                Console.WriteLine("Left:" + left.ToString());
                right = new Variable("x");
                treeNode = new Equation(right, left);
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
