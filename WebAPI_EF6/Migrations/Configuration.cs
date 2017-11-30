namespace WebAPI_EF6.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAPI_EF6.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI_EF6.Models.WebAPI_EF6Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPI_EF6.Models.WebAPI_EF6Context context)
        {
            context.Instructors.AddOrUpdate(x => x.Id,
                new Instructor() { Id = 1, Name = "Charles Pearson" },
                new Instructor() { Id = 2, Name = "Daniel McGraw" },
                new Instructor() { Id = 3, Name = "John Stairs" },
                new Instructor() { Id = 4, Name = "Manikantha Chavali" },
                new Instructor() { Id = 5, Name = "Sairam Bommireddy" }
                );

            context.Courses.AddOrUpdate(x => x.Id,
                new Course()
                {
                    Id = 1,
                    Title = "Intro to Accounting",
                    Credits = 3,
                    InstructorId = 1,
                    Price = 400.00M,
                    Dept = "Business",
                    StartDate = new DateTime(2018, 1, 8, 19, 0, 0)
                },
                new Course()
                {
                    Id = 2,
                    Title = "Advanced Accounting",
                    Credits = 3,
                    InstructorId = 1,
                    Price = 800.00M,
                    Dept = "Business",
                    StartDate = new DateTime(2018, 8, 6, 19, 0, 0)
                },
                new Course()
                {
                    Id = 3,
                    Title = "Intro to English Literature",
                    Credits = 3,
                    InstructorId = 2,
                    Price = 400.00M,
                    Dept = "Education",
                    StartDate = new DateTime(2018, 1, 10, 19, 0, 0)
                },
                new Course()
                {
                    Id = 4,
                    Title = "Advanced English Literature",
                    Credits = 3,
                    InstructorId = 2,
                    Price = 800.00M,
                    Dept = "Education",
                    StartDate = new DateTime(2018, 8, 8, 19, 0, 0)
                },
                new Course()
                {
                    Id = 5,
                    Title = "Intro to Telecommunication",
                    Credits = 3,
                    InstructorId = 3,
                    Price = 500.00M,
                    Dept = "Information Technology",
                    StartDate = new DateTime(2018, 1, 11, 19, 0, 0)
                },
                new Course()
                {
                    Id = 6,
                    Title = "Advanced Telecommunication",
                    Credits = 3,
                    InstructorId = 3,
                    Price = 1000.00M,
                    Dept = "Information Technology",
                    StartDate = new DateTime(2018, 8, 9, 19, 0, 0)
                },
                new Course()
                {
                    Id = 7,
                    Title = "Intro to Computing",
                    Credits = 3,
                    InstructorId = 4,
                    Price = 500.00M,
                    Dept = "Computer Science",
                    StartDate = new DateTime(2018, 1, 8, 19, 0, 0)
                },
                new Course()
                {
                    Id = 8,
                    Title = "Advanced Computing",
                    Credits = 3,
                    InstructorId = 4,
                    Price = 1000.00M,
                    Dept = "Computer Science",
                    StartDate = new DateTime(2018, 8, 6, 19, 0, 0)
                },
                new Course()
                {
                    Id = 9,
                    Title = "Intro to Physical Science",
                    Credits = 3,
                    InstructorId = 5,
                    Price = 500.00M,
                    Dept = "Physical Science",
                    StartDate = new DateTime(2018, 1, 9, 19, 0, 0)
                },
                new Course()
                {
                    Id = 10,
                    Title = "Advanced Physics",
                    Credits = 3,
                    InstructorId = 5,
                    Price = 1000.00M,
                    Dept = "Physical Science",
                    StartDate = new DateTime(2018, 8, 7, 19, 0, 0)
                }
                );
        }
    }
}
