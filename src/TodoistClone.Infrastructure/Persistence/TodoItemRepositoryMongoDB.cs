using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem entity)
        {
            throw new NotImplementedException();
        }
    }
}