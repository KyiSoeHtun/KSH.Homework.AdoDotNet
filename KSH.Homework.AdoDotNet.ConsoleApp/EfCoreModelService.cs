using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSH.Homework.AdoDotNet.ConsoleApp
{
    public class EfCoreModelService
    { public void read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Students.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine($"{item.ClientID} - {item.ClientName}");
            };
        }
        public void create()
        {
            AppDbContext db = new AppDbContext();
            StudentDto student = new StudentDto()
            {
                ClientName = "Mg Mg",
                FatherName = "U Aung",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 1, 1), // 1900-01-01 12:00:00 AM
                ClientType = "001",
                PhoneNo = "09122457387",
                Address = "Yangon"
                //DeleteFlag = false,
            };
            db.Students.Add(student);
            int result = db.SaveChanges();
        }
        public void update()
        {
            AppDbContext db = new AppDbContext();
            StudentDto? editStudent = db.Students.Where(x => x.ClientID == 8).FirstOrDefault();
            if (editStudent is not null)
            {
                editStudent.FatherName = "Father Name";
                db.SaveChanges();
            }
        }
        public void delete()
        {
            AppDbContext db = new AppDbContext();
            StudentDto? UpdateStatus = db.Students.Where(x => x.ClientID == 2).FirstOrDefault();
            if (UpdateStatus is not null)
            {
                UpdateStatus.DeleteFlag = true;
                db.SaveChanges();
            }
        }
    }
}
