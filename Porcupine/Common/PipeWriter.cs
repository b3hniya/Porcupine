namespace Porcupine.Common;

public class PipeWriter
{
    public static async Task WriteMessageOnPipe(StreamWriter writer, string requestMessage)
    {
        await writer.WriteLineAsync(requestMessage);
        await writer.FlushAsync();
    }
}