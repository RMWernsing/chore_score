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
}