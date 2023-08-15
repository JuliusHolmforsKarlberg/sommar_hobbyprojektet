using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using sommar_hobbyprojektet.Models;

namespace sommar_hobbyprojektet.Services
{
    public class TodoService
    {
        string _dbPath;
        public string StatusMessage { get; set; }
        // SQLite connection
        private SQLiteConnection conn;
        private void Init()
        {
            // code to initialize the TodoService
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<MyTodo>();
        }

        public TodoService(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewTodo(string titelName, DateTime DueDate)
        {
            int result = 0;
            try
            {
                // Call Init()
                Init();
                // Basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(titelName))
                    throw new Exception("Valid name required");


                // Insert the new Todo into the database
                result = conn.Insert(new MyTodo { Title = titelName, TodoDate = DueDate, IsDone = false });
                

                StatusMessage = string.Format("Name: {0} --- Date: {1}", titelName, DueDate);
                result = 0;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("It's already added. {0}", ex.Message);
            }

        }

        public List<MyTodo> GetAllTodos()
        {            
            try
            {
                Init();
                return conn.Table<MyTodo>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<MyTodo>();
        }
        public int DeleteTodo(int todoID)
        {
            int result = 0;
            result = conn.Delete<MyTodo>(todoID);
            return result;
        }
        public void UpdateIsDoneStatus(int todoId, bool isDone)
        {
            try
            {
                // Retrieve the specific Todo
                var todoToUpdate = conn.Find<MyTodo>(todoId);
                if (todoToUpdate != null)
                {
                    // Update its IsDone property
                    todoToUpdate.IsDone = isDone;
                    // Save the updated Todo
                    conn.Update(todoToUpdate);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to update Todo status. Error: {ex.Message}";
            }
        }

    }
}
