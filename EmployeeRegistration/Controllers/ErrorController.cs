using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistration.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            var statuscoderes = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "resource you requsted could not be found.";
                    ViewBag.Path = statuscoderes.OriginalPath;
                    ViewBag.OQS = statuscoderes.OriginalQueryString;
                    break;
            }
            return View("Not Found");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;
            return View("Error");
        }

    }
}