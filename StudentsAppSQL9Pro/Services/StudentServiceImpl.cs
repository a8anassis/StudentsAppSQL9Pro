using AutoMapper;
using StudentsAppSQL9Pro.DAO;
using StudentsAppSQL9Pro.DTO;
using StudentsAppSQL9Pro.Exceptions;
using StudentsAppSQL9Pro.Models;
using System.Transactions;

namespace StudentsAppSQL9Pro.Services
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO _studentDAO;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentServiceImpl> _logger;

        public StudentServiceImpl(IStudentDAO studentDAO, IMapper mapper, ILogger<StudentServiceImpl> logger)
        {
            _studentDAO = studentDAO;
            _mapper = mapper;
            _logger = logger;
        }

        public StudentReadOnlyDTO? InsertStudent(StudentReadOnlyDTO studentInsertDTO)
        {
            StudentReadOnlyDTO studentReadOnlyDTO;

            try
            {
                using TransactionScope scope = new TransactionScope();
                Student student = _mapper.Map<Student>(studentInsertDTO);
                Student? insertedStudent = _studentDAO.Insert(student);
                studentReadOnlyDTO = _mapper.Map<StudentReadOnlyDTO>(student);
                _logger.LogInformation("Student {Firstname} {Lastname} inserted successfully.", 
                    studentReadOnlyDTO.Firstname, studentReadOnlyDTO.Lastname);
                scope.Complete();
                return studentReadOnlyDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Student insertion failed for {Firstname} {Lastname}. {Errormessage}",
                    studentInsertDTO.Firstname, studentInsertDTO.Lastname, ex.Message);
                throw;
            }
        }

        public StudentReadOnlyDTO GetStudent(int id)
        {
            StudentReadOnlyDTO studentReadOnlyDTO;
            Student student;

            try
            {
                student = _studentDAO.GetById(id) ?? 
                    throw new StudentNotFoundException($"Student with id {id} not found.");
                studentReadOnlyDTO = _mapper.Map<StudentReadOnlyDTO>(student);
                _logger.LogInformation("Student with id={Id} fetced successfully.", id);
                return studentReadOnlyDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while fetching student with id={Id} {ErrorMessage}",
                    id, ex.Message);
                throw;
            }
        }

        public void UpdateStudent(StudentUpdateDTO studentUpdateDTO)
        {
            try
            {
                using TransactionScope scope = new TransactionScope();

                if (_studentDAO.GetById(studentUpdateDTO.Id) is null)
                {
                    throw new StudentNotFoundException($"Student with id {studentUpdateDTO.Id} not found.");
                }

                Student student = _mapper.Map<Student>(studentUpdateDTO);
                _studentDAO.Update(student);
                _logger.LogInformation("Student {Firstname} {Lastname} updated successfully.",
                    studentUpdateDTO.Firstname, studentUpdateDTO.Lastname);
                scope.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError("Student update failed for {Firstname} {Lastname}. {Errormessage}",
                    studentUpdateDTO.Firstname, studentUpdateDTO.Lastname, ex.Message);
                throw;
            }
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentReadOnlyDTO> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        

        

        
    }
}
