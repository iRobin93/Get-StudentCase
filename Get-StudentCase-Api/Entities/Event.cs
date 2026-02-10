namespace Get_StudentCase.Entities
{
    public class Event
    {
        public int EventId { get; set; }

        public DateTime OccurredUtc { get; set; }
        public DateTime RecordedUtc { get; set; }

        public int StudentId { get; set; }
        public string Type { get; set; }
        
        
        public string? Name { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? City { get; set; }
        
        
        public string? Course { get; set; }
        public int? Year { get; set; }
        public int? Semester { get; set; }
       
    }
}
