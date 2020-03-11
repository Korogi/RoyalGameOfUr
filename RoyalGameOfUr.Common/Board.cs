using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class Board
    {
        public List<int> WhitePlayerStonePositions { get; set; }
        public List<int> BlackPlayerStonePositions { get; set; }

        public List<Square> Squares = new List<Square>
        {
            new Square(id: 0, order: 0, SquareType.OnlyOccupiableByWhitePlayer),
            new Square(id: 1, order: 1, SquareType.OnlyOccupiableByWhitePlayer),

            new Square(id: 2, order: 0, SquareType.OnlyOccupiableByBlackPlayer),
            new Square(id: 3, order: 1, SquareType.OnlyOccupiableByBlackPlayer),

            new Square(id: 4, order: 2, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 5, order: 3, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 6, order: 4, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 7, order: 5, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 8, order: 6, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 9, order: 7, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 10, order: 8, SquareType.SafeOccupiableByBothPlayers),
            new Square(id: 11, order: 9, SquareType.SafeOccupiableByBothPlayers)
            //TODO: continue
        };
    }
}
