using NeoBF.Lexer;

namespace NeoBF.AST;

public class SimpleOp : Node
{
    private TokenType _operation;

    public SimpleOp(TokenType operation)
    {
        _operation = operation;
    }

    public override void Execute(ExecutionCtx ctx)
    {
        switch (_operation)
        {
            case TokenType.Increment:
                ctx.Tape[ctx.Pointer]++;
                break;

            case TokenType.Decrement:
                ctx.Tape[ctx.Pointer]--;
                break;

            case TokenType.MoveRight:
                ctx.Pointer++;
                break;

            case TokenType.MoveLeft:
                ctx.Pointer--;
                break;

            case TokenType.Print:
                Console.Write((char)ctx.Tape[ctx.Pointer]);
                break;

            case TokenType.Input:
                ctx.Tape[ctx.Pointer] = (byte)Console.Read();
                break;

            default:
                throw new NotImplementedException("Unknown operation.");
        }
    }
}
