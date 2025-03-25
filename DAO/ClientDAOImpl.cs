using Microsoft.Data.SqlClient;
using WebDBApp1.Models;
using WebDBApp1.Services.DBHelper;

namespace WebDBApp1.DAO
{
    public class ClientDAOImpl : IClientDAO
    {
        public void delete(int id)
        {
            string sql = "DELETE FROM Clients WHERE Id = @Id";

            using SqlConnection connection = DBUtil.GetConnection();
            connection.Open();

            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();

        }

        public List<Client> GetAll()
        {
            string sql = "SELECT * FROM Clients";  
            List<Client> clients = [];

            using SqlConnection connection = DBUtil.GetConnection();
            connection.Open();

            using SqlCommand command = new(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                clients.Add(new Client()
                {
                    Id = (int)reader["Id"],
                    Firstname = (string)reader["Firstname"],
                    Lastname = (string)reader["Lastname"]
                });
            }
            return clients;
        }

        public Client? GetById(int id)
        {
            Client? clientToReturn = null;
            string sql = "SELECT * FROM Clients Where Id = @id";

            using SqlConnection connection = DBUtil.GetConnection();
            connection.Open();

            using SqlCommand command = new(sql, connection);   
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                clientToReturn = new Client()
                {
                    Id = (int)reader["Id"],
                    Firstname = (string)reader["Firstname"],
                    Lastname = (string)reader["Lastname"]
                };
            }
            return clientToReturn;
        }

        public Client? Insert(Client client)
        {
            Client? clientToReturn = null;
            int insertedId = 0;
            string sql1 = "INSERT INTO Clients (Firstname, Lastname) VALUES (@Firstname, @Lastname);" +
                "SELECT SCOPE_IDENTITY();";

            using SqlConnection connection = DBUtil.GetConnection();
            connection.Open();

            using SqlCommand command1 = new(sql1, connection);
            command1.Parameters.AddWithValue("@Firstname", client.Firstname);
            command1.Parameters.AddWithValue("@Lastname", client.Lastname);

            object insertObj = command1.ExecuteScalar();
            if (insertObj != null)
            {
                if(!int.TryParse(insertObj.ToString(), out insertedId))
                {
                    throw new Exception("Error parsing inserted id");
                }
            }

            string sql2 = "SELECT * FROM Clients WHERE Id = @ClientId";
            using SqlCommand command2 = new(sql2, connection);
            command2.Parameters.AddWithValue("@ClientId", insertedId);

            using SqlDataReader reader = command2.ExecuteReader();
            if (reader.Read())
            {
                clientToReturn = new Client()
                {
                    Id = (int)reader["Id"], 
                    Firstname = (string)reader["Firstname"],
                    Lastname = (string)reader["Lastname"]
                };
            }
            return clientToReturn;
        }

        public void update(Client client)
        {
            string sql = "UPDATE Clients SET Firstname = @Firstname, Lastname = @Lastname WHERE Id = @Id";

            using SqlConnection connection = DBUtil.GetConnection();
            connection.Open();

            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@Id", client.Id);
            command.Parameters.AddWithValue("@Firstname", client.Firstname);
            command.Parameters.AddWithValue("@Lastname", client.Lastname);

            command.ExecuteNonQuery();
        }
    }
}
