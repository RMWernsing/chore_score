
namespace chore_score.Services;

public class ChoresService
{

  public ChoresService(ChoresRepository repository)
  {
    _repository = repository;
  }

  private readonly ChoresRepository _repository;

  public List<Chore> GetAllChores()
  {
    List<Chore> chores = _repository.GetAllChores();
    return chores;
  }

  public Chore GetChoreById(int choreId)
  {
    Chore chore = _repository.GetChoreById(choreId);
    if (chore == null)
    {
      throw new Exception($"Invalid chore id: {choreId}");
    }
    return chore;
  }

  internal void DeleteChore(int choreId)
  {
    _repository.DeleteChore(choreId);
  }
}