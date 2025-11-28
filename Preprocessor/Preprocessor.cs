namespace NeoBF.Preprocessing;

public class Preprocessor
{
    private string _source;

    public Preprocessor(string source)
    {
        _source = source;
    }

    public string Preprocess()
    {
        _source = new CommentStripper(_source).Strip();
        _source = new WhitespaceCleaner(_source).RemoveWhitespaces();
        return _source;
    }
}
