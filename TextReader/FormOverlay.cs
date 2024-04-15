using System.Windows.Forms;
using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
using NAudio.Wave;
using System.IO;
using System.Threading.Tasks;
using TextReader.Models;
using System.Collections.Generic;

namespace TextReader
{
    public partial class FormOverlay : Form
    {
        // Import the necessary functions from user32.dll for creating a global hotkey.
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                DWMWINDOWATTRIBUTE attribute,
                                                ref int pvAttribute,
                                                uint cbAttribute);
        [Flags]
        private enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        // This is used for native windows styles
        public enum DWMWINDOWATTRIBUTE : uint
        {
            DWMWA_NCRENDERING_ENABLED,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_PASSIVE_UPDATE_MODE,
            DWMWA_USE_HOSTBACKDROPBRUSH,
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_WINDOW_CORNER_PREFERENCE = 33,
            DWMWA_BORDER_COLOR,
            DWMWA_CAPTION_COLOR,
            DWMWA_TEXT_COLOR,
            DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
            DWMWA_SYSTEMBACKDROP_TYPE,
            DWMWA_LAST
        }

        private const int HotkeyId = 1;

        private string processedText;
        readonly FormCapture formCapture = new FormCapture();
        private readonly TTSService tts;
        private string selectedVoice = "RSSYi9qxZE4wMcHRAUjJ";
        private float selectedVolume = .5f;
        private readonly WaveOutEvent waveOut;
        private string audio;
        private Mp3FileReader reader;
        private string audioFilePath;
        private string previouslyProcessedText;

        public FormOverlay()
        {
            RegisterHotKey(Handle, HotkeyId, KeyModifiers.Control, Keys.Space);
            tts = new TTSService();
            waveOut = new WaveOutEvent();

            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            volumeSelector.ValueChanged += VolumeSelector_ValueChanged;
            textBox.TextChanged += TextBox_TextChanged;
            LoadingBox.Visible = false;
            ProcessingPanel.Visible = false;

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

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            Hide();
            Thread.Sleep(200);
            formCapture.ShowDialog();
            processedText = Clipboard.GetText();
            textBox.Text = processedText;
            Show();
        }

        private async void ProcessButton_ClickAsync(object sender, EventArgs e)
        {
            ProcessButton.Enabled = false;
            LoadingBox.Visible = true;
            ProcessingPanel.Visible = true;
            await UpdateOverlayTextAsync().ConfigureAwait(false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, HotkeyId);
        }

        private void HandleHotkey()
        {
            HotkeyCapture();
        }

        private void HotkeyCapture()
        {
            Hide();
            Thread.Sleep(200);
            if(!IsDialogOpen<FormCapture>())
            {
                formCapture.ShowDialog();
                processedText = Clipboard.GetText();
                textBox.Text = processedText;
                Show();
            }
            BringDialogToFront<FormCapture>();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HotkeyId)
            {
                HandleHotkey();
            }
        }

        private bool IsDialogOpen<T>() where T : Form
        {
            return Application.OpenForms.OfType<T>().Any();
        }

        private void BringDialogToFront<T>() where T : Form
        {
            T existingDialog = Application.OpenForms.OfType<T>().FirstOrDefault();
            existingDialog?.BringToFront();
        }

        private async Task UpdateOverlayTextAsync()
        {
            if (textBox.Text != null && textBox.Text?.Length != 0)
            {
                try
                {
                    var guid = Guid.NewGuid();
                    var myFileName = guid.ToString();
                    var baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    audio = await tts.RequestAudio(textBox.Text, selectedVoice, myFileName).ConfigureAwait(false);
                    audioFilePath = Path.Combine(baseDirectory, "TextReader", audio);
                    using (reader = new Mp3FileReader(audioFilePath))
                    using (waveOut)
                    {
                        waveOut.Init(reader);
                        waveOut.Volume = selectedVolume;
                        HideLoading();
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

        private void VoiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (voiceSelector.SelectedItem != null)
            {
                selectedVoice = ((dynamic)voiceSelector.SelectedItem).Id;
            }
        }

        private void VolumeSelector_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            selectedVolume = (float)trackBar.Value/100;
            Console.WriteLine(selectedVolume);
        }

        private void HideLoading()
        {
            LoadingBox.Invoke(new MethodInvoker(() => LoadingBox.Visible = false));
            ProcessingPanel.Invoke(new MethodInvoker(() => ProcessingPanel.Visible = false));
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if(!textBox.Text.Equals(previouslyProcessedText))
            {
                ProcessButton.Enabled = true;
            }
            else 
            { 
                ProcessButton.Enabled = false; 
            }
        }
    }
}
