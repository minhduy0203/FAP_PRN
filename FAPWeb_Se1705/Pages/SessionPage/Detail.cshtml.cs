using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAPWeb_Se1705.Pages.SessionPage
{
    public class DetailModel : PageModel
    {

        private ISessionService sessionService;
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public Models.Session Session { get; set; }

        public DetailModel(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public void OnGet()
        {
            GetData();
        }

        public void GetData()
        {
            Session = sessionService.GetSession(id);
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                sessionService.RemoveSession(id);
                return Redirect("/TimeTable");

            }
            catch (Exception)
            {

                return new PageResult();
            }
        }
    }
}
