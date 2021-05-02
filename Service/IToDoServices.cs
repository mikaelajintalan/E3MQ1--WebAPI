using Repository;
using System.Collections.Generic;

namespace Service
{
    public interface IToDoServices
    {
        ToDo CreateToDo(ToDo toDo);
        ToDo GetToDo(int id);
        List<ToDo> GetToDos();
        void DeleteToDo(int id);
        void EditToDo(ToDo toDo);
    }
}
