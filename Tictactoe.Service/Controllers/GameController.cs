using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tictactoe.Service.Services;

namespace Tictactoe.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GameController : ControllerBase
  {
    private readonly IGameService _gameService;
    public GameController(IGameService gameService)
    {
      this._gameService = gameService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult NewGame(){
      return Ok(_gameService.SetNewGame());
    }
  }
}