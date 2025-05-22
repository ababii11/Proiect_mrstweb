using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eUseControl.Domain.Entities.User;


namespace MRSTWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User model)
        {
            if (ModelState.IsValid)
            {
                var user = AccountController.GetUserByCredentials(model.Email, model.Password);
                
                if (user != null)
                {
                    // Create authentication ticket with user role
                    var authTicket = new FormsAuthenticationTicket(
                        1,                              // version
                        user.Username,                  // user name
                        DateTime.Now,                   // issue time
                        DateTime.Now.AddMinutes(30),    // expiry time
                        false,                          // do not remember
                        user.Level.ToString()                       // user role
                    );

                    // Encrypt the ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    // Create the cookie
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    // Add debug information
                    System.Diagnostics.Debug.WriteLine($"User logged in: {user.Username}, Role: {user.Level}");

                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Invalid username/email or password");
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
