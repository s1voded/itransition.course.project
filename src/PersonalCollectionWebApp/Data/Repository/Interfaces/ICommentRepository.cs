﻿using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data.Repository.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        public Task<IEnumerable<Comment>> GetItemComments(int itemId);
    }
}
