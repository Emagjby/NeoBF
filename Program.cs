using NeoBF.AST;
using NeoBF.Lexer;
using NeoBF.Parsing;

namespace NeoBF;

public class Program
{
    public static void Main(string[] args)
    {
        // Read file at path sent
        var source = File.ReadAllText(args[0]);

        // Tokenize source
        var tokenizer = new Tokenizer(source);
        var tokens = tokenizer.Tokenize();

        // Generate AST Nodes from tokens list
        var parser = new Parser(tokens);
        var nodes = parser.Parse();

        // Execute nodes
        var executionContext = new ExecutionCtx();
        foreach (var node in nodes)
        {
            node.Execute(executionContext);
        }
    }
}
