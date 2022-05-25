using Quiz;

string path = "data/input.txt";

while (true)
{
    Console.WriteLine("Do you want to add questions? (y/n)");
    if (Console.ReadLine() != "y") break;

    Console.WriteLine("Enter question name: ");
    string questionName = Console.ReadLine();

    Console.WriteLine("Enter question variants (split by commas): ");
    string[] questionVariants = Console.ReadLine().Split(',');
    
    Console.WriteLine("Enter right answer: ");
    string rightAnswer = Console.ReadLine();
    
    string file = File.ReadAllText(path).Trim();
    file += "\r\n" + questionName + "\r\n";
    file += string.Join(", ", questionVariants.Select((v, i) => $"{i + 1} - {v.Trim()}")) + "\r\n";
    file += rightAnswer + "\r\n";
    File.WriteAllText(path, file);
}

Test.ProceedQuestions(Test.ParseQuestions(Test.ReadFile(path))).GenerateFile("data/output.txt");