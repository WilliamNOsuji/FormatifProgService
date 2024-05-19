using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using h23final_serveur.Data;
using h23final_serveur.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using h23final_serveur.DTOs;

namespace h23final_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReactionsController : ControllerBase
    {
        private readonly h23final_serveurContext _context;
        readonly UserManager<User> UserManager;

        public ReactionsController(h23final_serveurContext context, UserManager<User> userManager)
        {
            _context = context;
            this.UserManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReactionPicture(int id)
        {
            if(_context.Reaction == null)
            {
                return Problem("Entity set 'h23final_serveurContext.Reaction' is null.");
            }

            Reaction? reaction = await _context.Reaction.FindAsync(id);
            if(reaction == null)
            {
                return NotFound(new { Message = "Cette réaction n'existe pas." });
            }

            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/reactions/" + reaction.FileName);
            return File(bytes, reaction.MimeType);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> ToggleReaction(int id)
        {
            if (_context.Reaction == null || _context.Users == null)
            {
                return Problem("Entity set 'h23final_serveurContext.Reaction' is null.");
            }

            Reaction? reaction = await _context.Reaction
                .Include(r => r.Users)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reaction == null)
            {
                return NotFound("Réaction non trouvée !");
            }

            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
            {
                return NotFound(new { Message = "L'utilisateur n'existe pas." });
            }

            // Check if the user already has this reaction
            if (reaction.Users.Contains(user) && reaction.Users.Count == 1)
            {
                // Remove the user from the reaction
                reaction.Users.Remove(user);
                reaction.Quantity = 0;
                _context.Entry(reaction).State = EntityState.Modified;
                return Ok(null);
            }
            
            if(reaction.Users.Contains(user) && reaction.Users.Count > 1)
            {
                reaction.Users.Remove(user);
                reaction.Quantity--;
                _context.Entry(reaction).State = EntityState.Modified;
                return Ok(reaction);
            }
            
            reaction.Users.Add(user);
            reaction.Quantity++;

            await _context.SaveChangesAsync();

            return Ok(reaction);
        }


        [HttpPost("{messageId}")]
        [Authorize]
        public async Task<ActionResult<Reaction>> PostReaction(int messageId)
        {
            if (_context.Reaction == null || _context.Message == null)
            {
                return Problem("Entity set 'h23final_serveurContext.Reaction'  is null.");
            }

            User? user = await _context.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Message? message = await _context.Message.FindAsync(messageId);

            if(user == null || message == null)
            {
                return NotFound(new { Message = "Le message n'existe pas." });
            }

            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("imageReaction");
                if(file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());

                    Reaction reaction = new Reaction()
                    {
                        Id = 0,
                        Quantity = 1,
                        MimeType = file.ContentType,
                        FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName),
                        Message = message,
                        Users = new List<User>() { user }
                    };

                    image.Mutate(i => i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Height = 30 }
                    }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/reactions/" + reaction.FileName);

                    _context.Reaction.Add(reaction);
                    await _context.SaveChangesAsync();
                    return Ok(reaction);
                }
                else
                {
                    return NotFound(new { Message = "Aucune image fournie." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
