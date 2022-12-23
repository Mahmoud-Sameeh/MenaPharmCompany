using Data.Repoitories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenaPharmCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IGenericRepository<Asset> _context;

        public AssetsController(IGenericRepository<Asset> context)
        {
            _context = context;
        }

        // GET: api/Assets
        [HttpGet]
        public  ActionResult<IEnumerable<Asset>> GetAsset()
        {
            return _context.GetAll().ToList();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public ActionResult<Asset> GetAsset(int id)
        {
            var asset = _context.FindById(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/Assets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            _context.Update(asset);

            try
            {
                _context.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("")]
        public ActionResult<Asset> PostAsset(Asset asset)
        {
            _context.Insert(asset);
            _context.Save();

            return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            var asset = _context.FindById(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Delete(asset.Id);
            _context.Save();

            return NoContent();
        }

        private bool AssetExists(int id)
        {
            return _context.Any(e => e.Id == id);
        }
    }
}
