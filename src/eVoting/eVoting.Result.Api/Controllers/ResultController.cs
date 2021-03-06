using System.Collections.Generic;
using eVoting.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace eVoting.Result.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly ILogger<ResultController> _logger;
        private readonly IVoteRepository _voteRepository;

        public ResultController(
            ILogger<ResultController> logger,
            IVoteRepository voteRepository)
        {
            _logger = logger;
            _voteRepository = voteRepository;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> Get()
        {
            return _voteRepository.GetResult().Select(v => new KeyValuePair<string, int>(v.Key.ToString(), v.Value));
        }
    }
}
