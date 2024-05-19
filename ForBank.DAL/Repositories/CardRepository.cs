using ForBank.DAL.Interfaces;
using ForBank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBank.DAL.Repositories
{
    public class CardRepository : IBaseRepository<Card>
    {
        private readonly ApplicationDbContext _db;

        public CardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Card entity)
        {
            await _db.Cards.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Card entity)
        {
            _db.Cards.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<Card>> GetAll()
        {
            return await _db.Cards.ToListAsync();
        }

        public async Task<Card> Update(Card entity)
        {
            _db.Cards.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
