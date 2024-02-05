using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class University : IErrMsg
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        string IErrMsg.ErrMsg { get; set; }
        public uint? RowCount { get; set; }
        public University() { }
        public University(int? id = null, string? name = null, string? country = null, string? city = null)
        {
            this.ID = id;
            this.Name = name;
            this.Country = country;
            this.City = city;
        }


        public async Task<List<University>> GetListAsync(int? id = null, string? name = null, string? country = null, string? city = null)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",id),
                    new SPParam("Name",name),
                    new SPParam("Country",country),
                    new SPParam("City",city)
                };


                List<University> list = new List<University>();

                (list, RowCount) = await MySQLDataAccess<University>.ExecuteSPListByPagingAsync("get_university", par);
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Game.GetListAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }
    }


    
}
