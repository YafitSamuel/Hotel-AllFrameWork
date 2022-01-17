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
    public class OrderController : ApiController
    {
        static string connectionString = "Data Source=laptop-a88v89ut;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";

        HotelDataContextDataContext DataContext = new HotelDataContextDataContext(connectionString);

        // GET: api/Order
        public IHttpActionResult Get()
        {
           List<Order> OrdersList= DataContext.Orders.ToList();
            return Ok(new { OrdersList });
        }

        // GET: api/Order/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Order orders = DataContext.Orders.First((OrderItem) => OrderItem.Id == id);
                return Ok(new { orders });
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

        // POST: api/Order
        public IHttpActionResult Post([FromBody] Order orders)
        {
            try
            {
                DataContext.Orders.InsertOnSubmit(orders);
                DataContext.SubmitChanges();
                return Ok("success");
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

        // PUT: api/Order/5
        public IHttpActionResult Put(int id, [FromBody] Order order)
        {
            try
            {
                Order OrdersToUpdate = DataContext.Orders.Single(orderItem => orderItem.Id == id);
                OrdersToUpdate = order;
                DataContext.SubmitChanges();
                return Ok("success");

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

        // DELETE: api/Order/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Order order1 = DataContext.Orders.First(residentItem => residentItem.Id == id);
                DataContext.Orders.DeleteOnSubmit(order1);
                DataContext.SubmitChanges();
                return Ok("success");
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
