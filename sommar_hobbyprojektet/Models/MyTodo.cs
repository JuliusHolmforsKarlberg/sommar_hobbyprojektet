using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sommar_hobbyprojektet.Models
{
    public class MyTodo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TodoDate { get; set; } 
        public bool IsDone { get; set; }
    }
}
