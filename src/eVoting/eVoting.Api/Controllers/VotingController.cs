using System;
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
        private readonly IVoteRepository _voteRepository;

        public VotingController(
            ILogger<VotingController> logger,
            IVoteRepository voteRepository)
        {
            _logger = logger;
            _voteRepository = voteRepository;
        }

        [HttpPost]
        public IActionResult Record(VoteOptions option)
        {
            _logger.LogInformation("Starting to record the vote");
            var vote = new Vote
            {
                Option = option,
                VotedDateTime = DateTime.UtcNow
            };
            _voteRepository.Save(vote);
            _logger.LogInformation("Finished recording the vote");
            return Ok();
        }
    }
}
