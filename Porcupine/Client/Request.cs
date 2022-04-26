using Porcupine.Common;
using Porcupine.Common.Model;

namespace Porcupine.Client;

public class Request
{
    public readonly string PipeName;

    public Request(string pipeName)
    {
        PipeName = pipeName;
    }


    public async Task Send(
        string pointName,
        string data,
        Action<string?> responseHandler)
    {
        await Pipe.Init(PipeName, async client =>
        {
            using StreamReader reader = new(client);
            using StreamWriter writer = new(client);

            string requestMessage
                = RequestModel.GetSerilizedRequestObject(data, pointName, "Send");

            await PipeWriter.WriteMessageOnPipe(writer, requestMessage);


            string? response = await PipeReader.ReadResponseFromPipe(reader);

            responseHandler(response);
        });
    }
}