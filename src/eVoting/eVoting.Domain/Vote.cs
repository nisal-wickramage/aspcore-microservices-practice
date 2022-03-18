using System;

namespace eVoting.Domain
{
    public class Vote
    {
        public DateTime VotedDateTime { get; set; }
        public VoteOptions Option { get; set; }
    }
}
