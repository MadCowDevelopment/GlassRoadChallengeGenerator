// © 2019 Baker Hughes, a GE company.  All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes, a GE company.
// Do not use, copy or distribute without permission.
namespace grcg
{
    internal class ChallengeResult
    {
        public string ThreadId { get; }
        public string Score { get; }
        public string User { get; }

        public ChallengeResult(string threadId, string score, string user)
        {
            ThreadId = threadId;
            Score = score;
            User = user;
        }
    }
}