
namespace chore_score.Repositories;

public class ChoresRepository
{
  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;
  internal List<Chore> GetAllChores()
  {
    string sql = "SELECT * FROM chores;";
    List<Chore> chores = _db.Query<Chore>(sql).ToList();
    return chores;
  }
}