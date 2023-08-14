namespace bcw_2023summer_choreScore.Repositories
{
    public class ChoresRepository
    {
        private List<Chore> dbChores;

        public ChoresRepository()
        {
            dbChores = new List<Chore>();
        }

        internal Chore CreateChore(Chore choreData)
        {
            dbChores.Add(choreData);
            return choreData;
        }

        internal void DeleteChore(Guid choreId)
        {
            Chore chore = GetChoreById(choreId);
            dbChores.Remove(chore);
        }

        internal Chore EditChore(Chore choreData, Guid choreId)
        {
            Chore chore = GetChoreById(choreId);
            chore.Task = choreData.Task ?? chore.Task;
            chore.Completed = choreData.Completed != null ? choreData.Completed : chore.Completed;
            return chore;
        }

        internal Chore GetChoreById(Guid choreId)
        {
            Chore chore = dbChores.Find(chore => chore.Id == choreId);
            return chore;
        }

        internal List<Chore> GetChores() {
            return dbChores;
        }

    }
}