using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusniessLayer
{
    public class Employee_Crud : IEmployee_Crud
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public interface IEmployee_Crud
    {
        int ID { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime? DateOfBirth { get; set; }
    }
}
