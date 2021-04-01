using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tictactoe.Service.Models;
using Tictactoe.Service.Services;

namespace Tictactoe.Service.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GameController : ControllerBase
  {
    private readonly IGameService _gameService;
    public GameController(IGameService gameService)
    {
      this._gameService = gameService;
    }

    /// <summary>
    /// Resets Tictactoe Board
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult NewGame(){
      return Ok(_gameService.SetNewGame());
    }

    [HttpPost]
    [Route("pcMove")]
    public ActionResult<GameInfo> PcMakeMovement(GameInfo info){
      if(info is null){
        return BadRequest();
      }
      return Ok(this._gameService.PcMakeMovement(info));
    }
  }
}