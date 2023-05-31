using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.AZ.EmpFunctionApp.Models
{
    [Table("tblEmployees")]
    public class Employee
    {
        
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EmployeeId { get; set; }
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }
        [Column("LAST_NAME")]
        public string? LastName { get; set; }
        [Column("SALARY")]
        public decimal? Salary { get; set; }
        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; } = true;
    }
}
