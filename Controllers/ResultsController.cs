using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sampleApp.Models;
using sampleApp.Repositories;

namespace sampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly ResultsRepository resultsRepository;

        public ResultsController(){
            resultsRepository = new ResultsRepository();
        }

    [HttpGet]
    public IEnumerable<Result> GetResults(){
        var results = resultsRepository.GetResults();
        return results;
    }
    }
}