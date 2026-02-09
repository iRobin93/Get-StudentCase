namespace Get_StudentCase.Entities
{
    public class Event
    {
        public int EventId { get; set; }

        public DateTime OccurredUtc { get; set; }
        public DateTime RecordedUtc { get; set; }

        public int StudentId { get; set; }

        public string Course { get; set; }
        public int Year { get; set; }

        public int Semester { get; set; }
        public string Type { get; set; }
    }
}
