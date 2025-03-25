using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDBApp1.DTO;
using WebDBApp1.Models;
using WebDBApp1.Services;

namespace WebDBApp1.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientReadOnlyDTO> Clients { get; set; } = [];
        public Error ErrorObj { get; set; } = new();

        private readonly IClientService _clientService;

        public IndexModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult OnGet()
        {
            try
            {
                ErrorObj = new();
                Clients = _clientService.GetAllClients();
            }
            catch (Exception ex)
            {
                ErrorObj = new Error("", ex.Message, "");
            }
            return Page();
        }
    }
}
