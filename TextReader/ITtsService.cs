using System.Threading.Tasks;

namespace TextReader
{
    public interface ITtsService
    {
        Task<string> RequestAudio(string prompt, string voice, string fileName);
    }
}
