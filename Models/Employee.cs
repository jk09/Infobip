using Microsoft.EntityFrameworkCore;

namespace Infobip.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDriver { get; set; }
    }
}
