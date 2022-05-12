namespace Test;

public class Result
{
    public List<string> wrongAnswers = new List<string>();
    public float rightPercent;
    public int rightAnswersCount;
    public int wrongAnswersCount;

    public void GenerateFile(string path)
    {
        string str = "";
        str += "Wrong Answers: \n";
        str += string.Join("\n", wrongAnswers);
        str += "\n\nRight Percent: " + (rightPercent * 100) + "%\n";
        str += "\n\nRight Answers Count: " + rightAnswersCount + "\n";
        str += "\n\nWrong Answers Count: " + wrongAnswersCount + "\n";
        File.WriteAllText(path, str);
    }
}