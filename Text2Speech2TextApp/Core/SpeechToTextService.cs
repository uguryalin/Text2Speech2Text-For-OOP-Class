using System;
using System.Collections.Generic;
using System.Globalization;
using System.Speech.Recognition;

namespace Text2Speech2TextApp.Core
{
    /// <summary>
    /// Implements Speech-to-Text operations using Windows Speech Recognition.
    /// Handles microphone initialization, dictation grammar, and events.
    /// Demonstrates encapsulation and robustness.
    /// </summary>
    public class SpeechToTextService : ISpeechToTextService
    {
        private SpeechRecognitionEngine _recognizer;
        private bool _isListening = false;
        private bool _disposed = false;

        public event EventHandler<Core.SpeechRecognizedEventArgs> TextRecognized;
        public event EventHandler<SpeechRecognitionStateEventArgs> StateChanged;
        public event EventHandler<SpeechRecognitionErrorEventArgs> ErrorOccurred;
        public event EventHandler<int> AudioLevelUpdated;

        public bool IsListening => _isListening;

        public List<string> GetInstalledRecognizers()
        {
            var recognizers = new List<string>();
            try
            {
                foreach (var reco in SpeechRecognitionEngine.InstalledRecognizers())
                {
                    recognizers.Add(reco.Culture.Name);
                }
            }
            catch (Exception ex)
            {
                // Fallback if no engines are installed or SAPI fails to initialize
                System.Diagnostics.Debug.WriteLine($"Failed to retrieve recognizers: {ex.Message}");
            }
            return recognizers;
        }

        public void StartListeningAsync(string cultureName = "en-US")
        {
            if (_isListening) return;

            try
            {
                if (_recognizer != null)
                {
                    StopAndCleanupRecognizer();
                }

                CultureInfo culture;
                try
                {
                    culture = new CultureInfo(cultureName);
                    _recognizer = new SpeechRecognitionEngine(culture);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"The Windows Speech Recognition engine for language '{cultureName}' is not installed on this PC.\n\n" +
                        "How to Fix:\n" +
                        "1. Open Windows Settings (Ayarlar).\n" +
                        "2. Go to Time & Language -> Language & Region (Zaman ve Dil -> Dil ve Bölge).\n" +
                        "3. Click 'Add a language' (Dil Ekle) and choose Turkish (Türkçe) or English (İngilizce).\n" +
                        "4. Click options next to the language and download the 'Speech' (Konuşma) feature package.\n" +
                        "5. Restart this application.", ex);
                }

                // Configure default audio device input. May throw if no microphone is found.
                try
                {
                    _recognizer.SetInputToDefaultAudioDevice();
                }
                catch (InvalidOperationException ioEx)
                {
                    throw new InvalidOperationException("No audio input device (microphone) detected. Please connect a microphone and try again.", ioEx);
                }

                // Load Dictation Grammar for general speech recognition
                DictationGrammar grammar = new DictationGrammar();
                _recognizer.LoadGrammar(grammar);

                // Wire up speech engine event handlers
                _recognizer.SpeechRecognized += OnSpeechRecognized;
                _recognizer.SpeechHypothesized += OnSpeechHypothesized;
                _recognizer.RecognizeCompleted += OnRecognizeCompleted;
                _recognizer.AudioLevelUpdated += OnAudioLevelUpdated;

                // Start continuous asynchronous speech recognition
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);

                _isListening = true;
                StateChanged?.Invoke(this, new SpeechRecognitionStateEventArgs(true, $"Listening in {cultureName}... Speak now."));
            }
            catch (Exception ex)
            {
                _isListening = false;
                ErrorOccurred?.Invoke(this, new SpeechRecognitionErrorEventArgs(ex.Message, ex));
                StateChanged?.Invoke(this, new SpeechRecognitionStateEventArgs(false, "Speech recognition failed to start."));
            }
        }

        public void StopListening()
        {
            if (!_isListening || _recognizer == null) return;

            try
            {
                // Request a clean stop
                _recognizer.RecognizeAsyncStop();
                _isListening = false;
                StateChanged?.Invoke(this, new SpeechRecognitionStateEventArgs(false, "Stopping listening engine..."));
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, new SpeechRecognitionErrorEventArgs($"Error stopping speech recognition: {ex.Message}", ex));
            }
        }

        private void OnSpeechRecognized(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            if (e.Result != null && !string.IsNullOrWhiteSpace(e.Result.Text))
            {
                TextRecognized?.Invoke(this, new Core.SpeechRecognizedEventArgs(e.Result.Text, e.Result.Confidence, true));
            }
        }

        private void OnSpeechHypothesized(object sender, System.Speech.Recognition.SpeechHypothesizedEventArgs e)
        {
            if (e.Result != null && !string.IsNullOrWhiteSpace(e.Result.Text))
            {
                TextRecognized?.Invoke(this, new Core.SpeechRecognizedEventArgs(e.Result.Text, e.Result.Confidence, false));
            }
        }

        private void OnAudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            AudioLevelUpdated?.Invoke(this, e.AudioLevel);
        }

        private void OnRecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            _isListening = false;
            string status = "Listening stopped.";
            if (e.Error != null)
            {
                status = $"Error: {e.Error.Message}";
                ErrorOccurred?.Invoke(this, new SpeechRecognitionErrorEventArgs(e.Error.Message, e.Error));
            }
            else if (e.Cancelled)
            {
                status = "Listening cancelled.";
            }
            StateChanged?.Invoke(this, new SpeechRecognitionStateEventArgs(false, status));
        }

        private void StopAndCleanupRecognizer()
        {
            if (_recognizer != null)
            {
                try
                {
                    _recognizer.SpeechRecognized -= OnSpeechRecognized;
                    _recognizer.SpeechHypothesized -= OnSpeechHypothesized;
                    _recognizer.RecognizeCompleted -= OnRecognizeCompleted;
                    _recognizer.AudioLevelUpdated -= OnAudioLevelUpdated;
                    _recognizer.Dispose();
                }
                catch { /* Suppress potential SAPI exceptions during cleanup */ }
                _recognizer = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopAndCleanupRecognizer();
                }
                _disposed = true;
            }
        }
    }
}
