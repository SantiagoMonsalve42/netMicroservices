using Data.Models.Identity;

namespace Data.interfaces.Identity
{
    public interface IAuditoriaData
    {
        Task<TblLogAuditoria> CreateAsync(TblLogAuditoria row);
        Task<TblLogAuditoria> UpdateAsync(TblLogAuditoria row);

    }
}
