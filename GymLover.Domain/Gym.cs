using System;
using System.Collections.Generic;
using System.Text;

namespace GymLover.Domain
{
    public class Gym
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string Address { get; set; }
        public string Neighbor { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Logo { get; set; }
        public int PersonId { get; set; }
    }
}
