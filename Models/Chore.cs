using System.Security.Cryptography.X509Certificates;

namespace chore_score.Models;

public class Chore
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public bool IsComplete { get; set; }

}