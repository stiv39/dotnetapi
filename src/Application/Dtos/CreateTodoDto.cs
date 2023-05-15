
namespace Application.Dtos
{
    public class CreateTodoDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
