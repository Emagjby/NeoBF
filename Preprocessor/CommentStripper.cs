namespace NeoBF.Preprocessing;

public class CommentStripper
{
    private readonly string _source;

    public CommentStripper(string source)
    {
        _source = source;
    }

    public string Strip()
    {
        var commentLines = _source.Split('\n', StringSplitOptions.None);

        var processed = commentLines.Select(line =>
        {
            var idx = line.IndexOf(';');
            return idx >= 0 ? line[..idx] : line;
        });

        return string.Join("\n", processed);
    }
}
