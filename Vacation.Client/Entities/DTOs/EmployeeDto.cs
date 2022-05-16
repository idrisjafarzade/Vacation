using Core.Entities.IDTOs;
using System.ComponentModel.DataAnnotations;


namespace Entities.DTOs
{
    public class EmployeeDto:IDTO
    {
        public bool IsSuccess { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}
