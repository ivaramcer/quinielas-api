﻿using QuinielasApi.Models.Entities;

namespace UserPickssApi.IRepository
{
    public interface IUserPicksRepository
    {
        Task<List<UserPicks>> GetAllAsync();
        Task<List<UserPicks>> GetAllByUserIdAsync(int userId, int sportId);
        Task<List<UserPicks>> GetAllByQuinielaUserIdAsync(int userId, int quinielaId);
        Task<List<UserPicks>> MakePicks(int userId, int quinielaId);
        Task<UserPicks?> GetByIdAsync(int id);
        Task BulkInsert(List<UserPicks> entities);
        Task BulkUpdate(List<UserPicks> entities);
        void Create(UserPicks entity);
        void Update(UserPicks entity);
        void Delete(UserPicks entity);
    }
}
