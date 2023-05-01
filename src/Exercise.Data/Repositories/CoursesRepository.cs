using Exercise.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Exercise.Domain.Models;
using System.Drawing;

namespace Exercise.Data.Repositories
{
    public class CoursesRepository : Repository, ICoursesRepository
    {
        private readonly TableProperties _tableProperties;

        public CoursesRepository(IConfiguration configuration) : base (configuration)
        {
            _tableProperties = new TableProperties 
            {
                Name = "Courses",
                IdColumnName = "course_id",
            };
        }

        public async Task<CourseDTO> Get(int courseId)
        {
            DataRow dataRow = await Get(_tableProperties, courseId);
            return CreateDTO(dataRow);
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            DataSet dataSet = await GetAll(_tableProperties);
            return CreateDTOList(dataSet);
        }

        public async Task<IEnumerable<CourseDTO>> GetMany (int size, int offset)
        {
            DataSet dataSet = await GetMany(_tableProperties, size, offset);
            return CreateDTOList(dataSet);
        }

        public async Task<int> Create (CourseDTO course)
        {
            string query = "INSERT INTO Courses (Title, Description) " +
                           $"VALUES ('{course.Title}', '{course.Description}')";
            return await ExecuteNonQuery(query);
        }

        public async Task<int> Update (int courseId, CourseDTO course)
        {
            string query = "UPDATE Courses SET " +
                                $"title = '{course.Title}', " +
                                $"description = '{course.Description}' " +
                                $"WHERE course_id = {courseId}";
            return await ExecuteNonQuery(query);
        }

        public async Task<int> Delete (int courseId)
        {
            string query = $"DELETE FROM Courses WHERE course_id = {courseId}";
            return await ExecuteNonQuery(query);
        }

        private IEnumerable<CourseDTO> CreateDTOList (DataSet dataSet)
        {
            List<CourseDTO> collection = new List<CourseDTO>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                collection.Add(CreateDTO(row));
            }

            return collection;
        }

        private CourseDTO CreateDTO(DataRow row)
        {
            if (row != null) return new CourseDTO
            {
                CourseId = (int)row["course_id"],
                Title = (string)row["title"],
                Description = (string)row["description"]
            };
            else return null;
        }
    }
}
