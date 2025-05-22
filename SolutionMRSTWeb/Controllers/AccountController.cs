using System;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using eUseControl.Domain.Entities.User;

namespace MRSTWeb.Controllers
{
    public class AccountController : Controller
    {
        // In-memory storage for demo purposes
        private static readonly List<User> Users = new List<User>
        {
            // Pre-create admin account
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@example.com",
                Password = "Admin123!", // In real application, this should be hashed
                Level = URole.Admin,
                CreatedAt = DateTime.Now
            }
        };

        // Helper method to get user credentials
        public static User GetUserByCredentials(string credential, string password)
        {
            var user = Users.FirstOrDefault(u => 
                (u.Username.Equals(credential, StringComparison.OrdinalIgnoreCase) ||
                 u.Email.Equals(credential, StringComparison.OrdinalIgnoreCase)) &&
                u.Password == password);

            // Add debug information
            if (user != null)
            {
                System.Diagnostics.Debug.WriteLine($"Found user: {user.Username}, Role: {user.Level}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No user found with the provided credentials");
            }

            return user;
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Check if username already exists
                if (Users.Any(u => u.Username.Equals(model.Username, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View(model);
                }

                // Check if email already exists
                if (Users.Any(u => u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View(model);
                }

                // Create new user
                var user = new User
                {
                    Id = Users.Count + 1,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password, // In real application, this should be hashed
                    Level = URole.User, // Default role
                    CreatedAt = DateTime.Now
                };

                Users.Add(user);

                // Create authentication ticket
                FormsAuthentication.SetAuthCookie(user.Username, false);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: Account/ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: Account/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(User model)
        {
            if (ModelState.IsValid)
            {
                // Find user by email
                var user = Users.FirstOrDefault(u => 
                    u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase));

                if (user != null)
                {
                    // In a real application, you would:
                    // 1. Generate a password reset token
                    // 2. Save it to the database with an expiration
                    // 3. Send an email with a reset link
                }

                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true });
                }
                TempData["SuccessMessage"] = "If an account exists with this email, you will receive password reset instructions.";
                return RedirectToAction("Index", "Login");
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = false, message = "Invalid email address" });
            }
            return View(model);
        }
    }
} 