using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tarea2Api.Core
{
    public interface IBaseService<TDto>
    {
        Task<ServiceResult<IEnumerable<TDto>>> GetAllAsync();
        Task<ServiceResult<TDto>> GetByIdAsync(int id);
        Task<ServiceResult<TDto>> CreateAsync(TDto dto);
        Task<ServiceResult<TDto>> UpdateAsync(int id, TDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}
