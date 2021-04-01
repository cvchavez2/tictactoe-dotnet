using System;
using Tictactoe.Service.Models;

namespace Tictactoe.Service.Services
{
  public class GameService : IGameService
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

    public GameInfo PcMakeMovement(GameInfo gi){
      if(gi.CurrentGame>gi.NumGames)
      {
        // throw exception here
        // return
      }
      gi.OngoingGame = PcMove(gi.OngoingGame);
      if(gi.OngoingGame.Winner!=null)
      {
        ProcessWin(gi);
      }
      return gi;
    }

    public void ProcessWin(GameInfo gi)
    {
        if(string.Equals(gi.OngoingGame.Winner, "x", StringComparison.OrdinalIgnoreCase)){
            gi.XWins++;
        }else{
            gi.OWins++;
        }
        gi.CurrentGame++;
    }

    public GameModel PcMove(GameModel gameModel)
    {
      if(this.Board is null)
      {
        SetNewGame();
      }
      if(this.Board[gameModel.Index] == null)
      {
        this.Board[gameModel.Index] = gameModel.Player;
      }
      this.Winner = CalculateWinner();
      GameModel gm = new GameModel();
      if(this.Winner != null)
      {
        gm.Winner = this.Winner;
      }else
      {
        gm.Index = ComputerMovement();
        gm.Player = "O";
      }
      return gm;
    }

    private int ComputerMovement(){
        Random r = new Random();
        int randomMoveIndex = r.Next(0,9);
        if(this.Board[randomMoveIndex] == null){
            this.Board[randomMoveIndex] = "O";
        }else{
            randomMoveIndex = ComputerMovement();
        }
        return randomMoveIndex;
    }
    private String CalculateWinner(){
      int[,] lines = {
              {0,1,2},
              {3,4,5},
              {6,7,8},
              {0,3,6},
              {1,4,7},
              {2,5,8},
              {0,4,8},
              {2,4,6}};
      for(int i = 0; i < lines.Length; i++)
      {
          int [] abc = new int[3];
          abc[0] = lines[i,0];
          abc[1] = lines[i,1];
          abc[2] = lines[i,2];
          if((this.Board[abc[0]] != null)
                  && (string.Equals(this.Board[abc[0]], this.Board[abc[1]], StringComparison.OrdinalIgnoreCase))
                  && (string.Equals(this.Board[abc[1]], this.Board[abc[2]], StringComparison.OrdinalIgnoreCase)))
          {
              return this.Board[abc[0]];
          }
      }
      return null;
    }
  }
}