using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDBApp1.DTO;
using WebDBApp1.Models;
using WebDBApp1.Services;

namespace WebDBApp1.Pages.Clients
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ClientInsertDTO ClientInsertDTO { get; set; } = new();

        public List<Error> ErrorArray { get; set; } = [];

        private readonly IClientService _clientService;

        public CreateModel(ClientInsertDTO clientInsertDTO, List<Error> errorArray, IClientService clientService)
        {
            _clientService = clientService;
        }

        public void OnGet()
        {
            //return Page();
        }

        public void OnPost() 
        {
            if(!ModelState.IsValid)
            {
                return;
            }

            try
            {
                ClientReadOnlyDTO? clientReadOnlyDTO = _clientService.Insert(ClientInsertDTO);  
                Response.Redirect("/Clients/getall");
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message ,""));
                return;
            }
        }
    }
}
