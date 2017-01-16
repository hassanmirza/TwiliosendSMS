using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace TwilioAPi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        string AccountSid = "AC55bed24d780411342a106bd2a70835d8";
        string AuthToken = "d1f955600c524c500ad4d3c671833cd8";
        public ActionResult SendMessages(string cellNo, string tokenNo)
        {
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendMessage(
                "+447481340446", // From (Replace with your Twilio number)
                cellNo, // To (Replace with your phone number)
               tokenNo +""+ "Auth Code for littlebird app"
                );
            if (message.RestException != null)
            {
                var error = "404";
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReSendPassword(string cellNo, string pass)
        {
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendMessage(
                "+447481340446", // From (Replace with your Twilio number)
                cellNo, // To (Replace with your phone number)
              "your littlebird app password"+"" +pass
                );
            if (message.RestException != null)
            {
                var error = "404";
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}
