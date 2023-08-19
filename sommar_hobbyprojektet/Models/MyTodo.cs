using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace sommar_hobbyprojektet.Models
{
    [Table("todos")]
    public class MyTodo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Title { get; set; }= null!;
        public string Description { get; set; } =string.Empty;
        public DateTime TodoDate { get; set; } = DateTime.Now;
        public bool IsDone { get; set; }= false;
    }
}
