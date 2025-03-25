using WebDBApp1.DTO;

namespace WebDBApp1.Services
{
    public interface IClientService
    {
        ClientReadOnlyDTO? Insert(ClientInsertDTO client);
        void Update(ClientUpdateDTO client);
        void Delete(int id);
        ClientReadOnlyDTO? GetById(int id);
        List<ClientReadOnlyDTO> GetAllClients();

    }
}
