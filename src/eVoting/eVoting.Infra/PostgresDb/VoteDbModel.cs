using System;
using eVoting.Domain;

namespace eVoting.Infra.PostgresDb
{
    public class VoteDbModel
    {
        public int Id { get; set; }
        public string VotedDateTime { get; set; }
        public int Option { get; set; }
    }
}
