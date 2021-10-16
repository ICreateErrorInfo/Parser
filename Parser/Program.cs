using System;

namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            string program = "/** Number: \n" +
                             " * Documentation comment \n" +
                             " */ \n" +
                             "\"Hello\"";

            ASTNode ast = parser.Parse(program);

            Console.WriteLine(ast.ToString());
        }
    }
}
