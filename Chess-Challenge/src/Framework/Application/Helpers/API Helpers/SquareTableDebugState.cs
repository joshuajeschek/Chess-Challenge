﻿using System.Linq;

namespace ChessChallenge.Application.APIHelpers
{
    public static class SquareTableDebugState
    {
        public static bool SquareTableDebugVisualizationRequested { get; set; }
        public static int[] SquareTableToVisualize {get; set;} = Enumerable.Repeat(0, 64).ToArray();
        public static int XORValue {get; set;} = 0;
    }
}
