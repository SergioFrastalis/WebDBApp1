using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDBApp1.Models;
using WebDBApp1.Services;

namespace WebDBApp1.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        public List<Error> ErrorArray { get; set; } = [];
        private readonly IClientService _clientService;

        public DeleteModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        public void OnGet(int id)
        {
            Console.WriteLine($"Trying to delete client with ID: {id}"); // TEMP: test if it triggers

            try
            {
                _clientService.Delete(id);
                Response.Redirect("/Clients/getall");
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));

            }
        }
    }
}
