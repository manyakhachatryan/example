using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;

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


        public async Task<List<University>> GetListAsync(int? id = null, string? name = null, string? country = null, string? city = null, int? startIndex = 0, int? viewCount = 0)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("startIndex",startIndex),
                    new SPParam("viewCount",viewCount),
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

        public async Task<University> AddAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("Name",this.Name),
                    new SPParam("Country",this.Country),
                    new SPParam("City",this.City),
                };
                University item = await MySQLDataAccess<University>.ExecuteSPItemAsync("add_university", par);

                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Session.AddAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }


        public async Task<University> DeleteAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                };
                University item = await MySQLDataAccess<University>.ExecuteSPItemAsync("delete_university", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Session.DeleteAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }


        public async Task<University> EditAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                    new SPParam("Name",this.Name),
                    new SPParam("Country",this.Country),
                    new SPParam("City",this.City),
                };

                University item = await MySQLDataAccess<University>.ExecuteSPItemAsync("edit_university", par);

                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Session.EditAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }  
    }
}
