


namespace chore_score.Repositories;

public class ChoresRepository
{
  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;
  public List<Chore> GetAllChores()
  {
    string sql = "SELECT * FROM chores;";
    List<Chore> chores = _db.Query<Chore>(sql).ToList();
    return chores;
  }

  public Chore GetChoreById(int choreId)
  {
    string sql = "SELECT * FROM chores WHERE id = @choreId;";
    Chore chore = _db.Query<Chore>(sql, new { choreId = choreId }).SingleOrDefault();
    return chore;
  }

  internal void DeleteChore(int choreId)
  {
    string sql = "DELETE FROM chores WHERE id = @choreId";
    int rowsAffected = _db.Execute(sql, new { choreId });

    if (rowsAffected == 1)
    {
      return;
    }
    if (rowsAffected == 0)
    {
      throw new Exception("0 chores have been deleted");
    }
    if (rowsAffected > 1)
    {
      throw new Exception($"{rowsAffected} chores have been deleted. Likely unintentional. Please check code");
    }

  }

  internal Chore CreateChore(Chore choreData)
  {
    string sql = @"
    INSERT INTO 
    chores(name, description, is_complete) 
    VALUES(@Name, @Description, @IsComplete);

    SELECT * FROM chores WHERE id = LAST_INSERT_ID();";

    Chore chore = _db.Query<Chore>(sql, choreData).SingleOrDefault();
    return chore;
  }
}