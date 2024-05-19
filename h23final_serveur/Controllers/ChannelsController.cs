using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using h23final_serveur.Data;
using h23final_serveur.Models;
using Microsoft.AspNetCore.Authorization;
using h23final_serveur.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace h23final_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly h23final_serveurContext _context;
        readonly UserManager<User> UserManager;

        public ChannelsController(h23final_serveurContext context, UserManager<User> userManager)
        {
            _context = context;
            this.UserManager = userManager;
        }

        // GET: api/Channels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channel>>> GetChannel()
        {
            if (_context.Channel == null)
            {
                return NotFound();
            }
            return await _context.Channel.ToListAsync();
        }

        // ███ Ajoutez une action ici ███
        [HttpPost]
        [Authorize("moderator")]
        public async Task<ActionResult> PostChannel(PostMessageDTO postMessageDTO)
        {
            if (_context.Channel == null)
            {
                return Problem("Entity set 'h23final_serveurContext.Channel' is null.");
            }

            User? user = await _context.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
            {
                return NotFound(new { Message = "l'utilisateur n'existe pas." });
            }

            Channel channel = new Channel() { Id = 0, Name = postMessageDTO.Text };
            _context.Channel.Add(channel);
            await _context.SaveChangesAsync();

            PostMessageDTO returnpPostMessage = new PostMessageDTO() { ChannelId = channel.Id, Text = channel.Name };

            return Ok(returnpPostMessage);
        }
    }
}

