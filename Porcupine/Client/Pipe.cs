using System.IO.Pipes;
using Porcupine.Common.Static;

namespace Porcupine.Client;

public static class Pipe
{
    private static NamedPipeClientStream? _client;

    public static NamedPipeClientStream Client
    {
        get => _client;
    }

    public static async Task Init(
        string pipeName,
        Func<NamedPipeClientStream, Task> handler,
        string serverName = ".")
    {
        using (_client = new(serverName, pipeName))
        {
            Console.WriteLine(Messages.PipeClientInitMessage);
            await _client.ConnectAsync();

            await handler(_client);
        }
    }
}