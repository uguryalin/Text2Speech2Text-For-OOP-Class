using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace Text2Speech2TextApp.Core
{
    /// <summary>
    /// Implements Text-to-Speech operations using Windows Speech Synthesis.
    /// Demonstrates encapsulation and polymorphic event raising.
    /// </summary>
    public class TextToSpeechService : ITextToSpeechService
    {
        private readonly SpeechSynthesizer _synthesizer;
        private bool _disposed = false;

        public event EventHandler<TextToSpeechStateEventArgs> StateChanged;
        public event EventHandler<TextToSpeechCompletedEventArgs> SpeakCompleted;
        public event EventHandler<TextToSpeechProgressEventArgs> SpeakProgress;

        public TextToSpeechService()
        {
            _synthesizer = new SpeechSynthesizer();
            
            // Subscribing to internal events to raise clean, custom service events
            _synthesizer.StateChanged += OnSynthesizerStateChanged;
            _synthesizer.SpeakCompleted += OnSynthesizerSpeakCompleted;
            _synthesizer.SpeakProgress += OnSynthesizerSpeakProgress;
        }

        public int Volume
        {
            get => _synthesizer.Volume;
            set => _synthesizer.Volume = Math.Clamp(value, 0, 100);
        }

        public int Rate
        {
            get => _synthesizer.Rate;
            set => _synthesizer.Rate = Math.Clamp(value, -10, 10);
        }

        public bool IsSpeaking => _synthesizer.State == SynthesizerState.Speaking;

        public string CurrentVoice => _synthesizer.Voice?.Name ?? "None";

        public List<string> GetInstalledVoices()
        {
            var voices = new List<string>();
            foreach (var voice in _synthesizer.GetInstalledVoices())
            {
                if (voice.Enabled)
                {
                    voices.Add(voice.VoiceInfo.Name);
                }
            }
            return voices;
        }

        public void SetVoice(string voiceName)
        {
            try
            {
                _synthesizer.SelectVoice(voiceName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to select voice: {voiceName}.", ex);
            }
        }

        public void SpeakAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;
            
            if (_synthesizer.State == SynthesizerState.Paused)
            {
                _synthesizer.Resume();
            }
            _synthesizer.SpeakAsync(text);
        }

        public void Pause()
        {
            if (_synthesizer.State == SynthesizerState.Speaking)
            {
                _synthesizer.Pause();
            }
        }

        public void Resume()
        {
            if (_synthesizer.State == SynthesizerState.Paused)
            {
                _synthesizer.Resume();
            }
        }

        public void Stop()
        {
            _synthesizer.SpeakAsyncCancelAll();
            
            // If the synthesizer was paused, resuming after canceling clears its state
            if (_synthesizer.State == SynthesizerState.Paused)
            {
                _synthesizer.Resume();
            }
        }

        private void OnSynthesizerStateChanged(object sender, StateChangedEventArgs e)
        {
            bool isPaused = e.State == SynthesizerState.Paused;
            StateChanged?.Invoke(this, new TextToSpeechStateEventArgs($"TTS engine changed state to: {e.State}", isPaused));
        }

        private void OnSynthesizerSpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            bool success = e.Error == null && !e.Cancelled;
            string errMsg = e.Error?.Message;
            SpeakCompleted?.Invoke(this, new TextToSpeechCompletedEventArgs(success, errMsg));
        }

        private void OnSynthesizerSpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            SpeakProgress?.Invoke(this, new TextToSpeechProgressEventArgs(e.Text, e.CharacterPosition, e.CharacterCount));
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
                    _synthesizer.StateChanged -= OnSynthesizerStateChanged;
                    _synthesizer.SpeakCompleted -= OnSynthesizerSpeakCompleted;
                    _synthesizer.SpeakProgress -= OnSynthesizerSpeakProgress;
                    _synthesizer.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
