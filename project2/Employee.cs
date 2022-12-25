using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    public class Employee
    {
        [Key]
       //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpID { get; set; }
       
        public string FName { get; set; }
        
        public string LName { get; set; }
       
        public int Age { get; set; }
        
        public string Address { get; set; }
    }
}
