using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class Stone
    {
        public int Id { get; set; }
        public int Order { get; set; }

        public Stone(int id, int order)
            => (Id, Order) = (id, order);

    }
}
