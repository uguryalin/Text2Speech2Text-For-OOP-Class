using System;

namespace Text2Speech2TextApp.Core
{
    /// <summary>
    /// Event arguments for changes in TTS engine state.
    /// </summary>
    public class TextToSpeechStateEventArgs : EventArgs
    {
        public string Message { get; }
        public bool IsPaused { get; }

        public TextToSpeechStateEventArgs(string message, bool isPaused)
        {
            Message = message;
            IsPaused = isPaused;
        }
    }

    /// <summary>
    /// Event arguments for completion of speech synthesis.
    /// </summary>
    public class TextToSpeechCompletedEventArgs : EventArgs
    {
        public bool Success { get; }
        public string ErrorMessage { get; }

        public TextToSpeechCompletedEventArgs(bool success, string errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }

    /// <summary>
    /// Event arguments tracking the word-by-word progress of TTS.
    /// </summary>
    public class TextToSpeechProgressEventArgs : EventArgs
    {
        public string CurrentWord { get; }
        public int CharacterPosition { get; }
        public int CharacterCount { get; }

        public TextToSpeechProgressEventArgs(string currentWord, int characterPosition, int characterCount)
        {
            CurrentWord = currentWord;
            CharacterPosition = characterPosition;
            CharacterCount = characterCount;
        }
    }

    /// <summary>
    /// Event arguments containing recognized speech text.
    /// </summary>
    public class SpeechRecognizedEventArgs : EventArgs
    {
        public string Text { get; }
        public float Confidence { get; }
        public bool IsFinal { get; }

        public SpeechRecognizedEventArgs(string text, float confidence, bool isFinal)
        {
            Text = text;
            Confidence = confidence;
            IsFinal = isFinal;
        }
    }

    /// <summary>
    /// Event arguments for STT engine state transitions.
    /// </summary>
    public class SpeechRecognitionStateEventArgs : EventArgs
    {
        public bool IsListening { get; }
        public string StatusMessage { get; }

        public SpeechRecognitionStateEventArgs(bool isListening, string statusMessage)
        {
            IsListening = isListening;
            StatusMessage = statusMessage;
        }
    }

    /// <summary>
    /// Event arguments for speech recognition error occurrences.
    /// </summary>
    public class SpeechRecognitionErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; }
        public Exception Exception { get; }

        public SpeechRecognitionErrorEventArgs(string errorMessage, Exception exception = null)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
