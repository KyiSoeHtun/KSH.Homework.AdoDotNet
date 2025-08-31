using Dapper;
using KSH.Homework.AdoDotNet.ConsoleApp;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;

AppDbContext db = new AppDbContext();
List<StudentDto> lst = db.Students.ToList();
foreach (var item in lst)
{
    //string a = $"dsnfasid{item.StudentNo}fnsaidfasfnsanf";
    Console.WriteLine($"{item.ClientID} - {item.ClientName}");
}

StudentDto student = new StudentDto()
{
    ClientName = "Mg Mg",
    FatherName = "U Aung",
    Gender = "Male",
    DateOfBirth = new DateTime(2000, 1, 1), // 1900-01-01 12:00:00 AM
    ClientType = "001",
    PhoneNo  = "09122457387",
    Address = "Yangon"
    //DeleteFlag = false,
};
db.Students.Add(student);
int result = db.SaveChanges();

StudentDto? editStudent = db.Students.Where(x => x.ClientID == 8).FirstOrDefault();
if (editStudent is not null)
{
    editStudent.FatherName = "Father Name";
    db.SaveChanges();
}

StudentDto? removeStudent = db.Students.Where(x => x.ClientID == 9).FirstOrDefault();
if (removeStudent is not null)
{
    db.Students.Remove(removeStudent);
    db.SaveChanges();
}

Console.ReadLine();