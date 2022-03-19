namespace eVoting.Domain
{
    public class Vote
    {
        public string VotedDateTime { get; set; }
        public VoteOptions Option { get; set; }
    }
}
