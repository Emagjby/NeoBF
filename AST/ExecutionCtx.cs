namespace NeoBF.AST;

public class ExecutionCtx
{
    public byte[] Tape { get; }
    public int Pointer { get; set; }

    public ExecutionCtx(int tapeSize = 30_000)
    {
        Tape = new byte[tapeSize];
        Pointer = 0;
    }
}
