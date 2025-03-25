using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDBApp1.DTO;
using WebDBApp1.Models;
using WebDBApp1.Services;

namespace WebDBApp1.Pages.Clients
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public ClientUpdateDTO ClientUpdateDTO { get; set; } = new();

        public List<Error> ErrorArray { get; set; } = [];

        private readonly IClientService _clientService;

        public UpdateModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                ClientReadOnlyDTO? clientReadOnlyDTO = _clientService.GetById(id);
                ClientUpdateDTO = new ClientUpdateDTO()
                {
                    Id = clientReadOnlyDTO.Id,
                    Firstname = clientReadOnlyDTO.Firstname,
                    Lastname = clientReadOnlyDTO.Lastname
                };
                
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
            }
            return Page();

        }

        public void OnPost(int id)
        {
            try
            {
                ClientUpdateDTO.Id = id;
                _clientService.Update(ClientUpdateDTO);
                Response.Redirect("/Clients/getall");
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
            }
        }
    }
}
