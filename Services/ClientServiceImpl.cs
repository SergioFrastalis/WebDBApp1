using AutoMapper;
using System.Transactions;
using WebDBApp1.DAO;
using WebDBApp1.DTO;
using WebDBApp1.Exceptions;
using WebDBApp1.Models;

namespace WebDBApp1.Services
{
    public class ClientServiceImpl : IClientService
    {
        private readonly IClientDAO _clientDAO;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientServiceImpl> _logger;

        public ClientServiceImpl(IClientDAO clientDAO, IMapper mapper, ILogger<ClientServiceImpl> logger)
        {
            _clientDAO = clientDAO;
            _mapper = mapper;
            _logger = logger;
        }

        public ClientReadOnlyDTO? Insert(ClientInsertDTO clientInsertDTO)
        {
            ClientReadOnlyDTO clientReadOnlyDTO;
            try
            {
                using TransactionScope scope = new TransactionScope();
                Client client = _mapper.Map<Client>(clientInsertDTO);
                Client? insertedClient = _clientDAO.Insert(client);
                clientReadOnlyDTO = _mapper.Map<ClientReadOnlyDTO>(insertedClient);

                scope.Complete();
                return clientReadOnlyDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inserting client. {ErrorMessage}",
                    clientInsertDTO.Firstname, clientInsertDTO.Lastname, ex.Message);
                throw;
            }
        }

        public void Update(ClientUpdateDTO clientUpdateDTO)
        {
            Client client;

            try
            {
                using TransactionScope scope = new();
                if (_clientDAO.GetById(clientUpdateDTO.Id) == null)
                {
                    throw new ClientNotFoundException($"Client with id {clientUpdateDTO.Id} not found");
                }
                client= _mapper.Map<Client>(clientUpdateDTO);
                _clientDAO.update(client);
                scope.Complete();
            }
            catch (ClientNotFoundException ex) 
            {
                _logger.LogError("Error updating client. {ErrorMessage}", ex.Message);
                throw;
            }
            catch (TransactionException ex)
            {
                _logger.LogError("Error updating client. {ErrorMessage}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating client. {ErrorMessage}", ex.Message);
                throw;
            }   
        }

        public void Delete(int id)
        {
            try
            {
                using TransactionScope scope = new();
                if (_clientDAO.GetById(id) == null)
                {
                    throw new ClientNotFoundException($"Client with id {id} not found");
                }
                _clientDAO.delete(id);
                scope.Complete();
            }
            catch (ClientNotFoundException ex)
            {
                _logger.LogError("Error deleting client. {ErrorMessage}", ex.Message);
                throw;
            }
            catch (TransactionException ex)
            {
                _logger.LogError("Error deleting client. {ErrorMessage}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting client. {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public List<ClientReadOnlyDTO> GetAllClients()
        {
            ClientReadOnlyDTO clientReadOnlyDTO;
            List<ClientReadOnlyDTO> clientReadOnlyDTOs = new();
            List<Client> clients;
            try
            {
                clients = _clientDAO.GetAll();

                foreach (Client client in clients) {
                    clientReadOnlyDTO = _mapper.Map<ClientReadOnlyDTO>(client);
                    clientReadOnlyDTOs.Add(clientReadOnlyDTO);
                }   
                return clientReadOnlyDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting all clients. {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public ClientReadOnlyDTO? GetById(int id)
        {
            ClientReadOnlyDTO? clientReadOnlyDTO;
            Client? client;

            try
            {
                client = _clientDAO.GetById(id);
                if (client == null)
                {
                    throw new ClientNotFoundException($"Client with id {id} not found");
                }
                clientReadOnlyDTO = _mapper.Map<ClientReadOnlyDTO>(client);
                return clientReadOnlyDTO;
            }
            catch (ClientNotFoundException ex)
            {
                _logger.LogError("Error getting client. {ErrorMessage}", ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting client. {ErrorMessage}", ex.Message);
                throw;
            }
        }

        

    }
}
