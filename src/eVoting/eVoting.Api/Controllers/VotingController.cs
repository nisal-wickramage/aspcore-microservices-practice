using System;
using System.Threading.Tasks;
using eVoting.Application;
using eVoting.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eVoting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly ILogger<VotingController> _logger;
        private readonly IVotePublisher _votePublisher;

        public VotingController(
            ILogger<VotingController> logger,
            IVotePublisher votePublisher)
        {
            _logger = logger;
            _votePublisher = votePublisher;
        }

        [HttpPost]
        [Route("{option}")]
        public async Task<IActionResult> Record(VoteOptions option)
        {
            _logger.LogInformation("Starting to record the vote");
            var vote = new Vote
            {
                Option = option,
                VotedDateTime = DateTime.UtcNow
            };
            await _votePublisher.Publish(vote);
            _logger.LogInformation("Finished recording the vote");
            return Ok();
        }
    }
}
