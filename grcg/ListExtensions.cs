// © 2019 Baker Hughes, a GE company.  All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes, a GE company.
// Do not use, copy or distribute without permission.

using System;
using System.Collections.Generic;

namespace grcg
{
    internal static class ListExtensions
    {
        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}