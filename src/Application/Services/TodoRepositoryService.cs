﻿using AutoMapper;
using Application.Dtos;
using Domain.Entities;
using Application.Interfaces;
using Domain.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class TodoRepositoryService : ITodoRepositoryService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public TodoRepositoryService(
            ITodoRepository todoRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger<TodoRepositoryService> logger)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<TodoDto>> GetAll()
        {
            var todos = await _todoRepository.GetAll();
            var todoDtos = todos.Select(todo => _mapper.Map<TodoDto>(todo));
            return todoDtos;
        }

        public async Task<TodoDto?> GetById(int id)
        {
            var todo = await _todoRepository.GetById(id);
            if (todo == null) { return null; }

            return _mapper.Map<TodoDto>(todo);
        }

        public int? Add(CreateTodoDto entity)
        {
            try
            {
                var mapped = _mapper.Map<Todo>(entity);
                _todoRepository.Add(mapped);
                _unitOfWork.SaveChanges();

                var id = _todoRepository.GetNewlyCreatedEntityId(mapped);

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public bool Update(TodoDto entity)
        {
            try
            {
                _todoRepository.Update(_mapper.Map<Todo>(entity));
                _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var todo = await _todoRepository.GetById(id);
                if (todo == null) { return false; }

                _todoRepository.Delete(todo);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
