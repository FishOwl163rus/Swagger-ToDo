using System.Collections.Generic;
using System.Linq;
using Swagger_ToDo.Context;
using Swagger_ToDo.Interfaces;
using Swagger_ToDo.Models;

namespace Swagger_ToDo.Services
{
    public class NoteService : INoteService
    {
        private readonly ToDoContext _context;
        
        public NoteService(ToDoContext context)
        {
            _context = context;
        }
        
        public void Add(NoteModel model)
        {
            _context.Notes.Add(model);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var model = new NoteModel {Id = id};
            
            _context.Notes.Attach(model);
            _context.Notes.Remove(model);

            _context.SaveChanges();
        }

        public void Update(NoteModel model)
        {
            _context.Notes.Update(model);
            var entry = _context.Entry(model);
            
            entry.Property(n => n.Id).IsModified = false;
            entry.Property(n => n.UserId).IsModified = false;

            _context.SaveChanges();
        }

        public void RemoveAll(int userId)
        {
            _context.RemoveRange(_context.Notes.Where(u => u.UserId == userId));
            _context.SaveChanges();
        }

        public NoteModel Get(int id)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<NoteModel> GetAll(int userId)
        {
            return _context.Notes.Where(n => n.UserId == userId);
        }

        public IEnumerable<NoteModel> GetAll()
        {
            return _context.Notes.ToList();
        }
    }
}