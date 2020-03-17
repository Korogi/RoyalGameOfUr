using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class Board
    {
        public List<Stone> WhitePlayerStones { get; set; }
        public List<Stone> BlackPlayerStones { get; set; }
        public List<Square> Squares { get; set; }

        public Board()
        {
            this.Squares = new List<Square>();
            int currentId = 0;
            for (int i = 0; i < 4; i++)
            {
                Squares.Add(new Square(id: currentId++, order: i, SquareType.OnlyOccupiableByWhitePlayer)); 
            }

            for (int i = 0; i < 4; i++)
            {
                Squares.Add(new Square(id: currentId++, order: i, SquareType.OnlyOccupiableByBlackPlayer));
            }

            for (int i = 0; i < 8; i++)
            {
                Squares.Add(new Square(id: currentId++, order: i + 4, SquareType.UnsafeOccupiableByBothPlayers));
            }

            Squares.Add(new Square(id: currentId++, order: 12, SquareType.OnlyOccupiableByWhitePlayer));
            Squares.Add(new Square(id: currentId++, order: 13, SquareType.OnlyOccupiableByWhitePlayer));

            Squares.Add(new Square(id: currentId++, order: 12, SquareType.OnlyOccupiableByBlackPlayer));
            Squares.Add(new Square(id: currentId++, order: 13, SquareType.OnlyOccupiableByBlackPlayer));
        }

        public Square GetSquareByOrder(int order)
            => Squares.Where(square => square.Order == order).DefaultIfEmpty().First();

        public Square GetSquarebyId(int id)
            => Squares.Where(square => square.Id == id).DefaultIfEmpty().First();

    }
}
