using RoyalGameOfUr.Common;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    class GameHandler
    {
        public Game Game { get; private set; }
        

        private readonly Random _randomGenerator = new Random();
        public GameHandler(Game game)
            => Game = game;

        public void MakeMove(Stone stoneToMove, int stepsToMove)
        {

            bool IsValidMove() =>  false;
            bool IsSquareOccupiable() 
                => Game.Board.GetSquareByOrder(stoneToMove.Order + stepsToMove).Type != SquareType.InaccessibleSquare;
        }

        public int RollDice()
        {
            var poolOfPossibleOutcomes = Enumerable.Repeat(0, 1).Concat(Enumerable.Repeat(1, 4)
                                              .Concat(Enumerable.Repeat(2, 6)
                                              .Concat(Enumerable.Repeat(3, 4)
                                              .Concat(Enumerable.Repeat(4, 1))))).ToList();

            return poolOfPossibleOutcomes[_randomGenerator.Next(0, 16)];
        }

    }
}
