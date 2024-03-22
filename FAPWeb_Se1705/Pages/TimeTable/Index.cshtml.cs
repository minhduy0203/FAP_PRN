using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAPWeb_Se1705.Pages.TimeTable
{
    public class IndexModel : PageModel
    {
        private ISessionService SessionService;

        public IndexModel(ISessionService sessionService)
        {
            SessionService = sessionService;
        }

        public List<Session> Sessions { get; set; }
        public void OnGet()
        {
            GetData();
        }

        private void GetData()
        {

        }
    }
}
