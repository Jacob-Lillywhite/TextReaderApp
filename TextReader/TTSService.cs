using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TextReader.Models;

namespace TextReader.Services
{
    public class TtsService: ITtsService
    {
        private const string BASE_URL = "https://api.elevenlabs.io/v1/text-to-speech/";
        private readonly string API_KEY = Environment.GetEnvironmentVariable("ELEVEN_LABS_API_KEY");
        public bool requesting = false;

        public async Task<string> RequestAudio(string prompt, string voice, string fileName)
        {
            string url = BASE_URL + voice;
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("xi-api-key", API_KEY);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("audio/mpeg"));

            var data = new ElevenLabsRequest()
            {
                text = prompt,
                model_id = "eleven_monolingual_v1",
                voice_settings = new VoiceSettings()
                {
                    stability = 0.5f,
                    similarity_boost = 0.8f
                }
            };

            string json = JsonConvert.SerializeObject(data);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.Default, "application/json");

            var response = await client.PostAsync(url, httpContent);
            requesting = false;

            if (response != null)
            {
                int fileNameExtension = 0;
                int retries = 0;
                bool fileNameValid = false;

                while (!fileNameValid)
                {
                    try
                    {
                        var directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TextReader\\");

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        using (var fileStream = File.Create(directoryPath + fileName + fileNameExtension.ToString() + ".mp3"))
                        {
                            await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                        fileNameValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        retries++;
                        if (retries > 10) { break; }
                        fileNameExtension++;
                    }
                }

                return fileName + fileNameExtension.ToString() + ".mp3";
            }
            return null;
        }
    }
}
