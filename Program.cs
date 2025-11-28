using NeoBF.AST;
using NeoBF.Lexer;
using NeoBF.Parsing;
using NeoBF.Preprocessing;

namespace NeoBF;

public class Program
{
    public static void Main(string[] args)
    {
        // Read file at path sent
        var source = File.ReadAllText(args[0]);

        // Preprocess source
        var preprocessor = new Preprocessor(source);
        var preprocessed = preprocessor.Preprocess();

        // Tokenize source
        var tokenizer = new Tokenizer(preprocessed);
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
