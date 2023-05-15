using Application.Dtos;

namespace Application.Interfaces
{
    public interface IPostRepositoryService
    {
        Task<IEnumerable<PostDto>> GetAll();

        Task<PostDto?> GetById(int id);

        int? Add(CreatePostDto entity);

        bool Update(PostDto entity);

        Task<bool> Delete(int id);
    }
}
