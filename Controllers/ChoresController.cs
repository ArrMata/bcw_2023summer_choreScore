namespace bcw_2023summer_choreScore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoresController : ControllerBase
    {

        private readonly ChoresService _choresService;
        private readonly Auth0Provider _auth0Provider;

        public ChoresController(ChoresService choresService, Auth0Provider auth0Provider)
        {
            _choresService = choresService;
            _auth0Provider = auth0Provider;
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
        public ActionResult<List<Chore>> GetChoreById(int choreId) 
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Chore>> CreateChore([FromBody] Chore choreData)
        {
            try 
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                choreData.CreatorId = userInfo.Id;
                Chore chore = _choresService.CreateChore(choreData);
                return Ok(chore);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{choreId}")]
        public ActionResult<string> DeleteChore(int choreId) 
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
        public ActionResult<Chore> EditChore([FromBody] Chore choreData, int choreId) 
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