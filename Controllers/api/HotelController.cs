using Hotel_AllFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hotel_AllFrameWork.Controllers.api
{
    public class HotelController : ApiController
    {

        HotelDataContext DBC = new HotelDataContext();
        // GET: api/Hotel
        public IHttpActionResult Get()
        {
            try
            {
                List<Claient> AllClaients = DBC.Claients.ToList();

                return Ok(new { AllClaients });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Hotel/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Claient claient = await DBC.Claients.FindAsync(id);

                return Ok(new { claient });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Hotel
        public async Task<IHttpActionResult> post([FromBody] Claient claient)
        {
            DBC.Claients.Add(claient);
            await DBC.SaveChangesAsync();
            return Ok("added");
        }

        // PUT: api/Hotel/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Claient claient)
        {
            try
            {
                Claient UpDateClaient = await DBC.Claients.FindAsync(id);
                UpDateClaient.FirstName = claient.LastName;
                UpDateClaient.LastName = claient.FirstName;
                UpDateClaient.YearOfBrith = claient.YearOfBrith;
                UpDateClaient.EntryDate = claient.EntryDate;
                UpDateClaient.Gender = claient.Gender;
                await DBC.SaveChangesAsync();
                return Ok("eddit");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Hotel/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Claient claient = await DBC.Claients.FindAsync(id);
                DBC.Claients.Remove(claient);
                await DBC.SaveChangesAsync();
                return Ok("Removed");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
