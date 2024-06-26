﻿using ForBank.DAL.Interfaces;
using ForBank.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBank.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.Include(x=>x.Cards).ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
