using System.Collections.Generic;
using System.Threading.Tasks;
using AuditTool.Models;

namespace AuditTool.Repositories
{
    public interface IEngagementRepository
    {
        Task AddAsync(Engagement item);

        Task<Engagement> GetAsync(string id, string partitionKey);

        Task<IEnumerable<Engagement>> GetAllAsync();

        Task DeleteAsync(string id, string partitionKey);

        Task<Engagement> ReplaceAsync(Engagement item);
    }
}