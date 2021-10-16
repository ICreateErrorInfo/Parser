using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class ASTNode
    {
        public string type;
        public object value;

        public ASTNode(string type, object value)
        {
            this.type = type;
            this.value = value;
        }

        public override string ToString()
        {
            return $"(\n  type: {type}, \n  value: {value}\n)";
        }
    }
}
