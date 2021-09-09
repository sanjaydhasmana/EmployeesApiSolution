using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Models.Employees
{
    public class PostEmployeeRequest : IValidatableObject
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(3)]
        public string Department { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(FirstName.ToLower() == "darth" && LastName.ToLower() == "vader")
            {
                yield return new ValidationResult("We have a strict No Sith Policy", new string[] {
                    nameof(FirstName), nameof(LastName)
                });
            }
        }
    }

}
