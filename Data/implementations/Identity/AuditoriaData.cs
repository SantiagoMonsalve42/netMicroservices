using Data.Models;
using Data.Models.Identity;

namespace Data.interfaces.Identity
{
    public class AuditoriaData : IAuditoriaData
    {
        public readonly IRepository<TblLogAuditoria> Repository;
        public AuditoriaData(IRepository<TblLogAuditoria> repository)
        {
            Repository = repository;
        }

        public async Task<TblLogAuditoria> CreateAsync(TblLogAuditoria row)
        {
            return await Repository.CreateAsync(row);
        }

        public async Task<TblLogAuditoria> UpdateAsync(TblLogAuditoria row)
        {
            return await Repository.Put(row);
        }
    }
}
