namespace Porcupine.Common;

public static class PipeReader
{
    public static async Task<string?> ReadResponseFromPipe(StreamReader reader)
    {
        var response = await reader.ReadLineAsync();


        if (response is not null)
            return response;
        else
            throw new Exception("response is null");
    }
}