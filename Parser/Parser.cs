using NeoBF.AST;
using NeoBF.Lexer;

namespace NeoBF.Parsing;

public class Parser
{
    private List<Token> _tokens;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
    }

    public List<Node> Parse()
    {
        List<Node> root = [];
        Stack<List<Node>> stack = [];
        stack.Push(root);

        foreach (var token in _tokens)
        {
            switch (token.Type)
            {
                case TokenType.Increment:
                case TokenType.Decrement:
                case TokenType.MoveRight:
                case TokenType.MoveLeft:
                case TokenType.Print:
                case TokenType.Input:
                    stack.Peek().Add(new SimpleOp(token.Type));
                    break;

                case TokenType.LoopStart:
                    List<Node> body = [];
                    stack.Peek().Add(new LoopOp(body));
                    stack.Push(body);
                    break;

                case TokenType.LoopEnd:
                    stack.Pop();
                    break;
            }
        }

        return root;
    }
}
