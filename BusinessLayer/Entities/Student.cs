using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;


namespace BusinessLayer.Entities
{
    public class Student : IErrMsg
    {
        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? UniversityID { get; set; }
        string IErrMsg.ErrMsg { get; set; }
        public uint? RowCount { get; set; }

        public string? Name { get; set; }

        public Student() { }
        public Student(int? id = null, string? firstName = null, string? lastName = null, int? uID = null, string? name = null)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UniversityID = uID;
            this.Name =name; 
        }


        public async Task<Student> AddAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("UniversityID",this.UniversityID),
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("add_student", par);

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


        public async Task<List<Student>> GetListAsync(int? id = 0, string? firstName = null, string? lastName = null, int? uID = 0, int? startIndex = 0, int? viewCount = 0)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("startIndex",startIndex),
                    new SPParam("viewCount",viewCount),
                    new SPParam("ID",id),
                    new SPParam("FirstName",firstName),
                    new SPParam("LastName",lastName ),
                    new SPParam("UniversityID",uID )
                };

      
                List<Student> list = new List<Student>();
                (list, RowCount) = await MySQLDataAccess<Student>.ExecuteSPListByPagingAsync("get_student", par);
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

        public async Task<Student> DeleteAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("delete_student", par);
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

        public async Task<Student> EditAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("ID",this.ID),
                    new SPParam("FirstName",this.FirstName),
                    new SPParam("LastName",this.LastName),
                    new SPParam("UniversityID",this.UniversityID),
                };
       
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("edit_student", par);

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
