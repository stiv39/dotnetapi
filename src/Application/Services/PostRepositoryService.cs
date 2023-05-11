using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class PostRepositoryService : IPostRepositoryService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public PostRepositoryService(
            IPostRepository postRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            ILogger logger)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<PostDto>> GetAll()
        {
           var posts = await _postRepository.GetAll();
           var postDtos = posts.Select(post => _mapper.Map<PostDto>(post));
           return postDtos;
        }

        public async Task<PostDto?> GetById(int id)
        {
            var post = await _postRepository.GetById(id);
            if(post == null) { return null; }

            return _mapper.Map<PostDto>(post);
        }

        public bool Add(CreatePostDto entity)
        {
            try
            {
                _postRepository.Add(_mapper.Map<Post>(entity));
                _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }     
        }

        public bool Update(PostDto entity)
        {
            try
            {
                _postRepository.Update(_mapper.Map<Post>(entity));
                _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }          
        }

        public bool Delete(int id)
        {
            try
            {
                var post = _postRepository.GetById(id);
                if (post == null) { return false; }

                _postRepository.Delete(_mapper.Map<Post>(post));
                _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }             
        }
    }
}
