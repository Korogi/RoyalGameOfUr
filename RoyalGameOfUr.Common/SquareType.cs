using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public enum SquareType
    {
        OnlyOccupiableByBlackPlayer,
        OnlyOccupiableByWhitePlayer,
        UnsafeOccupiableByBothPlayers,
        SafeOccupiableByBothPlayers, 
        WinningSquare,
        InaccessibleSquare
    }
}
