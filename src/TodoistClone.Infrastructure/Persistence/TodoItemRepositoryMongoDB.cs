using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;
using TodoistClone.Infrastructure.Persistence.config;

namespace TodoistClone.Infrastructure.Persistence
{
    public class TodoItemRepositoryMongoDB : ITodoItemRepository
    {
        public TodoItemRepositoryMongoDB(ITodosContext context)
        {
            this._context = context;
        }

        private readonly ITodosContext _context;


        public void Add(TodoItem entity)
        {
            _context.TodoItems.InsertOne(entity);
        }

        public void Delete(TodoItem entity)
        {
            var filter = Builders<TodoItem>.Filter.Eq(e => e.Id, entity.Id);
            _context.TodoItems.DeleteOne(filter);
        }

        public Task<List<TodoItem>> GetAllAsync()
        {
            var filter = Builders<TodoItem>.Filter.Empty;

            var result = _context.TodoItems.FindAsync(filter);
            return result.Result.ToListAsync();

        }

        public Task<TodoItem?> GetByIdAsync(Guid id)
        {
            var filter = Builders<TodoItem>.Filter.Eq(e => e.Id, id);
            var result = _context.TodoItems.FindAsync(filter);
            return result.Result.FirstOrDefaultAsync();

        }

        public void Update(TodoItem entity)
        {

            var filter = Builders<TodoItem>.Filter.Eq(e => e.Id, entity.Id);

            var result = _context.TodoItems.FindOneAndReplace(filter, entity);
        }
    }
}