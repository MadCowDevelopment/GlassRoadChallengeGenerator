// © 2019 Baker Hughes, a GE company.  All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes, a GE company.
// Do not use, copy or distribute without permission.

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace grcg
{
    internal class ChallengeData : List<ChallengeResult>
    {
        public static ChallengeData Load()
        {
            var data = new ChallengeData();
            foreach (var line in File.ReadAllLines(@".\PreviousChallenges.dat").Select(p=>p.Split(",")))
            {
                data.Add(new ChallengeResult(line[0], line[1], line[2]));
            }

            return data;
        }
    }
}