using System.ComponentModel.DataAnnotations;

namespace StudentApp.Data.Models
{
    public class School : BaseClass
    {        
        public string Name { get; set; }
        public string Address { get; set; }
        public int YearEstablished { get; set; }
    }
}
