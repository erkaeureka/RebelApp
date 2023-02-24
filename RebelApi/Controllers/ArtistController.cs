using Api.Managers;
using Api.Models;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistManager _artistManager;

        public ArtistController(IArtistManager artistManager)
        {
            _artistManager = artistManager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<ArtistViewModel>> Get()
        {
            return await _artistManager.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Post Artist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ArtistViewModel> Post(ArtistInputModel model)
        {
            return await _artistManager.CreateAsync(model);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(long id, ArtistInputModel model)
        {
            await _artistManager.Update(id,model);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _artistManager.DeleteArtist(id);

        }
    }
}
