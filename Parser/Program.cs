using System;

namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            string program = "\"Hello\"";

            ASTNode ast = parser.Parse(program);

            Console.WriteLine(ast.ToString());
        }
    }
}
