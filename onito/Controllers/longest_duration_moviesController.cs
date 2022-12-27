using onito.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace onito.Controllers
{
    public class longest_duration_moviesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            string query = @"
               select Top(10)tconst
               ,primaryTitle
               ,runtimeMinutes
               ,genres
               FROM movies
               order by runtimeMinutes Desc ; 
                ";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["onitoAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }



        
       
    }
}

