﻿using System;

namespace grcg
{
    public static class RNG
    {
        private static readonly Random _rng = new Random((int)DateTime.Now.Ticks);

        public static int Between(int inclusiveLowerBound, int inclusiveUpperBound)
        {
            return _rng.Next(inclusiveLowerBound, inclusiveUpperBound + 1);
        }
    }
}
