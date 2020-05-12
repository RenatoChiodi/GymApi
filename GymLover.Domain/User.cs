using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymLover.Domain
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public byte EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string TwoFactorEnabled { get; set; }
        public byte PerfilCompleted { get; set; }
        public DateTime LockoutEnd { get; set; }
        public DateTime LastAccess { get; set; }
        public string Ip { get; set; }
        public byte LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public virtual Person Person { get; set; }
    }
}
