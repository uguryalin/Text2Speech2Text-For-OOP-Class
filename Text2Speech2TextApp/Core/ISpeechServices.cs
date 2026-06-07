using System;
using System.Collections.Generic;

namespace Text2Speech2TextApp.Core
{
    /// <summary>
    /// Abstraction for Text-to-Speech (TTS) operations.
    /// Demonstrates encapsulation and abstraction principles.
    /// </summary>
    public interface ITextToSpeechService : IDisposable
    {
        int Volume { get; set; } // 0 - 100
        int Rate { get; set; }   // -10 - 10
        bool IsSpeaking { get; }
        string CurrentVoice { get; }

        List<string> GetInstalledVoices();
        void SetVoice(string voiceName);
        void SpeakAsync(string text);
        void Pause();
        void Resume();
        void Stop();

        event EventHandler<TextToSpeechStateEventArgs> StateChanged;
        event EventHandler<TextToSpeechCompletedEventArgs> SpeakCompleted;
        event EventHandler<TextToSpeechProgressEventArgs> SpeakProgress;
    }

    /// <summary>
    /// Abstraction for Speech-to-Text (STT) operations.
    /// Demonstrates encapsulation and abstraction principles.
    /// </summary>
    public interface ISpeechToTextService : IDisposable
    {
        bool IsListening { get; }
        List<string> GetInstalledRecognizers();
        void StartListeningAsync(string cultureName = "en-US");
        void StopListening();

        event EventHandler<SpeechRecognizedEventArgs> TextRecognized;
        event EventHandler<SpeechRecognitionStateEventArgs> StateChanged;
        event EventHandler<SpeechRecognitionErrorEventArgs> ErrorOccurred;
        event EventHandler<int> AudioLevelUpdated;
    }
}
