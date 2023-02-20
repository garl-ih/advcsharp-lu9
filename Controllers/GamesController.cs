using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;
using System.ComponentModel;
using GroupProject.Database;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameContext _context;

        public GamesController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public List<Game> GetGames()
        {
            GamesDatabase gdb = new GamesDatabase();

            return gdb.GetGames();
        }

        

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public Resp PutGame(Game game)
        {
            Resp resp = new Resp();

            GamesDatabase gdb = new GamesDatabase();

            if (gdb.updateGame(game))
            {
                resp.status = "Okay";
                resp.message = "Game Updated in database";
            }
            else
            {
                resp.status = "Error";
                resp.message = "Something went wrong";
            }

            return resp;
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Resp PostGame(Game game)
        {

            Resp resp = new Resp();

            GamesDatabase gdb = new GamesDatabase();
            
            if (gdb.addGame(game))
            {
                resp.status = "Okay";
                resp.message = "Game added to database";
            }
            else
            {
                resp.status = "Error";
                resp.message = "Something went wrong";
            }
            return resp;
        }

        // DELETE: api/Games/5
        [HttpDelete]
        public Resp DeleteGame(int id)
        {
            Resp resp = new Resp();

            GamesDatabase gdb = new GamesDatabase();

            if (gdb.deleteGame(id))
            {
                resp.status = "Okay";
                resp.message = "Game removed from database";
            }
            else
            {
                resp.status = "Error";
                resp.message = "Something went wrong";
            }
            return resp;
        }

        
    }
}
