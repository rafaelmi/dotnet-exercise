using Exercise.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Exercise.Data.Repositories
{
    public class CoursesRepository : Repository, ICoursesRepository
    {
        public CoursesRepository(IConfiguration configuration) : base (configuration)
        {
        }

        public async Task<IEnumerable<Course>> GetMany (int size, int offset)
        {
            List<Course> collection = new List<Course>();
            DataSet dataSet = await GetMany("Courses", size, offset);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                collection.Add(new Course
                {
                    CourseId = (int)row["course_id"],
                    Title = (string)row["title"],
                    Description = (string)row["description"]
                });
            }

            return collection;
        }

        public async Task<int> Create (Course course)
        {
            string query = "INSERT INTO Courses (Title, Description) " +
                           $"VALUES ('{course.Title}', '{course.Description}')";
            return await ExecuteNonQuery(query);
        }

        public async Task<int> Update (Course course)
        {
            string query = "UPDATE Courses SET " +
                                $"title = '{course.Title}', " +
                                $"description = '{course.Description}' " +
                                $"WHERE course_id = {course.CourseId}";
            return await ExecuteNonQuery(query);
        }

        public async Task<int> Delete (int courseId)
        {
            string query = $"DELETE FROM Courses WHERE course_id = {courseId}";
            return await ExecuteNonQuery(query);
        }
    }
}
