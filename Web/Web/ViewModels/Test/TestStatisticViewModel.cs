namespace Web.ViewModels
{
    public class TestStatisticViewModel
    {
        public TestViewModel Test { get; set; }

        public int CountCompleted { get; set; }

        public double MiddlePercentOfCompleted { get; set; }

        public class QuestionStat
        {
            public QuestionViewModel Question { get; set; } 
        }
    }
}