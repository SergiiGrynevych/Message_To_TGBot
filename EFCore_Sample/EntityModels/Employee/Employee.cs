using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Sample.EntityModels.Employee
{
    [Table("employee")]
    public class Employee
    {
        public int? id { get; set; }
        public string? firstName { get; set; }
        public string? secondName { get; set; }
        public string? birthday { get; set; }
    }
}
