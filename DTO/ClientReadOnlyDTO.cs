namespace WebDBApp1.DTO
{
    public class ClientReadOnlyDTO : BaseDTO
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public ClientReadOnlyDTO() { }
        public ClientReadOnlyDTO(int id, string? firstname, string? lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
