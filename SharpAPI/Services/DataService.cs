using SharpAPI.Data;
using SharpAPI.Models;

namespace SharpAPI.Services;

public class DataService
{
    private readonly IDataRepository _dataRepository;

    public DataService(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public async Task<string> ProcessDataAsync(DataDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Name)) throw new ArgumentException("Name cannot be empty.");

        var data = new DataModel
        {
            Name = dto.Name,
            Description = dto.Description
        };
        await _dataRepository.SaveDataAsync(data);
        return "Data saved successfully.";
    }

}