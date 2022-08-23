using System.ComponentModel.DataAnnotations;
namespace universityApi.Models.DataModels

{
    public class Student: BaseEntity
    {
        public String Name { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
