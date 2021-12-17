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

            throw new Exception();
        }

        public override string ToString()
        {
            return $"{left.ToString()} = {right.ToString()}";
        }
    }
}
