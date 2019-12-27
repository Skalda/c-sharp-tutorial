using System;
using System.Collections.Generic;

namespace NullableIntroduction
{
    public class SurveyResponse
    {
        public int Id { get; }

        public SurveyResponse(int id) => Id = id;
        
        private static readonly Random RandomGenerator = new Random();
        public static SurveyResponse GetRandomId() => new SurveyResponse(RandomGenerator.Next());

        private Dictionary<int, string>? surveyResponses;

        public bool AnswerSurvey(IEnumerable<SurveyQuestion> questions)
        {
            if (ConsentToSurvey())
            {
                surveyResponses = new Dictionary<int, string>();
                int index = 0;
                foreach (var question in questions)
                {
                    var answer = GenerateAnswer(question);
                    if (answer != null)
                    {
                        surveyResponses.Add(index, answer);
                    }

                    index++;
                }
            }

            return surveyResponses != null;
        }

        private bool ConsentToSurvey() => RandomGenerator.Next(0, 2) == 1;

        private string? GenerateAnswer(SurveyQuestion question)
        {
            switch (question.TypeOfQuestion)
            {
                case QuestionType.YesNo:
                    int n = RandomGenerator.Next(-1, 2);
                    return (n == -1) ? default : (n == 0) ? "No" : "Yes";
                case QuestionType.Number:
                    n = RandomGenerator.Next(-30, 101);
                    return (n < 0) ? default : n.ToString();
                case QuestionType.Text:
                default:
                    return RandomGenerator.Next(0, 5) switch
                    {
                        0 => default,
                        1 => "Red",
                        2 => "Green",
                        3 => "Blue",
                        _ => "Red. No, Green. Wait.. Blue ... AAARGGGGHH!"
                    };
            }
        }
        
        public bool AnsweredSurvey => surveyResponses != null;
        public string Answer(int index) => surveyResponses?.GetValueOrDefault(index) ?? "No answer";
    }
}