using BusinessLayer.Entities;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;


namespace BusinessLayer.Entities
{
    public class Student : IErrMsg
    {
        public int? ID { get; set; }

        [MinLength(3, ErrorMessage = "The first name should be minimum 3 characters long")]
        [MaxLength(15, ErrorMessage = "The first name should be maximum 15 characters long")]
        public string? FirstName { get; set; }


        [MaxLength(20, ErrorMessage = "The last name should be maximum 20 characters long")]
        [MinLength(3, ErrorMessage = "The last name should be minimum 3 characters long")]
        public string? LastName { get; set; }


        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int? Age { get; set; }


        [Range(0, 20, ErrorMessage = "Grade must be between 0 and 20.")]
        public int? Grade { get; set; }

      
        public EducationT? EducationType{ get; set; }
        public int? UniversityID { get; set; }
        string IErrMsg.ErrMsg { get; set; }
        public uint? RowCount { get; set; }
        public long? StudentCount { get; set; }
        public decimal? AverageAge { get; set; }
        public decimal? AverageGrade { get; set; }
        public string? Name { get; set; }



        public Student() { }
        public Student(int? id = null, string? firstName = null, string? lastName = null, int? uID = null, string? name = null,
                        int? age = null, int? grade = null, long? studentCount = null, long? aAge = null, long? averageGrade = null, EducationT? educationType = null)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UniversityID = uID;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
            this.StudentCount = studentCount;
            this.AverageAge = aAge;
            this.AverageGrade = averageGrade;
            this.EducationType = educationType;
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
                    new SPParam("Age",this.Age),
                    new SPParam("Grade",this.Grade),
                    new SPParam("EducationType", EducationType)
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


        public async Task<List<Student>> GetListAsync(int? id = 0, string? firstName = null, string? lastName = null,
                    int? uID = 0, int? age = null, int? grade = null, int? startIndex = 0, int? viewCount = 0, EducationT? educationType =null)


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
                    new SPParam("UniversityID",uID ),
                    new SPParam("Age",age),
                    new SPParam("Grade",grade),
                    new SPParam("EducationType",educationType)
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
                    new SPParam("Age",this.Age),
                    new SPParam("Grade",this.Grade),
                    new SPParam("EducationType",this.EducationType),
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


        public async Task<Student> GetTotal()
        {
            try
            {


                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("get_total_student", null);

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
    public enum EducationT
    {
        Available = 0,
        Remotely = 1
    }
}

