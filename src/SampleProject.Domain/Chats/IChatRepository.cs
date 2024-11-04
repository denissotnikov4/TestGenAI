using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProject.Domain.Chats;

public interface IChatRepository
{
    Task AddAsync(Chat chat);
    
    Task<Chat> GetByIdAsync(Guid chatId);
    
    Task<List<Chat>> GetAllAsync();
    
    Task UpdateAsync(Chat chat);
    
    Task DeleteAsync(Guid chatId);
}