namespace Quiz;

public static class Test
{
    public static string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public static List<Question> ParseQuestions(string str)
    {
        List<Question> questions = new List<Question>();
        Question question = new Question();
        string[] lines = str.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
        {
            switch (i % 3)
            {
                case 0:
                    ParseQuestionName(lines[i], question);
                    break;
                case 1:
                    ParseQuestionAnswers(lines[i], question);
                    break;
                case 2:
                    ParseRightAnswer(lines[i], question);
                    questions.Add(question);
                    question = new Question();
                    break;
            }
        }
        return questions;
    }
    
    public static void ParseQuestionName(string line, Question question)
    {
        question.question = line;
    }
    
    public static void ParseQuestionAnswers(string line, Question question)
    {
        string[] parts = line.Split(',');
        question.answers = new string[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            string[] answerParts = parts[i].Split('-');
            int answerId = int.Parse(answerParts[0]);
            string answerName = answerParts[1];
            question.answers[answerId - 1] = answerName;
        }
    }
    
    public static void ParseRightAnswer(string line, Question question)
    {
        question.rightAnswer = int.Parse(line);
    }

    public static Result ProceedQuestions(List<Question> questions)
    {
        Result result = new Result();
        foreach (Question question in questions)
        {
            Console.WriteLine(question.question);
            for (var i = 0; i < question.answers.Length; i++)
            {
                string presentAnswer = question.answers[i];
                if (question.answers.Length == i + 1)
                {
                    Console.Write((i + 1) + " -" + presentAnswer);
                }
                else
                {
                    Console.Write((i + 1) + " -" + presentAnswer + ", ");
                }
            }

            Console.WriteLine();

            string answer = Console.ReadLine()!;
            int answerId = int.Parse(answer);

            if (!question.CheckAnswer(answerId))
            {
                if (answerId < 1 || answerId > question.answers.Length)
                {
                    result.wrongAnswers.Add(question.question + ": " + "Invalid" + " " + question.answers[question.rightAnswer - 1]);
                }
                else
                {
                    result.wrongAnswers.Add(question.question + ": " + question.answers[answerId - 1] + " " + question.answers[question.rightAnswer - 1]);
                }
                result.wrongAnswersCount++;
            }
            else
            {
                result.rightAnswersCount++;
            }
        }

        result.rightPercent = (float)result.rightAnswersCount / (result.rightAnswersCount + result.wrongAnswersCount);
        return result;
    }
}