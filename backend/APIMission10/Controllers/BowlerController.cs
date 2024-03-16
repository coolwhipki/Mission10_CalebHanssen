using APIMission10.Bowling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMission10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        public BowlerController(IBowlerRepository temp) {
            _bowlerRepository = temp;
        }

        [HttpGet]
     //   public ActionResult<IEnumerable<object>> GetBowlerTeams()
    //        var bowlerTeams = _bowlerRepository.GetBowlerTeams();
    //        return Ok(bowlerTeams);
   //     }

        public IEnumerable<object> Get() 
        { var bowlerTeams = _bowlerRepository.GetBowlerTeams();
            return bowlerTeams;
        }

    }
}
