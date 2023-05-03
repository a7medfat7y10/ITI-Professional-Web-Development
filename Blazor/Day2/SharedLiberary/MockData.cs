using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLiberary
{
    public static class MockData
    {
       public static List<Track> tracks = new List<Track>
{
    new Track { ID = 1, Name = "Web Development", Description = "Learn web development" },
    new Track { ID = 2, Name = "Mobile Development", Description = "Learn mobile app development" },
    new Track { ID = 3, Name = "Data Science", Description = "Learn data science and machine learning" },
    new Track { ID = 4, Name = "Cloud Computing", Description = "Learn cloud computing and server management" },
    new Track { ID = 5, Name = "Cybersecurity", Description = "Learn cybersecurity and ethical hacking" }
};

        public static List<Trainee> trainees = new List<Trainee>
{
    new Trainee { ID = 1, Name = "John Doe", Email = "john.doe@example.com", MobileNo = "1234567890", Birthdate = new DateTime(1995, 1, 1), IsGraduated = true, Sex = Gender.Male, trackId = 1 },
    new Trainee { ID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", MobileNo = "45678901", Birthdate = new DateTime(1998, 5, 15), IsGraduated = false, Sex = Gender.Female, trackId = 2 },
    new Trainee { ID = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com", MobileNo = "36789012", Birthdate = new DateTime(2000, 9, 30), IsGraduated = false, Sex = Gender.Male, trackId = 3 },
    new Trainee { ID = 4, Name = "Mary Davis", Email = "mary.davis@example.com", MobileNo = "47890123", Birthdate = new DateTime(1997, 12, 25), IsGraduated = true, Sex = Gender.Female, trackId = 4 },
    new Trainee { ID = 5, Name = "Tom Wilson", Email = "tom.wilson@example.com", MobileNo = "678901234", Birthdate = new DateTime(1999, 3, 10), IsGraduated = false, Sex = Gender.Male, trackId = 5 }
};

    }
}
