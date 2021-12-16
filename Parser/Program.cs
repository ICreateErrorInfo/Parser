using Parser.Lexer;
using Parser.Parser;
using System;

namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RDParser parser = new RDParser();
                Tokenizer tokenizer = new Tokenizer();

                var tokens = tokenizer.Tokenize(Console.ReadLine());

                foreach (var token in tokens)
                {
                    Console.Write(token.Value);
                    Console.Write($", {token.TokenType}");
                    Console.WriteLine();
                }

                parser.Parse(tokens);
                foreach (var node in parser.nodes)
                {
                    Console.WriteLine(node.ToString());
                }
            }
        }
    }
}
