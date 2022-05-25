namespace Quiz;

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
        return $"{this.question}, answers = {string.Join(" ", this.answers)}, {this.rightAnswer}";
    }

    public bool CheckAnswer(int answer)
    {
        return answer == this.rightAnswer;
    }
}