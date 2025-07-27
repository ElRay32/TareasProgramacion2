namespace Tarea2Api.Core
{
    public abstract class BaseService
    {
        protected ServiceResult<T> OkResult<T>(T data, string message = "")
            => new() { Success = true, Data = data, Message = message };

        protected ServiceResult<T> ErrorResult<T>(string message)
            => new() { Success = false, Data = default, Message = message };
    }
}
