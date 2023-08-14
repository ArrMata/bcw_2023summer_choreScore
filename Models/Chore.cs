namespace bcw_2023summer_choreScore.Models
{
    public class Chore
    {
        public Guid Id { get; private set; }
        public string Task { get; set;}
        public bool ? Completed { get; set; } = false;

        public Chore(string? task, bool? completed ) {
            Id = Guid.NewGuid();
            Task = task;
            Completed = completed;
        }

    }
}