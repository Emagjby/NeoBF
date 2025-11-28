using System.Text;

namespace NeoBF.Preprocessing;

public class WhitespaceCleaner
{
    private readonly string _source;

    public WhitespaceCleaner(string source)
    {
        _source = source;
    }

    public string RemoveWhitespaces()
    {
        var inBody = false;
        var sanitized = new StringBuilder();

        foreach (var c in _source)
        {
            switch (c)
            {
                case '{':
                    if (inBody)
                        throw new Exception("Syntax error: Nested '{' not allowed.");

                    inBody = true;
                    sanitized.Append(c);
                    break;

                case '}':
                    if (!inBody)
                        throw new Exception("Syntax error: Unexpected '}'");

                    inBody = false;
                    sanitized.Append(c);
                    break;

                case ' ':
                case '\n':
                case '\t':
                case '\r':
                    if (!inBody)
                        continue;

                    sanitized.Append(c);
                    break;

                default:
                    sanitized.Append(c);
                    break;
            }
        }

        if (inBody)
            throw new Exception("Syntax error: Missing closing '}'");

        return sanitized.ToString();
    }
}
