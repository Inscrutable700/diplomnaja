namespace Web.ViewModels
{
    public class TestResultViewModel
    {
        public TestViewModel Test { get; set; }

        public int Points { get; set; }

        public UserAnswer[] Answers { get; set; }

        public class UserAnswer
        {
            public QuestionViewModel Question { get; set; }

            public AvailableAnswerViewModel RightAnswer { get; set; }

            public AvailableAnswerViewModel Answer { get; set; }

            public bool IsCorrect { get; set; }

            public double Points { get; set; }
        }
    }
}