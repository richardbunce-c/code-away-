namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }

        public int PossibleMarks { get; private set; }

        public string SubmitterName { get; private set; }
   
    public string LetterGrade 
        {
        get
            {
                //TODO: Implement logic to calc letter grade
                return "A";
            }
        }
    }
}
