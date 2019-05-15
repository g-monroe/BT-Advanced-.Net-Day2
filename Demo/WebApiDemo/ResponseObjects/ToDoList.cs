using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.ResponseObjects
{
    public class ToDoList
    {
        public int TotalCount { get; set;  }
        public List<ToDoListItem> Items { get; set; }
    }

}
