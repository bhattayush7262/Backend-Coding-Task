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
    public class top_rated_moviesController : ApiController
    {
         public HttpResponseMessage Gett()
        {
            DataTable dt = new DataTable();
            string query = @"
               select m.tconst
               ,m.primaryTitle
               ,m.runtimeMinutes
               ,m.genres
               ,r.averageRating
               FROM movies m 
               inner join ratings r
               on m.tconst = r.tconst
               where r.averageRating > 6.0 
               order by r.averageRating ; 
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
