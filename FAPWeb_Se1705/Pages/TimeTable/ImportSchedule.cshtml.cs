using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.FileIO;
using System.IO;

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

        public void OnPost(IFormFile Upload)
        {
            try
            {
                List<Session> sessions = TimeTableLogic.GetValidSessions(Upload.OpenReadStream());
                sessionService.AddSessions(sessions);
            }
            catch (Exception ex)
            {

                Message = "Import failed";
            }

        }
    }
}
