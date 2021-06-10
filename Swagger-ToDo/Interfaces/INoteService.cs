using System.Collections.Generic;
using Swagger_ToDo.Models;

namespace Swagger_ToDo.Interfaces
{
    public interface INoteService
    {
        void Add(NoteModel model);
        void Remove(int id);
        void Update(NoteModel model);
        void RemoveAll(int userId);
        NoteModel Get(int id);
        IEnumerable<NoteModel> GetAll(int userId);
        IEnumerable<NoteModel> GetAll();
    }
}