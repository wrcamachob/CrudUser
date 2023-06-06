using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public abstract class Repository
    {
        private readonly string connection;
        private readonly IConfiguration _configuration;
        
        public Repository()
        {
            //connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            connection = ConfigurationManager.AppSettings["DefaultConnection"].ToString();

            //_configuration = config;
            //connection = _configuration.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connection);
        }
    }
}
