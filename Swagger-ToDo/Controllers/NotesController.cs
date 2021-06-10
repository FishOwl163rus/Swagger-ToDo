using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Swagger_ToDo.Context;
using Swagger_ToDo.Interfaces;
using Swagger_ToDo.Models;
using Swagger_ToDo.Services;

namespace Swagger_ToDo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public void Add([FromBody]NoteModel model) => _noteService.Add(model);

        [HttpDelete("{id}")]
        public void Remove(int id) => _noteService.Remove(id);

        [HttpDelete("{userId}")]
        public void RemoveAll(int userId) => _noteService.RemoveAll(userId);
        
        [HttpPut]
        public void Update([FromBody]NoteModel model) => _noteService.Update(model);

        [HttpGet("{id}")]
        public NoteModel Get(int id) => _noteService.Get(id);
        
        [HttpGet("{userId}")]
        public IEnumerable<NoteModel> GetAll(int userId) => _noteService.GetAll(userId);
        
        [HttpGet]
        public IEnumerable<NoteModel> GetAll() => _noteService.GetAll();
    }
}