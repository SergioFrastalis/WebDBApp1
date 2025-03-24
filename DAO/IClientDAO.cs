using WebDBApp1.Models;

namespace WebDBApp1.DAO

{
    public interface IClientDAO
    {
        Client? Insert(Client client);
        void update(Client client);
        void delete(int id);
        Client? GetById(int id);
        List<Client> GetAll();

    }
}
