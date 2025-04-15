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
      return chores;
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}