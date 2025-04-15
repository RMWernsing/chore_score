namespace chore_score.Controllers;

[ApiController]
[Route("api/chores")]
public class ChoresController : ControllerBase
{

  public ChoresController(ChoresService choresService)
  {
    _choresService = choresService;
  }
  private readonly ChoresService _choresService;

  [HttpGet]
  public ActionResult<List<Chore>> GetAllChores()
  {
    try
    {
      List<Chore> chores = _choresService.GetAllChores();
      return Ok(chores);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpGet("{choreId}")]
  public ActionResult<Chore> GetChoreById(int choreId)
  {
    try
    {
      Chore chore = _choresService.GetChoreById(choreId);
      return Ok(chore);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpDelete("{choreId}")]
  public ActionResult<string> DeleteChore(int choreId)
  {
    try
    {
      _choresService.DeleteChore(choreId);
      return Ok("Chore was deleted!");
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}