using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Core.Domain.Documents;
using Core.Domain.Management;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Employees;

public class Manager : Employee
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    [NotMapped]
    public PasswordHasher<object> hasher { get; set; }

    public PasswordVerificationResult SignIn(PasswordHasher<object> hasher, string input)
    {
        this.hasher = hasher;
        return this.hasher.VerifyHashedPassword(null, Password, input);
    }

    public Teacher CreateTeacher(Guid id, string Name)
    {
        var t = new Teacher()
        {
            Id = id,
            Name = Name
        };
        return t;
    }

    public Course CreateCourse(Guid id, string name)
    {
        var c = new Course()
        {
            Id = id,
            Name = name
        };
        return c;
    }

    public Schedule AssignCourseToTeacher(Teacher teacher, Course course, Classroom classroom, int duration)
    {
        var s = new Schedule()
        {
            Id = Guid.NewGuid(),
            TeacherId = teacher.Id,
            Teacher = teacher,
            CourseId = course.Id,
            Course = course,
            ClassroomId = classroom.Id,
            Classroom = classroom,
            Duration = TimeSpan.FromSeconds(duration)
        };
        return s;
    }

    public Document AssignDocumentToEmployee(Employee employee, IFormFile file)
    {
        Document d = new Document
        {
            Id = Guid.NewGuid(),
            OwnerId = employee.Id,
            MimeType = file.ContentType,
            Name = file.FileName
        };

        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            d.Content = ms.ToArray();
        }

        return d;
    }

    public Manager AssignNewManager(string name, string username, string password)
    {
        var m = new Manager()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Username = username,
            Password = hasher.HashPassword(null, password)
        };
        return m;
    }
}