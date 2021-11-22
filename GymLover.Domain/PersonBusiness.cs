using GymLover.Domain.Entities;
using GymLover.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GymLover.Domain
{
    public class PersonBusiness : IPersonBusiness
    {
        private List<Person> _person;

        public PersonBusiness()
        {
            _person = People();
        }

        public void DeletePerson(Person person)
        {
            _person.Remove(person);
        }

        public void EditPerson(Person person)
        {
            _person.Remove(_person.FirstOrDefault(x => x.Id == person.Id));
            _person.Add(person);
        }

        public List<Person> GetPeople()
        {
            return _person;
        }

        public Person GetPerson(int Id)
        {
            return _person.FirstOrDefault(x => x.Id == Id);
        }

        public void IsertPerson(Person person)
        {
            _person.Add(person);
        }

        private List<Person> People()
        {
            var people = new List<Person>();

            people.Add(new Person { Id = 1, Name = "Renato", LastName = "Chiodi", CPF = "0123.123.123-85", Email = "Renato@email.com", Address = "Maria Julia da Luz", Neighbor = "Bairro teste", City = "São José",  Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 2, Name = "Denise", LastName = "Mueller", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Maria Julia da Luz", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 3, Name = "Fernando", LastName = "Mueller", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 4, Name = "Pedro", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 5, Name = "Maria", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 6, Name = "Julia", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 7, Name = "Ana", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 8, Name = "Diego", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 9, Name = "joão", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Testez", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });
            people.Add(new Person { Id = 10, Name = "Eduardo", LastName = "Teste", CPF = "0123.123.123-85", Email = "Teste@email.com", Address = "Rua Teste", Neighbor = "Bairro teste", City = "São José", Phone = "48988653636", State = "SC" });

            return people;
        }
    }
}
