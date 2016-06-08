using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class CourseService
    {
        private readonly DataContext _context;

        public CourseService()
        {
            _context = new DataContext();
        }

        public Course Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public IEnumerable<CourseQuorum> AddQuorum(int id, IEnumerable<int> empKeys)
        {
            var quorums = empKeys.Select(p => new CourseQuorum { CourseId = id, EmployeeId = p });
            _context.CourseQuorums.AddRange(quorums);
            _context.SaveChanges();
            return quorums;
        }

        public void Update(Course course)
        {
            _context.Courses.AddOrUpdate(course);
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public int GetActualQuorum(int courseId)
        {
            return _context.CourseQuorums.Count(p => p.CourseId == courseId);
        }

        public void Update(CourseQuorum quorum)
        {
            _context.CourseQuorums.AddOrUpdate(quorum);
            quorum.Course.Capacity = _context.CourseQuorums.Count(p => p.CourseId == quorum.CourseId);
            quorum.Course.Capacity++;
            _context.Courses.AddOrUpdate(quorum.Course);
            _context.SaveChanges();
        }
        
    }
}
