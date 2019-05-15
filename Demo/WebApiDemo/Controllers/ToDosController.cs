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
        public ResponseObjects.ToDoList GetToDoList()
        {
            List<ToDo> todos = Datastore.ToDoHandler.GetToDos();
            var resp = new ResponseObjects.ToDoList();
            resp.TotalCount = todos.Count;
            resp.Items = todos.Select(x => new ResponseObjects.ToDoListItem()
            {
                Title = x.Title,
                ToDoId = x.Id
            }).ToList();

            return resp;
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