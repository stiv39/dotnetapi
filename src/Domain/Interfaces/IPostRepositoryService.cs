using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface IPostRepositoryService
    {
        Task<IEnumerable<PostDto>> GetAll();

        Task<PostDto?> GetById(int id);

        int? Add(CreatePostDto entity);

        bool Update(PostDto entity);

        bool Delete(int id);
    }
}
