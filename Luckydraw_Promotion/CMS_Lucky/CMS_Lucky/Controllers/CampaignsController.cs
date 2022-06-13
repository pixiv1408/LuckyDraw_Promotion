using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS_Lucky.Data;
using Datactx.Models;

namespace CMS_Lucky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly CMS_LuckyContext _context;

        public CampaignsController(CMS_LuckyContext context)
        {
            _context = context;
        }

        // GET: api/Campaigns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetCampaign()
        {
          if (_context.Campaign == null)
          {
              return NotFound();
          }
            return await _context.Campaign.ToListAsync();
        }

        // GET: api/Campaigns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campaign>> GetCampaign(int id)
        {
          if (_context.Campaign == null)
          {
              return NotFound();
          }
            var campaign = await _context.Campaign.FindAsync(id);

            if (campaign == null)
            {
                return NotFound();
            }

            return campaign;
        }

        // PUT: api/Campaigns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaign(int id, Campaign campaign)
        {
            if (id != campaign.camId)
            {
                return BadRequest();
            }

            _context.Entry(campaign).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(id))
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

        // POST: api/Campaigns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campaign>> PostCampaign(Campaign campaign)
        {
          if (_context.Campaign == null)
          {
              return Problem("Entity set 'CMS_LuckyContext.Campaign'  is null.");
          }
            _context.Campaign.Add(campaign);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampaign", new { id = campaign.camId }, campaign);
        }

        // DELETE: api/Campaigns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaign(int id)
        {
            if (_context.Campaign == null)
            {
                return NotFound();
            }
            var campaign = await _context.Campaign.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            _context.Campaign.Remove(campaign);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampaignExists(int id)
        {
            return (_context.Campaign?.Any(e => e.camId == id)).GetValueOrDefault();
        }
    }
}
