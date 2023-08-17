namespace bcw_2023summer_choreScore.Services
{
    public class ChoresService
    {
        private readonly ChoresRepository _choresRepository;

        public ChoresService(ChoresRepository choresRepository)
        {
            _choresRepository = choresRepository;
        }

        internal Chore CreateChore(Chore choreData)
        {
            int choreId = _choresRepository.CreateChore(choreData);
            Chore chore = GetChoreById(choreId);
            return chore;
        }

        internal void DeleteChore(int choreId)
        {
            GetChoreById(choreId);
            _choresRepository.DeleteChore(choreId);
        }

        internal Chore EditChore(Chore choreData, int choreId)
        {
            Chore originalChore = GetChoreById(choreId);
            originalChore.Task = choreData.Task ?? originalChore.Task;
            originalChore.Completed = choreData.Completed ?? originalChore.Completed;
            _choresRepository.EditChore(originalChore);
            Chore updatedChore = GetChoreById(choreId);
            return updatedChore;
        }

        internal Chore GetChoreById(int choreId)
        {
            Chore chore = _choresRepository.GetChoreById(choreId);

            if (chore == null)
            {
                throw new Exception($"No chore with the id of {choreId}");
            }

            return chore;
        }

        internal List<Chore> GetChores()
        {
            List<Chore> chores = _choresRepository.GetChores();
            return chores;
        }
    }
}