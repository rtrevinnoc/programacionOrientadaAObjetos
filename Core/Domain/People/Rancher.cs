using System;
using System.Collections.Generic;
using Core.Domain.Locations;
using Microsoft.AspNetCore.Identity; // <-- AÑADE ESTE 'USING'

namespace Core.Domain.People
{
    public class Rancher
    {
        public Rancher(string name, string username, string plainPassword)
        {
            Id = Guid.NewGuid();
            
            Name = name;
            Username = username;
            
            Password = new PasswordHasher<Rancher>().HashPassword(this, plainPassword);

            Ranches = new List<Ranch>();
        }

        public Rancher()
        {
            Name = null!;
            Username = null!;
            Password = null!;
            
            Ranches = new List<Ranch>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Ranch> Ranches { get; set; }

        public PasswordVerificationResult SignIn(PasswordHasher<object> hasher, string providedPassword)
        {
            return hasher.VerifyHashedPassword(this, Password, providedPassword);
        }
    }
}