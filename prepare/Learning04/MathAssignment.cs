class MathAssignment : Assignment
{
    private double _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, double textbookSection, string problems) : base(name, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeWorkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}