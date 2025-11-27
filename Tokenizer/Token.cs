namespace NeoBF.Lexer;

public struct Token
{
    public TokenType Type { get; }

    public Token(TokenType type)
    {
        Type = type;
    }
}
