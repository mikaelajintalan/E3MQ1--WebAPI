using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ToDoServices : IToDoServices
    {
        private ToDoDbContext _context;

        public ToDoServices(ToDoDbContext context)
        {
            _context = context;
        }

        public ToDo CreateToDo(ToDo toDo)
        {
            _context.Add(toDo);
            _context.SaveChanges();

            return toDo;
        }

        public ToDo GetToDo(int id)
        {
            return _context.ToDos.First(n => n.Id == id);
        }

        public List<ToDo> GetToDos()
        {
            return _context.ToDos.ToList(); ;
        }

        public void DeleteToDo(int id)
        {
            var toDo = _context.ToDos.First(n => n.Id == id);
            _context.ToDos.Remove(toDo);
            _context.SaveChanges();
        }

        public void EditToDo(ToDo toDo)
        {
            var editedToDo = _context.ToDos.First(n => n.Id == toDo.Id);
            editedToDo.Value = toDo.Value;
            _context.SaveChanges();
        }
    }
}
