using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymLover.Domain
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Neighbor { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Permission { get; set; }
        public string LastAcess { get; set; }
    }
}
