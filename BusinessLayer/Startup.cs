using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DBTools;
using Microsoft.Extensions.Configuration;
namespace BusinessLayer
{
    public class Startup
    {
        public IConfiguration Config { get; }
        public Startup(IConfiguration config)
        {
            Config = config;
            DBConfig.ConnectionString = Config.GetSection("DBConfig").GetValue<string>("ConnectionString");

        }

    }
}