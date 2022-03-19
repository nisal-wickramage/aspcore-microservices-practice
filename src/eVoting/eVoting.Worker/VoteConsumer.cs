using System.Threading.Tasks;
using eVoting.Domain;
using MassTransit;
using System;

namespace eVoting.Worker
{
    public class VoteConsumer : IConsumer<Vote>
    {
        private readonly IVoteRepository _voteRepository;

        public VoteConsumer(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public Task Consume(ConsumeContext<Vote> context)
        {
            Console.WriteLine($"{context.Message.Option}, {context.Message.VotedDateTime}");
            try
            {
                _voteRepository.Save(context.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
            return Task.CompletedTask;
        }
    }
}
