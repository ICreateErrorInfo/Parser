using Parser.Lexer;
using System;

namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Tokenizer tokenizer = new Tokenizer();

                var tokens = tokenizer.Tokenize(Console.ReadLine());

                foreach (var token in tokens)
                {
                    Console.Write(token.Value);
                    Console.Write($", {token.TokenType}");
                    Console.WriteLine();
                }
            }
        }
    }
}
