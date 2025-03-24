using System.ComponentModel.DataAnnotations;

namespace WebDBApp1.DTO
{
    public class ClientUpdateDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname must be at least 1 character.")]

        public string? Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required.")]
        [MinLength(1, ErrorMessage = "Lastname must be at least 1 character.")]
        public string? Lastname { get; set; }

        public ClientUpdateDTO() { }

        public ClientUpdateDTO(int id, string? firstname, string? lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
