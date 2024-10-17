using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepositoryPattern_ASPNetCore_WebAPI.Services;

public interface IServiceResult
{
    bool Status { get; set; }
    List<string> Message { get; set; }
    string MessageType { get; set; }
}
