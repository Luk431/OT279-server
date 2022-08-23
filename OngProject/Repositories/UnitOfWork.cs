﻿using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        private Repository<Category> _categoriesRepository;
        private Repository<User> _usersRepository; 

        public IRepository<News> NewsRepository { get; private set; }
        private IRepository<Testimonials> _testimonialsRepository;

        public UnitOfWork(OngDbContext context)
        {
            _context = context;
            NewsRepository = new Repository<News>(context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Repository<Category> CategoriesRepo
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new Repository<Category>(_context);
                }
                return _categoriesRepository;
            }
        }

        public Repository<User> UserRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new Repository<User>(_context);
                }
                return _usersRepository;
            }
        }

        public IRepository<Testiomonials> TestiomonialsRepository
        {
            get
            {
                if (_testimonialsRepository == null)
                {
                    _testimonialsRepository = new Repository<Testimonials>(_context);
                }
                return _testimonialsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
