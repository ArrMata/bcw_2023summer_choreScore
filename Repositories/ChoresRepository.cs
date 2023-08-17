namespace bcw_2023summer_choreScore.Repositories
{
    public class ChoresRepository
    {
        private readonly IDbConnection _db;

        public ChoresRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int CreateChore(Chore choreData)
        {
            string sql = @"
            INSERT INTO chores(task, completed, creatorId)
            VALUES (@Task, @Completed, @CreatorId);
            SELECT LAST_INSERT_ID()
            ;";
            int choreId = _db.ExecuteScalar<int>(sql, choreData);
            return choreId;
        }

        internal void DeleteChore(int choreId)
        {
            string sql = "DELETE FROM chores WHERE id = @ChoreId LIMIT 1;";
            _db.Execute(sql, new { choreId });
        }

        internal void EditChore(Chore editedChore)
        {
            string sql = @"
            UPDATE cars
            SET
            task = @Task,
            completed = @Completed,
            WHERE id = @Id
            LIMIT 1;
            ;";
            _db.Execute(sql, editedChore);
        }

        internal Chore GetChoreById(int choreId)
        {
            string sql = @"
            SELECT 
            chore.*,
            acc.*
            FROM chores chore
            JOIN accounts acc ON acc.id = chore.creatorId
            WHERE chore.id = @ChoreId LIMIT 1
            ;";
            Chore chore = _db.Query<Chore, Profile, Chore>(sql, 
            (chore, profile) => {
                chore.Creator = profile;
                return chore;
            },
            new { choreId }).FirstOrDefault();
            return chore;
        }

        internal List<Chore> GetChores() {
            string sql = @"
            SELECT 
            chore.*,
            acc.*
            FROM chores chore
            JOIN accounts acc ON acc.id = chore.creatorId
            ;";

            List<Chore> chores = _db.Query<Chore, Profile, Chore>(
                sql, 
                (chore, profile) => 
                {
                    chore.Creator = profile;
                    return chore;
                }
                ).ToList();

            return chores;
        }

    }
}