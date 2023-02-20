using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;
using GroupProject.Database;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchesController : ControllerBase
    {
        // GET: api/Merches
        [HttpGet]
        public List<Merch> GetMerches()
        {
            MerchDatabase mdb = new MerchDatabase();

            return mdb.GetMerches();
        }



        // PUT: api/Merches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public Resp PutMerch(Merch merch)
        {
            Resp resp = new Resp();

            MerchDatabase mdb = new MerchDatabase();

            if (mdb.updateMerch(merch))
            {
                resp.status = "Okay";
                resp.message = "Merch Updated in database";
            }
            else
            {
                resp.status = "Error";
                resp.message = "Something went wrong";
            }

            return resp;
        }

        // POST: api/Merches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Resp PostMerch(Merch merch)
        {

            Resp resp = new Resp();

            MerchDatabase mdb = new MerchDatabase();

            if (mdb.addMerch(merch))
            {
                resp.status = "Okay";
                resp.message = "Merch added to database";
            }
            else
            {
                resp.status = "Error";
                resp.message = "Something went wrong";
            }
            return resp;
        }

        // DELETE: api/Merches/5
        [HttpDelete]
        public Resp DeleteMerch(int id)
        {
            Resp resp = new Resp();

            MerchDatabase mdb = new MerchDatabase();

            if (mdb.deleteMerch(id))
            {
                resp.status = "Okay";
                resp.message = "Merch removed from database";
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
