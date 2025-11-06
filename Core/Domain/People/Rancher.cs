using System;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace Core.Domain.People
{
    public class Rancher
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }

        public Rancher() {}

        [SetsRequiredMembers]
        public Rancher(Guid id, string name, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("El password no puede estar vacio.");

            Id = id;
            Name = name;
            Username = username;
            
            var hasher = new PasswordHasher<Rancher>();
            PasswordHash = hasher.HashPassword(this, password);
        }

        public PasswordVerificationResult SignIn(PasswordHasher<object> hasher, string providedPassword)
        {
            return hasher.VerifyHashedPassword(this, this.PasswordHash, providedPassword);
        }
    }
}