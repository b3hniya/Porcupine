using Newtonsoft.Json;

namespace Porcupine.Common.Model;

[Serializable]
public class RequestModel
{
    public string? Data { get; set; }
    public string? Point { get; set; }
    public string? Type { get; set; }

    public RequestModel(string data, string point, string type)
    {
        Data = data;
        Point = point;
        Type = type;
    }

    public static string GetSerilizedRequestObject(string data, string pointName, string type)
    {
        return JsonConvert.SerializeObject(
            new RequestModel(
                data,
                pointName,
                type
            ));
    }
}