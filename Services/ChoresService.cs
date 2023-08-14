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
            Chore chore = _choresRepository.CreateChore(choreData);
            return chore;
        }

        internal void DeleteChore(Guid choreId)
        {
            GetChoreById(choreId);
            _choresRepository.DeleteChore(choreId);
        }

        internal Chore EditChore(Chore choreData, Guid choreId)
        {
            GetChoreById(choreId);
            Chore chore = _choresRepository.EditChore(choreData, choreId);
            return chore;
        }

        internal Chore GetChoreById(Guid choreId)
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