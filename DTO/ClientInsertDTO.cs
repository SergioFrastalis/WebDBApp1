using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebDBApp1.DTO
{
    public class ClientInsertDTO
    {
        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname must be at least 1 character.")]
        public string? Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required.")]
        [MinLength(1, ErrorMessage = "Lastname must be at least 1 character.")]
        public string? Lastname { get; set; }

        public ClientInsertDTO() { }

        public ClientInsertDTO(string? firstname, string? lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
