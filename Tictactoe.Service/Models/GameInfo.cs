namespace Tictactoe.Service.Models
{
  public class GameInfo
  {
    public int NumGames { get; set; }
    public int XWins { get; set; }
    public int OWins { get; set; }
    public int CurrentGame { get; set; }

    public GameModel OngoingGame { get; set; }
  }
}