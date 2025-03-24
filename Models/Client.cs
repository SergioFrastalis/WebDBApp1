namespace WebDBApp1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public String? Firstname { get; set; }
        public String? Lastname { get; set; }

        public Client() { }

        public Client(int id, string? firstname, string? lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }

       

        public override string? ToString()
        {
            return $"{Id} {Firstname} {Lastname}";
        }
    }
}
