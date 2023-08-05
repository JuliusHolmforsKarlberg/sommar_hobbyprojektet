using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sommar_hobbyprojektet.Models;

namespace sommar_hobbyprojektet.Services
{
    public class TodoService
    {
        public List<MyTodo> Todos { get; set; } = new List<MyTodo>();
    }
}
