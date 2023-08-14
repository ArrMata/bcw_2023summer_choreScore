namespace bcw_2023summer_choreScore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoresController : ControllerBase
    {

        private readonly ChoresService _choresService;

        public ChoresController(ChoresService choresService)
        {
            _choresService = choresService;
        }

        [HttpGet]
        public ActionResult<List<Chore>> GetChores() 
        {
            try
            {
                List<Chore> chores = _choresService.GetChores();
                return Ok(chores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{choreId}")]
        public ActionResult<List<Chore>> GetChoreById(Guid choreId) 
        {
            try
            {
                Chore chore = _choresService.GetChoreById(choreId);
                return Ok(chore);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
        {
            try 
            {
                Chore chore = _choresService.CreateChore(choreData);
                return Ok(chore);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{choreId}")]
        public ActionResult<string> DeleteChore(Guid choreId) 
        {
            try
            {
                _choresService.DeleteChore(choreId);
                return "Chore Deleted!";
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{choreId}")]
        public ActionResult<Chore> EditChore([FromBody] Chore choreData, Guid choreId) 
        {
            try
            {
                Chore chore = _choresService.EditChore(choreData, choreId);
                return chore;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}