using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TradeMarketDbContext context;

        public PersonRepository(TradeMarketDbContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Person entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public void Delete(Person entity)
        {
           throw new NotImplementedException();

        }

        public Task DeleteByIdAsync(int id)
        {
            var person = new Person() { Id = id };
            context.Entry(person).State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Person>> GetAllAsync()=>
            Task.FromResult(context.Persons.AsEnumerable());

        public Task<Person> GetByIdAsync(int id)=>
            Task.FromResult(context.Persons.Find(id));

        public void Update(Person entity)
        {
            context.Entry(entity).State= EntityState.Modified;
            context.SaveChanges();
        }
    }
}
