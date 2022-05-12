using Test;

Questions.ProceedQuestions(Questions.ParseQuestions(Questions.ReadFile("data/input.txt"))).GenerateFile("data/output.txt");