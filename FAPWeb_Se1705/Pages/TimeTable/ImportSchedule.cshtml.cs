using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Text;

namespace FAPWeb_Se1705.Pages.TimeTable
{
    public class ImportScheduleModel : PageModel
    {

        private ISessionService sessionService;
        private string Message;

        public ImportScheduleModel(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public void OnGet()
        {
        }

        public FileResult OnPost(IFormFile Upload)
        {
            String result = "";
            try
            {
                List<Session> sessions = TimeTableLogic.GetValidSessions(Upload.OpenReadStream());
                result = sessionService.AddSessions(sessions);


            }
            catch (Exception ex)
            {

                result = "Import failed";
            }

            return File(Encoding.UTF8.GetBytes(result.ToString()), "text/csv", "Sessions.csv");


        }
    }
}
