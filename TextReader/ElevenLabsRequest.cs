namespace TextReader.Models
{
    internal class ElevenLabsRequest
    {
#pragma warning disable IDE1006 // Naming Styles
        public string text { get; set; }
        public string model_id { get; set; }
        public VoiceSettings voice_settings { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
