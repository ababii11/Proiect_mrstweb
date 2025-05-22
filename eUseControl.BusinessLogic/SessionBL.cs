﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
    public class SessionBL : UserApi, ISession
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

        public SessionResponse UserLogin(ULoginData data)
        {
            try
            {
                if (data == null)
                {
                    return new SessionResponse
                    {
                        Status = false,
                        StatusMsg = "Login data cannot be null"
                    };
                }

                var user = Users.FirstOrDefault(u =>
                    (u.Username.Equals(data.Credential, StringComparison.OrdinalIgnoreCase) ||
                     u.Email.Equals(data.Credential, StringComparison.OrdinalIgnoreCase)) &&
                    u.Password == data.Password);

                if (user == null)
                {
                    return new SessionResponse
                    {
                        Status = false,
                        StatusMsg = "Invalid username/email or password"
                    };
                }

                return new SessionResponse
                {
                    Status = true,
                    StatusMsg = "Login successful",
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new SessionResponse
                {
                    Status = false,
                    StatusMsg = "An error occurred during login"
                };
            }
        }

        public SessionResponse RegisterUser(User model)
        {
            try
            {
                if (model == null)
                {
                    return new SessionResponse
                    {
                        Status = false,
                        StatusMsg = "Registration data cannot be null"
                    };
                }

                // Check if username already exists
                if (Users.Any(u => u.Username.Equals(model.Username, StringComparison.OrdinalIgnoreCase)))
                {
                    return new SessionResponse
                    {
                        Status = false,
                        StatusMsg = "Username already exists"
                    };
                }

                // Check if email already exists
                if (Users.Any(u => u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    return new SessionResponse
                    {
                        Status = false,
                        StatusMsg = "Email already exists"
                    };
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

                return new SessionResponse
                {
                    Status = true,
                    StatusMsg = "Registration successful",
                    User = user
                };
            }
            catch (Exception ex)
            {
                return new SessionResponse
                {
                    Status = false,
                    StatusMsg = "An error occurred during registration"
                };
            }
        }
    }
}
