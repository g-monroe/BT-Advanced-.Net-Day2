using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        [HttpGet]
        public ResponseObjects.ToDoList GetToDoList()
        {
            var  toDo = Datastore.ToDoHandler.GetToDos();
            var resp = new ResponseObjects.ToDoList();
            resp.TotalCount = toDo.Count;
            resp.Items = toDo.Select(x => new ResponseObjects.ToDoListItem() { Title = x.Title, ToDoId = x.Id }).ToList();
            return resp;
        }
        [HttpPost]
        public Datastore.DataModels.ToDo AddToDo(RequestObjects.ToDoCreationRequest request)
        {
            var toDo = new Datastore.DataModels.ToDo();
            toDo.Title = request.Title;
            toDo.Status = Datastore.Enums.ToDoEnums.Status.Incomplete;
            Datastore.ToDoHandler.InsertToDo(toDo);
            return toDo;
        }
    }
}