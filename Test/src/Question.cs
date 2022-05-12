namespace Test;

public class Question
{
    public string question;
    public string[] answers;
    public int rightAnswer;

    public Question(string question, string[] answers, int rightAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.rightAnswer = rightAnswer;
    }

    public Question()
    {
        
    }

    public override string ToString()
    {
        return $"{question}, answers = {string.Join(" ", answers)}, {rightAnswer}";
    }

    public bool CheckAnswer(int answer)
    {
        return answer == rightAnswer;
    }
}