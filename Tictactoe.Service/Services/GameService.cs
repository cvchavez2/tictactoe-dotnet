namespace Tictactoe.Service.Services
{
  public class GameService
  {
    string[] Board { get; set; }
    string Winner { get; set; }

    public GameService()
    {}

    public string SetNewGame()
    {
      this.Board = new string[9];
      this.Winner = null;
      return "new game created";
    }
  }
}