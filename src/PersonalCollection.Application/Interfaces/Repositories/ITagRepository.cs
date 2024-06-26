﻿using PersonalCollection.Application.Models.Dto;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Interfaces.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        public Task<List<Tag>> GetTagsByIds(int[] tagIds);
    }
}
