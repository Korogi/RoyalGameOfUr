using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class Square
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public SquareType Type { get; set; }

        public Square(int id, int order, SquareType type)
            => (Id, Order, Type) = (id, order, type);
    }
}
