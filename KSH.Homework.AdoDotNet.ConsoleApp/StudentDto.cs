using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSH.Homework.AdoDotNet.ConsoleApp
{
    [Table("ClientRegistration")]
    public class StudentDto
    {
        [Key]
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ClientType { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
