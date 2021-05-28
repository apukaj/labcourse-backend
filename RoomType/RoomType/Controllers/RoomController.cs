using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using RoomType.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace RoomType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public RoomController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {

            string query = @"select RoomId, RoomName, StatusOfRoom,
                            convert(varchar(10),DateOfJoining,120) as DateOfJoining,
                            convert(varchar(10),DateOfExit,120) as DateOfExit, Price
                             from Room1";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Room app)
        {
            string query = @"
                    insert into Room1
                     (RoomName,StatusOfRoom,DateOfJoining,DateOfExit,Price)
                     values 
                    (
                      '" + app.RoomName + @"'
                      ,'" + app.StatusOfRoom + @"'
                      ,'" + app.DateOfJoining + @"'
                      ,'" + app.DateOfExit + @"'
                      ,'" + app.Price +@"'
                      )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Room app)
        {
            string query = @"
                    update Room1 set 
                    RoomName = '" + app.RoomName + @"'
                    ,StatusOfRoom = '" + app.StatusOfRoom + @"'
                    ,DateOfJoining = '" + app.DateOfJoining + @"'
                    ,DateOfExit = '" + app.DateOfExit + @"'
                    ,Price = '" + app.Price + @"'
                    where RoomId = " + app.RoomId + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from Room1
                    where RoomId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
