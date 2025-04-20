using SharpAPI.Models;

namespace SharpAPI.Data;

public interface IDataRepository
{
    Task SaveDataAsync(DataModel data);
}