using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppTask.Commons.Interface
{
    public interface IJsonHelper
    {
        Task<List<T>> ReadFromJson<T>(string jsonFile);
        Task<bool> UpdateJson<T>(List<T> model, string jsonFile);
        Task<bool> WriteToJson<T>(T model, string jsonFile);
    }
}
