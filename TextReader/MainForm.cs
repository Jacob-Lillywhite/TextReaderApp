using System.Windows.Forms;
using System;
using System.Threading;
using System.Linq;
using NAudio.Wave;
using System.IO;
using System.Threading.Tasks;
using TextReader.Models;
using System.Collections.Generic;
using TextReader.Input;
using TextReader.Services;

namespace TextReader
{
    public partial class MainForm : Form
    {
        private readonly SnippingForm _snippingForm;
        private readonly TtsService _ttsService;
        private Mp3FileReader reader;
        private readonly WaveOutEvent waveOut = new WaveOutEvent();

        private const int HotkeyId = 1;
        private string processedText;
        private const string DEFAULT_VOICE_ID = "RSSYi9qxZE4wMcHRAUjJ";
        private const float DEFAULT_VOICE_VOLUME = .5f;
        private string selectedVoice = DEFAULT_VOICE_ID;
        private float selectedVolume = DEFAULT_VOICE_VOLUME;
        private string audio;
        private string audioFilePath;
        private string previouslyProcessedText;

        public MainForm(ISnippingForm formCapture, ITtsService ttsService)
        {
            _snippingForm = (SnippingForm)(formCapture ?? throw new ArgumentNullException(nameof(formCapture)));
            _ttsService = (TtsService)(ttsService ?? throw new ArgumentNullException(nameof(ttsService)));
            NativeMethods.RegisterHotKey(Handle, HotkeyId, KeyModifiers.Control, Keys.Space);

            InitializeComponent();
            AddEventListeners();
            LoadVoices();
            SetupFormVisibility();
        }

        private void AddEventListeners()
        {
            FormClosing += MainForm_FormClosing;
            volumeSelector.ValueChanged += VolumeSelector_ValueChanged;
            textBox.TextChanged += TextBox_TextChanged;
        }

        private void BringDialogToFront<T>() where T : Form
        {
            T existingDialog = Application.OpenForms.OfType<T>().FirstOrDefault();
            existingDialog?.BringToFront();
        }

        private void SnipButton_Click(object sender, EventArgs e)
        {
            Snip();
        }

        private void HandleHotkey()
        {
            Snip();
        }

        private void HideLoadingPanel()
        {
            LoadingBox.Invoke(new MethodInvoker(() => LoadingBox.Visible = false));
            ProcessingPanel.Invoke(new MethodInvoker(() => ProcessingPanel.Visible = false));
        }

        private bool IsDialogOpen<T>() where T : Form
        {
            return Application.OpenForms.OfType<T>().Any();
        }

        private void LoadVoices()
        {
            var voices = new List<Voice>()
            {
                new Voice(){Name="British Gentleman", Id="RSSYi9qxZE4wMcHRAUjJ"},
                new Voice(){Name="British Lady", Id="PrToS5QAsyROoA4tQIUG"},
                new Voice(){Name="British Boy", Id="brt1RJPtSKYTi0tc3row"},
            };

            foreach (Voice voice in voices)
            {
                voiceSelector.Items.Add(voice);
            }

            voiceSelector.DisplayMember = "Name";
            voiceSelector.ValueMember = "Value";
            voiceSelector.SelectedIndex = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.UnregisterHotKey(Handle, HotkeyId);
        }

        private async void ReadButton_ClickAsync(object sender, EventArgs e)
        {
            ReadButton.Enabled = false;
            LoadingBox.Visible = true;
            ProcessingPanel.Visible = true;
            await ReadText().ConfigureAwait(false);
        }

        private async Task ReadText()
        {
            if (textBox.Text != null && textBox.Text?.Length != 0)
            {
                try
                {
                    var guid = Guid.NewGuid();
                    var myFileName = guid.ToString();
                    var baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    audio = await _ttsService.RequestAudio(textBox.Text, selectedVoice, myFileName).ConfigureAwait(false);
                    audioFilePath = Path.Combine(baseDirectory, "TextReader", audio);
                    using (reader = new Mp3FileReader(audioFilePath))
                    using (waveOut)
                    {
                        waveOut.Init(reader);
                        waveOut.Volume = selectedVolume;
                        HideLoadingPanel();
                        waveOut.Play();

                        // Let the Audio Finish Playing
                        while (waveOut.PlaybackState == PlaybackState.Playing) { Thread.Sleep(100); }
                    }
                    File.Delete(audioFilePath);
                    previouslyProcessedText = textBox.Text;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void SetupFormVisibility()
        {
            LoadingBox.Visible = false;
            ProcessingPanel.Visible = false;
        }

        private void Snip()
        {
            Hide();
            Thread.Sleep(200); // This is required to hide the FormOverlay while snipping.
            if (!IsDialogOpen<SnippingForm>())
            {
                _snippingForm.ShowDialog();
                processedText = Clipboard.GetText();
                textBox.Text = processedText;
                Show();
            }
            BringDialogToFront<SnippingForm>();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ReadButton.Enabled = !textBox.Text.Equals(previouslyProcessedText);
        }

        private void VoiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedVoice = voiceSelector.SelectedItem != null ? ((dynamic)voiceSelector.SelectedItem).Id : selectedVoice;
        }

        private void VolumeSelector_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            selectedVolume = (float)trackBar.Value / 100;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HotkeyId) { HandleHotkey(); }
        }
    }
}
