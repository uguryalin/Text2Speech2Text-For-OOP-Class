using System;
using System.Drawing;
using System.Windows.Forms;
using Text2Speech2TextApp.Core;

namespace Text2Speech2TextApp
{
    /// <summary>
    /// Code-behind for the main application form.
    /// Demonstrates:
    /// - Abstraction & Polymorphism: referencing services via interfaces (ITextToSpeechService, ISpeechToTextService).
    /// - Event-Driven Programming: handling custom events raised by background engines.
    /// - Encapsulation: orchestrating GUI state based on engine states.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ITextToSpeechService _ttsService;
        private readonly ISpeechToTextService _sttService;

        public MainForm()
        {
            InitializeComponent();

            _ttsService = new TextToSpeechService();
            _sttService = new SpeechToTextService();

            // Wire up UI events
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;

            // Wire up TTS UI Controls
            btnTTSSpeak.Click += BtnTTSSpeak_Click;
            btnTTSPause.Click += BtnTTSPause_Click;
            btnTTSResume.Click += BtnTTSResume_Click;
            btnTTSStop.Click += BtnTTSStop_Click;
            trackTTSVolume.Scroll += TrackTTSVolume_Scroll;
            trackTTSRate.Scroll += TrackTTSRate_Scroll;

            // Wire up STT UI Controls
            btnSTTStart.Click += BtnSTTStart_Click;
            btnSTTStop.Click += BtnSTTStop_Click;
            btnSTTClear.Click += BtnSTTClear_Click;
            btnSTTCopy.Click += BtnSTTCopy_Click;

            // Wire up Utility UI Controls
            btnLogsClear.Click += BtnLogsClear_Click;

            // Apply modern flat hover transitions to buttons
            ApplyButtonHover(btnTTSSpeak, Color.FromArgb(59, 130, 246), Color.FromArgb(29, 78, 216)); // Blue
            ApplyButtonHover(btnTTSPause, Color.FromArgb(107, 114, 128), Color.FromArgb(75, 85, 99)); // Grey
            ApplyButtonHover(btnTTSResume, Color.FromArgb(107, 114, 128), Color.FromArgb(75, 85, 99)); // Grey
            ApplyButtonHover(btnTTSStop, Color.FromArgb(239, 68, 68), Color.FromArgb(185, 28, 28)); // Red

            ApplyButtonHover(btnSTTStart, Color.FromArgb(16, 185, 129), Color.FromArgb(4, 120, 87)); // Green
            ApplyButtonHover(btnSTTStop, Color.FromArgb(239, 68, 68), Color.FromArgb(185, 28, 28)); // Red
            ApplyButtonHover(btnSTTClear, Color.FromArgb(75, 85, 99), Color.FromArgb(55, 65, 81)); // Grey
            ApplyButtonHover(btnSTTCopy, Color.FromArgb(75, 85, 99), Color.FromArgb(55, 65, 81)); // Grey
            ApplyButtonHover(btnLogsClear, Color.FromArgb(75, 85, 99), Color.FromArgb(55, 65, 81)); // Grey

            // Subscribe to Custom OOP Events raised by services
            _ttsService.StateChanged += TtsService_StateChanged;
            _ttsService.SpeakCompleted += TtsService_SpeakCompleted;
            _ttsService.SpeakProgress += TtsService_SpeakProgress;

            _sttService.TextRecognized += SttService_TextRecognized;
            _sttService.StateChanged += SttService_StateChanged;
            _sttService.ErrorOccurred += SttService_ErrorOccurred;
            _sttService.AudioLevelUpdated += SttService_AudioLevelUpdated;
        }

        #region Form Lifecycle Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            Log("System initialized. Loading speech capabilities...");

            // 1. Load Installed Voices for TTS
            try
            {
                var voices = _ttsService.GetInstalledVoices();
                if (voices.Count > 0)
                {
                    cmbTTSVoice.Items.Clear();
                    foreach (var voice in voices)
                    {
                        cmbTTSVoice.Items.Add(voice);
                    }
                    cmbTTSVoice.SelectedIndex = 0;
                    _ttsService.SetVoice(voices[0]);
                    Log($"Loaded {voices.Count} system voice(s).");
                }
                else
                {
                    cmbTTSVoice.Items.Add("No voices found");
                    cmbTTSVoice.SelectedIndex = 0;
                    btnTTSSpeak.Enabled = false;
                    Log("Warning: No text-to-speech voices were detected.", "WARNING");
                }
            }
            catch (Exception ex)
            {
                Log($"Error loading voices: {ex.Message}", "ERROR");
            }

            // 2. Load Speech Recognition Locales (Guarantee both tr-TR and en-US are displayed and show their install status)
            cmbSTTLanguage.Items.Clear();
            var recognizers = _sttService.GetInstalledRecognizers();
            
            bool enInstalled = recognizers.Contains("en-US");
            bool trInstalled = recognizers.Contains("tr-TR");

            cmbSTTLanguage.Items.Add("en-US" + (enInstalled ? " (Installed)" : " (Not Installed)"));
            cmbSTTLanguage.Items.Add("tr-TR" + (trInstalled ? " (Installed)" : " (Not Installed)"));

            foreach (var locale in recognizers)
            {
                if (locale != "en-US" && locale != "tr-TR")
                {
                    cmbSTTLanguage.Items.Add(locale + " (Installed)");
                }
            }

            // Select installed English by default, fallback to installed Turkish, otherwise first
            int defaultIdx = enInstalled ? 0 : (trInstalled ? 1 : 0);
            cmbSTTLanguage.SelectedIndex = defaultIdx;
            Log("Speech-to-Text languages configured. Status displayed next to each language.");

            // 3. Sync Sliders and Labels with initial service properties
            trackTTSVolume.Value = _ttsService.Volume;
            lblTTSVolume.Text = $"Volume: {trackTTSVolume.Value}%";

            trackTTSRate.Value = _ttsService.Rate;
            lblTTSRate.Text = $"Speed: {trackTTSRate.Value}";

            UpdateUIState(false, false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ttsService.Dispose();
            _sttService.Dispose();
        }

        #endregion

        #region Text-to-Speech (TTS) Event Handlers

        private void BtnTTSSpeak_Click(object sender, EventArgs e)
        {
            if (cmbTTSVoice.SelectedItem != null && cmbTTSVoice.SelectedItem.ToString() != "No voices found")
            {
                _ttsService.SetVoice(cmbTTSVoice.SelectedItem.ToString());
            }
            Log($"Initiating speech synthesis. Rate: {_ttsService.Rate}, Volume: {_ttsService.Volume}");
            _ttsService.SpeakAsync(txtTTSInput.Text);
            UpdateUIState(true, _sttService.IsListening);
        }

        private void BtnTTSPause_Click(object sender, EventArgs e)
        {
            _ttsService.Pause();
            UpdateUIState(true, _sttService.IsListening);
        }

        private void BtnTTSResume_Click(object sender, EventArgs e)
        {
            _ttsService.Resume();
            UpdateUIState(true, _sttService.IsListening);
        }

        private void BtnTTSStop_Click(object sender, EventArgs e)
        {
            _ttsService.Stop();
            UpdateUIState(false, _sttService.IsListening);
        }

        private void TrackTTSVolume_Scroll(object sender, EventArgs e)
        {
            _ttsService.Volume = trackTTSVolume.Value;
            lblTTSVolume.Text = $"Volume: {trackTTSVolume.Value}%";
        }

        private void TrackTTSRate_Scroll(object sender, EventArgs e)
        {
            _ttsService.Rate = trackTTSRate.Value;
            lblTTSRate.Text = $"Speed: {trackTTSRate.Value}";
        }

        // TTS Engine Events
        private void TtsService_StateChanged(object sender, TextToSpeechStateEventArgs e)
        {
            ExecuteOnUIThread(() =>
            {
                Log(e.Message);
                if (e.IsPaused)
                {
                    btnTTSPause.Enabled = false;
                    btnTTSResume.Enabled = true;
                }
                else
                {
                    btnTTSPause.Enabled = _ttsService.IsSpeaking;
                    btnTTSResume.Enabled = false;
                }
            });
        }

        private void TtsService_SpeakCompleted(object sender, TextToSpeechCompletedEventArgs e)
        {
            ExecuteOnUIThread(() =>
            {
                if (e.Success)
                {
                    Log("TTS: Completed speaking successfully.");
                }
                else if (!string.IsNullOrEmpty(e.ErrorMessage))
                {
                    Log($"TTS: Completed with error: {e.ErrorMessage}", "ERROR");
                }
                else
                {
                    Log("TTS: Speech synthesis stopped.");
                }
                UpdateUIState(false, _sttService.IsListening);
            });
        }

        private void TtsService_SpeakProgress(object sender, TextToSpeechProgressEventArgs e)
        {
            ExecuteOnUIThread(() =>
            {
                txtTTSInput.Select(e.CharacterPosition, e.CharacterCount);
                txtTTSInput.SelectionBackColor = Color.FromArgb(59, 130, 246);
                txtTTSInput.SelectionColor = Color.White;
                txtTTSInput.DeselectAll();
            });
        }

        #endregion

        #region Speech-to-Text (STT) Event Handlers

        private void BtnSTTStart_Click(object sender, EventArgs e)
        {
            string selectedItem = cmbSTTLanguage.SelectedItem?.ToString() ?? "en-US";
            string selectedLocale = selectedItem.Split(' ')[0]; // Extract "en-US" or "tr-TR" from display string
            Log($"Initializing speech recognition engine for language: {selectedLocale}");
            _sttService.StartListeningAsync(selectedLocale);
        }

        private void BtnSTTStop_Click(object sender, EventArgs e)
        {
            Log("Stopping speech recognition listener...");
            _sttService.StopListening();
        }

        private void BtnSTTClear_Click(object sender, EventArgs e)
        {
            txtSTTOutput.Clear();
            Log("Cleared transcript textbox.");
        }

        private void BtnSTTCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSTTOutput.Text))
            {
                Clipboard.SetText(txtSTTOutput.Text);
                Log("Transcript text copied to clipboard.");
                MessageBox.Show("Transcript copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string _currentHypothesis = "";

        // STT Engine Events
        private void SttService_TextRecognized(object sender, Core.SpeechRecognizedEventArgs e)
        {
            ExecuteOnUIThread(() =>
            {
                if (e.IsFinal)
                {
                    _currentHypothesis = "";
                    txtSTTOutput.AppendText(e.Text + " ");
                    lblSTTStatus.Text = $"Status: Active | Heard: {e.Text}";
                    lblSTTStatus.ForeColor = Color.FromArgb(16, 185, 129); // Green
                    Log($"[STT FINAL] Heard: \"{e.Text}\" (Confidence: {e.Confidence:P0})");
                }
                else
                {
                    _currentHypothesis = e.Text;
                    lblSTTStatus.ForeColor = Color.FromArgb(245, 158, 11); // Yellow/Orange
                }
            });
        }

        private void SttService_AudioLevelUpdated(object sender, int level)
        {
            ExecuteOnUIThread(() =>
            {
                int barCount = level / 10;
                string bar = new string('█', barCount) + new string('░', 10 - barCount);
                
                string liveGuess = string.IsNullOrEmpty(_currentHypothesis) ? "Waiting for speech..." : $"\"... {_currentHypothesis}\"";
                
                lblSTTStatus.Text = $"Status: Listening...\n" +
                                    $"Mic Input: {bar} ({level}%)\n" +
                                    $"Live Guess: {liveGuess}";
            });
        }

        private void SttService_StateChanged(object sender, SpeechRecognitionStateEventArgs e)
        {
            ExecuteOnUIThread(() =>
            {
                Log($"STT State: {e.StatusMessage}");
                if (e.IsListening)
                {
                    lblSTTStatus.Text = $"Status: Listening ({e.StatusMessage})";
                    lblSTTStatus.ForeColor = Color.FromArgb(16, 185, 129); // Green
                    UpdateUIState(_ttsService.IsSpeaking, true);
                }
                else
                {
                    lblSTTStatus.Text = $"Status: Offline ({e.StatusMessage})";
                    lblSTTStatus.ForeColor = Color.FromArgb(239, 68, 68); // Red
                    UpdateUIState(_ttsService.IsSpeaking, false);
                }
            });
        }

        private void SttService_ErrorOccurred(object sender, SpeechRecognitionErrorEventArgs e)
        {
            ExecuteOnUIThread(() =>
            {
                Log($"STT Error: {e.ErrorMessage}", "ERROR");
                MessageBox.Show(e.ErrorMessage, "Speech Recognition Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
        }

        #endregion

        #region Helper Methods

        private void UpdateUIState(bool isSpeaking, bool isListening)
        {
            btnTTSSpeak.Enabled = !isSpeaking;
            btnTTSPause.Enabled = isSpeaking;
            btnTTSResume.Enabled = false;
            btnTTSStop.Enabled = isSpeaking;
            cmbTTSVoice.Enabled = !isSpeaking;

            btnSTTStart.Enabled = !isListening;
            btnSTTStop.Enabled = isListening;
            cmbSTTLanguage.Enabled = !isListening;
        }

        private void ExecuteOnUIThread(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private void Log(string message, string level = "INFO")
        {
            ExecuteOnUIThread(() =>
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                string logLine = $"[{timestamp}] [{level}] {message}{Environment.NewLine}";

                int start = txtLogs.TextLength;
                txtLogs.AppendText(logLine);
                int end = txtLogs.TextLength;

                txtLogs.Select(start, end - start);
                if (level == "ERROR")
                {
                    txtLogs.SelectionColor = Color.FromArgb(239, 68, 68); // Red
                    txtLogs.SelectionFont = new Font(txtLogs.Font, FontStyle.Bold);
                }
                else if (level == "WARNING")
                {
                    txtLogs.SelectionColor = Color.FromArgb(245, 158, 11); // Amber
                    txtLogs.SelectionFont = new Font(txtLogs.Font, FontStyle.Bold);
                }
                else if (level.StartsWith("[STT"))
                {
                    txtLogs.SelectionColor = Color.FromArgb(16, 185, 129); // Green
                }
                else
                {
                    txtLogs.SelectionColor = Color.FromArgb(148, 163, 184); // Muted slate
                }

                txtLogs.DeselectAll();
                txtLogs.ScrollToCaret();
            });
        }

        private void BtnLogsClear_Click(object sender, EventArgs e)
        {
            txtLogs.Clear();
            Log("Logs cleared.");
        }

        private void ApplyButtonHover(Button btn, Color normalColor, Color hoverColor)
        {
            btn.BackColor = normalColor;
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = normalColor;
        }

        #endregion
    }
}
