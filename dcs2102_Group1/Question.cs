namespace SportsQuizApp
{
    internal class Question
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;

        public Question(string v1, string v2, string v3, string v4, string v5, string v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

        public object Option4 { get; internal set; }
        public object Text { get; internal set; }
    }
}