namespace bcw_2023summer_choreScore.Models
{
    public class Chore
    {
        public int Id { get; private set; }
        public string Task { get; set;}
        public bool ? Completed { get; set; }
        public string CreatorId { get; set; } 
        public Profile Creator { get; set; }
    }
}