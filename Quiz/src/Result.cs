namespace Quiz;

public class Result
{
    public readonly List<string> wrongAnswers = new List<string>();
    public float rightPercent;
    public int rightAnswersCount;
    public int wrongAnswersCount;

    public void GenerateFile(string path)
    {
        string str = "";
        str += "Wrong Answers: \n";
        str += string.Join("\n", this.wrongAnswers);
        str += "\n\nRight Percent: " + (this.rightPercent * 100) + "%\n";
        str += "\n\nRight Answers Count: " + this.rightAnswersCount + "\n";
        str += "\n\nWrong Answers Count: " + this.wrongAnswersCount + "\n";
        File.WriteAllText(path, str);
    }
}