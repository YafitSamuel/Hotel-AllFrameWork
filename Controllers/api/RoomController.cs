using Hotel_AllFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_AllFrameWork.Controllers.api
{
    public class RoomController : ApiController
    {
        string connectionString = "Data Source=laptop-a88v89ut;Initial Catalog=HotelDB;Integrated Security=True";

        List<Room> roomlist = new List<Room>();
        // GET: api/Room
        public IHttpActionResult Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Rooms";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader alllData = command.ExecuteReader();
                    if (alllData.HasRows)
                    {
                        while (alllData.Read())
                        {
                            roomlist.Add(new Room(alllData.GetInt32(0), alllData.GetInt32(1), alllData.GetString(2), alllData.GetInt32(3), alllData.GetBoolean(4)));
                        }
                        connection.Close();
                        return Ok(new { roomlist });
                    }
                    return Ok("no have rows");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM Rooms WHERE Rooms.Id={id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader room = command.ExecuteReader();
                    if (room.HasRows)
                    {
                        while (room.Read())
                        {
                            Room OneRoom = new Room(room.GetInt32(0), room.GetInt32(1), room.GetString(2), room.GetInt32(3), room.GetBoolean(4));
                            connection.Close();
                            return Ok(new { OneRoom });
                        }
                    }
                    return Ok("no exsit");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Room
        public IHttpActionResult Post([FromBody] Room Room)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Room(roomNumber,roomType,price,Isavailable)
                       VALUES({Room.roomNumber},'{Room.roomType}',{Room.price},'{Room.Isavailable}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsEffected = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok("add");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Room/5
        public IHttpActionResult Put(int id, [FromBody] Room ROOM)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"UPDATE Rooms
                                SET roomNumber = {ROOM.roomNumber}, roomType='{ROOM.roomType}', price={ROOM.price}, Isavailable='{ROOM.Isavailable}'
                                 WHERE Room.id={id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsEffected = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Eddit");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Room/5

        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE  FROM Rooms  WHERE Id={id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok("removed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
