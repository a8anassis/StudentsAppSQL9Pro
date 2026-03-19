using Microsoft.Data.SqlClient;
using StudentsAppSQL9Pro.Core;
using StudentsAppSQL9Pro.Models;

namespace StudentsAppSQL9Pro.DAO
{

    public class StudentDAOImpl : IStudentDAO
    {
        private readonly DBHelper _db;

        public StudentDAOImpl(DBHelper db)
        {
            _db = db;
        }

        public Student? Insert(Student student)
        {
            int insertedId = 0;
            Student? studentToReturn = null;

            string sql = "INSERT INTO Students (Firstname, Lastname) VALUES (@firstname, @lastname); " +
                "SELECT SCOPE_IDENTITY();";

            using SqlConnection connection = _db.GetConnection();
            connection.Open();

            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@firstname", student.Firstname);
            command.Parameters.AddWithValue("@lastname", student.Lastname);

            var insertedObject = command.ExecuteScalar();
            if (insertedObject != null)
            {
                if (!int.TryParse(insertedObject.ToString(), out insertedId))
                {
                    throw new Exception("Error in inserted id");
                }
            }

            string sql2 = "SELECT * FROM Students WHERE Id = @studentId";
            using SqlCommand command2 = new(sql2, connection);
            command2.Parameters.AddWithValue("@studentId", insertedId);

            using SqlDataReader reader = command2.ExecuteReader();

            if (reader.Read())
            {
                studentToReturn = new Student()
                {
                    Id = (int)reader["Id"],
                    Firstname = reader["Firstname"] as string ?? "",
                    Lastname = reader["Lastname"] as string ?? ""
                };
            }

            return studentToReturn;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student? GetById(int id)
        {
            throw new NotImplementedException();
        }

        

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
