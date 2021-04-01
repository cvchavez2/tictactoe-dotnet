using Tictactoe.Service.Models;

namespace Tictactoe.Service.Services
{
  public interface IGameService
  {
    string SetNewGame();

    GameInfo PcMakeMovement(GameInfo gi);
  }
}