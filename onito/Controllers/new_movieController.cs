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
    public class new_movieController : ApiController
    {
        public string Post(Movies m)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"
               insert into dbo.movies
                (   tconst,
                    titleType,
                    primaryTitle,
                    runtimeMinutes,
                    genres)
                    Values
                    (
                     '" + m.tconst + @"',
                     '" + m.titleType + @"',
                     '" + m.primaryTitle + @"',
                     '" + m.runtimeMinutes + @"',
                     '" + m.genres + @"'
                    )
                ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["onitoAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return "Failed to Add";
            }
        }
    }
}
