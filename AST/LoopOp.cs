namespace NeoBF.AST;

public class LoopOp : Node
{
    private List<Node> _body;

    public LoopOp(List<Node> body)
    {
        _body = body;
    }

    public override void Execute(ExecutionCtx ctx)
    {
        while (ctx.Tape[ctx.Pointer] != 0)
        {
            foreach (var node in _body)
            {
                node.Execute(ctx);
            }
        }
    }
}
