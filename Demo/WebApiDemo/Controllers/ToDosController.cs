using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Datastore.DataModels;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {

        [HttpGet]
        public ResponseObjects.ToDoList GetToDoList(string title = "", System.DateTime? date = null)
        {
            List<ToDo> todos = Datastore.ToDoHandler.GetToDos();
            if (title != "")
            {
                todos = todos.Where(x => x.Title.Contains(title)).ToList();
            }
            if(date != null)
            {
                todos = todos.Where(x => x.DueDate == date).ToList();
            }
            var resp = new ResponseObjects.ToDoList();
            resp.TotalCount = todos.Count;
            resp.Items = todos.Select(x => new ResponseObjects.ToDoListItem()
            {
                Title = x.Title,
                ToDoId = x.Id
            }).ToList();

            return resp;
        }

        [HttpGet("{toDoId}")]
        public ToDo GetToDo(int toDoId)
        {
            return WebApiDemo.Datastore.ToDoHandler.GetToDo(toDoId);
        }

        [HttpDelete("{id}")]
        public void DeleteToDo(int id)
        {
            // Imagine we deleted it
        }

        [HttpPut("{id}/complete")]
        public ToDo CompleteToDo(int id)
        {
            var todo = Datastore.ToDoHandler.GetToDo(id);
            todo.Status = Datastore.Enums.ToDoEnums.Status.Complete;
            Datastore.ToDoHandler.UpdateToDo(todo);
            return todo;
        }

        [HttpPut("{id}")]
        public ToDo UpdateToDo([FromRoute]int id, [FromBody]RequestObjects.ToDoCreationRequest request)
        {
            var todo = Datastore.ToDoHandler.GetToDo(id);
            todo.Title = request.Title;
            Datastore.ToDoHandler.UpdateToDo(todo);
            return todo;
        }

        [HttpPost]
        public ToDo AddToDo(RequestObjects.ToDoCreationRequest request)
        {
            var toDo = new ToDo();
            toDo.Title = request.Title;
            toDo.Status = Datastore.Enums.ToDoEnums.Status.Incomplete;
            Datastore.ToDoHandler.InsertToDo(toDo);
            return toDo;
        }
    }
}