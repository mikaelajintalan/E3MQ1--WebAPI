using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
