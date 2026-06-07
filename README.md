# Text ⇄ Speech ⇄ Text Studio (OOP Class Project)

This project is a Windows Forms application developed in C# (.NET 9.0) designed as an educational project for an **Object-Oriented Programming (OOP)** class. It integrates Windows native speech capabilities using the `System.Speech` library to perform bidirectional speech services: **Text-to-Speech (TTS)** and **Speech-to-Text (STT)**.

*Bu projenin Türkçe açıklaması için [aşağı kaydırınız](#türkçe-nesne-yönelimli-programlama-metin-konuşma-metin-stüdyosu).*

---

## Table of Contents / İçindekiler
1. [English Version](#english-version)
   - [Features](#features)
   - [OOP Principles Implemented](#oop-principles-implemented)
   - [Project Structure](#project-structure)
   - [Requirements & Setup](#requirements--setup)
   - [How to Build and Run](#how-to-build-and-run)
2. [Türkçe Sürüm](#türkçe-nesne-yönelimli-programlama-metin-konuşma-metin-stüdyosu)
   - [Özellikler](#özellikler)
   - [Uygulanan NYP İlkeleri](#uygulanan-nyp-ilkeleri)
   - [Proje Yapısı](#proje-yapısı)
   - [Gereksinimler ve Kurulum](#gereksinimler-ve-kurulum)
   - [Derleme ve Çalıştırma](#derleme-ve-çalıştırma)

---

# English Version

## Features
- **Text-to-Speech (TTS)**: Synthesizes input text into audio. Supports pausing, resuming, stopping, adjusting volume (0-100), adjusting rate/speed (-10 to 10), and choosing between different installed voices.
- **Word Highlighting**: Automatically highlights each word in the input box as it is being spoken in real-time.
- **Speech-to-Text (STT)**: Continuous speech recognition using the default microphone. Transcribes spoken sentences into text.
- **Hypothesis Visualizer**: Displays intermediate speech recognition guesses in real-time, matching modern voice dictation software.
- **OOP Event Console**: A live logging panel at the bottom of the window displaying every system state transition, text recognized, and engine event.
- **Modern UI**: A responsive, dark-mode flat user interface.

---

## OOP Principles Implemented

This project is structured specifically to showcase academic OOP concepts in production-grade C# code:

### 1. Abstraction
Defined through interfaces in [Core/ISpeechServices.cs](file:///d:/Desktop/UGUR/oop%20projects/Text2Speech2Text-For-OOP-Class/Text2Speech2TextApp/Core/ISpeechServices.cs). The user interface (`MainForm`) does not interact directly with concrete SAPI implementations. Instead, it relies on contract interfaces:
- `ITextToSpeechService`: Defines standard synthesis controls, voice info retrieval, and events.
- `ISpeechToTextService`: Defines recording and recognition controls, locales, and speech events.

### 2. Encapsulation
- The implementation details of `System.Speech.Synthesis` and `System.Speech.Recognition` are completely hidden inside their respective service classes (`TextToSpeechService` and `SpeechToTextService`).
- Internal states, event hookups, and low-level resource cleanups (COM disposals) are managed internally.
- Properties like `Volume` and `Rate` utilize validation logic (clamping values) within getters and setters to protect internal state consistency.
- Voice parameters are wrapped cleanly in the [Models/VoiceInfoModel.cs](file:///d:/Desktop/UGUR/oop%20projects/Text2Speech2Text-For-OOP-Class/Text2Speech2TextApp/Models/VoiceInfoModel.cs) data transfer object.

### 3. Polymorphism
- **Interface Polymorphism**: The `MainForm` declares private fields referencing the interfaces:
  ```csharp
  private readonly ITextToSpeechService _ttsService;
  private readonly ISpeechToTextService _sttService;
  ```
  But instantiates concrete service classes at runtime. This allows switching engines (e.g., to cloud API speech engines) without modifying a single line of GUI code.
- **Method Overriding**: Custom string formatting is achieved by overriding `.ToString()` in `VoiceInfoModel`.

### 4. Event-Driven Programming
Speech engines operate asynchronously on background threads to avoid freezing the UI. They communicate state changes back to the main thread using custom delegates and Event Args in [Core/SpeechEventArgs.cs](file:///d:/Desktop/UGUR/oop%20projects/Text2Speech2Text-For-OOP-Class/Text2Speech2TextApp/Core/SpeechEventArgs.cs):
- `TextRecognized`: Fired when speech is heard (both intermediate/final).
- `StateChanged`: Fired when engines change state (speaking, listening, idle).
- `ErrorOccurred`: Emitted when microphone access is denied or voice packages are missing.

---

## Project Structure
```text
Text2Speech2Text-For-OOP-Class/
│
├── nuget.config                    # Local package source configuration
├── Text2Speech2TextApp.sln         # Solution file
└── Text2Speech2TextApp/
    ├── Text2Speech2TextApp.csproj  # WinForms .NET 9.0 project definition
    ├── Program.cs                  # Application entry point
    ├── MainForm.cs                 # Form code-behind (event bindings)
    ├── MainForm.Designer.cs        # UI visual layouts & styles
    │
    ├── Core/
    │   ├── ISpeechServices.cs      # OOP Abstraction interfaces
    │   ├── SpeechEventArgs.cs      # Custom OOP Event Args
    │   ├── TextToSpeechService.cs  # TTS implementation
    │   └── SpeechToTextService.cs  # STT implementation
    │
    └── Models/
        └── VoiceInfoModel.cs       # Voice details encapsulation
```

---

## Requirements & Setup
1. **Operating System**: Windows 10 or 11 (required for Windows Speech API - SAPI).
2. **Framework**: .NET SDK 9.0.
3. **Hardware**: A working microphone for Speech-to-Text.
4. **Speech Packages**: Windows Speech Recognition must be enabled. To recognize Turkish speech, you should install the Turkish language pack with speech capabilities in Windows Settings.

---

## How to Build and Run

1. Open a terminal (PowerShell or Command Prompt) in the project root directory.
2. Build the project:
   ```powershell
   dotnet build
   ```
3. Run the application:
   ```powershell
   dotnet run --project Text2Speech2TextApp/Text2Speech2TextApp.csproj
   ```

---

# Türkçe Sürüm: Nesne Yönelimli Programlama Metin ⇄ Konuşma ⇄ Metin Stüdyosu

Bu proje, **Nesne Yönelimli Programlama (NYP / OOP)** dersi için eğitim amaçlı geliştirilmiş, C# (.NET 9.0) tabanlı bir Windows Forms uygulamasıdır. Proje, Windows işletim sisteminin yerleşik konuşma yeteneklerini `System.Speech` kütüphanesini kullanarak çift yönlü olarak gerçekleştirir: **Metinden Konuşmaya (Text-to-Speech - TTS)** ve **Konuşmadan Metne (Speech-to-Text - STT)**.

---

## Özellikler
- **Metinden Konuşmaya (TTS)**: Girilen metni sese dönüştürür. Duraklatma (Pause), devam ettirme (Resume), durdurma (Stop), ses seviyesi ayarı (0-100), konuşma hızı ayarı (-10 ile 10 arası) ve sistemde kurulu sesler arasından seçim yapmayı destekler.
- **Kelime Vurgulama**: Konuşma devam ederken, o an telaffuz edilen kelimeyi giriş kutusunda eş zamanlı olarak seçerek vurgular.
- **Konuşmadan Metne (STT)**: Sistem varsayılan mikrofonunu kullanarak sürekli konuşma tanıma gerçekleştirir ve konuşulan cümleleri yazıya döker.
- **Tahmin İzleyici (Hypothesis Visualizer)**: Konuşma tanıma motorunun anlık ara tahminlerini (cümle tamamlanmadan önce) ekranda canlı olarak gösterir.
- **NYP Olay Konsolu**: Pencerenin alt kısmında yer alan ve sistem durumu değişikliklerini, algılanan konuşmaları ve motor olaylarını gerçek zamanlı gösteren canlı günlük panelidir.
- **Modern Arayüz**: Slate/Koyu renk temalı, duyarlı (responsive) bir modern WinForms arayüzü sunar.

---

## Uygulanan NYP İlkeleri

Bu proje, akademik NYP konseptlerini çalışan bir üretim kodunda göstermek üzere yapılandırılmıştır:

### 1. Soyutlama (Abstraction)
[Core/ISpeechServices.cs](file:///d:/Desktop/UGUR/oop%20projects/Text2Speech2Text-For-OOP-Class/Text2Speech2TextApp/Core/ISpeechServices.cs) dosyasındaki arayüzler (interface) ile tanımlanmıştır. Kullanıcı arayüzü (`MainForm`), doğrudan konuşma motorunun alt seviye COM detaylarıyla konuşmaz. Bunun yerine sözleşme arayüzlerini kullanır:
- `ITextToSpeechService`: Ses sentezleme kontrollerini, kurulu sesleri çekme metodunu ve olayları tanımlar.
- `ISpeechToTextService`: Ses tanıma, mikrofon kontrolleri ve ses olaylarını tanımlar.

### 2. Kapsülleme (Encapsulation)
- `System.Speech.Synthesis` ve `System.Speech.Recognition` nesnelerinin karmaşık çalışma mantığı, kendi sınıf dosyalarında (`TextToSpeechService` ve `SpeechToTextService`) tamamen gizlenmiştir.
- İç durumlar, alt olay abonelikleri ve alt seviye COM kaynaklarının temizliği (`IDisposable` yönetimi) sınıf içinde yönetilir.
- `Volume` ve `Rate` gibi özellikler (properties), alıcı (get) ve ayarlayıcılarında (set) veri sınırlandırması uygulayarak (`Math.Clamp`) sınıfın iç veri bütünlüğünü korur.
- Ses parametreleri [Models/VoiceInfoModel.cs](file:///d:/Desktop/UGUR/oop%20projects/Text2Speech2Text-For-OOP-Class/Text2Speech2TextApp/Models/VoiceInfoModel.cs) sınıfı içinde kapsüllenmiştir.

### 3. Çok Biçimlilik (Polymorphism)
- **Arayüz Çok Biçimliliği (Interface Polymorphism)**: `MainForm` arayüz referanslarını kullanır:
  ```csharp
  private readonly ITextToSpeechService _ttsService;
  private readonly ISpeechToTextService _sttService;
  ```
  Çalışma zamanında (runtime) ise somut (concrete) sınıflar örneklenir. Bu sayede, ileride bulut tabanlı bir API motoruna geçilmek istendiğinde GUI koduna hiç dokunmadan farklı bir motor sınıfı enjekte edilebilir.
- **Metot Ezme (Method Overriding)**: `VoiceInfoModel` sınıfında `.ToString()` metodu ezilerek özel bir metinsel çıktı formatı sağlanmıştır.

### 4. Olay Güdümlü Programlama (Event-Driven Programming)
Konuşma motorları arayüzün donmasını engellemek için arka planda (background thread) asenkron çalışır. Durum değişikliklerini ana arayüze [Core/SpeechEventArgs.cs](file:///d:/Desktop/UGUR/oop%20projects/Text2Speech2Text-For-OOP-Class/Text2Speech2TextApp/Core/SpeechEventArgs.cs) içindeki özel olay argümanlarını (Event Args) tetikleyerek iletirler:
- `TextRecognized`: Konuşma algılandığında tetiklenir (ara tahminler ve kesin sonuçlar için).
- `StateChanged`: Konuşma veya dinleme motorları durum değiştirdiğinde tetiklenir.
- `ErrorOccurred`: Mikrofon bulunamadığında veya ses paketleri eksik olduğunda hata mesajı fırlatır.

---

## Proje Yapısı
```text
Text2Speech2Text-For-OOP-Class/
│
├── nuget.config                    # Yerel paket kaynak yapılandırması
├── Text2Speech2TextApp.sln         # Çözüm (Solution) dosyası
└── Text2Speech2TextApp/
    ├── Text2Speech2TextApp.csproj  # WinForms .NET 9.0 Proje Tanımı
    ├── Program.cs                  # Uygulama Giriş Noktası (Main)
    ├── MainForm.cs                 # Arayüz Olay İlişkilendirmeleri (Code-behind)
    ├── MainForm.Designer.cs        # Arayüz Görsel Tasarım Kodları
    │
    ├── Core/
    │   ├── ISpeechServices.cs      # NYP Soyutlama Arayüzleri
    │   ├── SpeechEventArgs.cs      # Özel Olay Argüman Sınıfları
    │   ├── TextToSpeechService.cs  # TTS (Metinden Sese) Sınıfı
    │   └── SpeechToTextService.cs  # STT (Sesten Metne) Sınıfı
    │
    └── Models/
        └── VoiceInfoModel.cs       # Ses Bilgilerini Kapsülleyen Model Sınıfı
```

---

## Gereksinimler ve Kurulum
1. **İşletim Sistemi**: Windows 10 veya Windows 11 (Windows Speech API - SAPI kullanımı için zorunludur).
2. **Geliştirme Kiti**: .NET SDK 9.0.
3. **Donanım**: Ses kaydı için çalışan bir mikrofon.
4. **Konuşma Paketleri**: Windows Ses Tanıma aktif olmalıdır. Türkçe konuşma tanıyabilmek için Windows Ayarları üzerinden "Zaman ve Dil -> Konuşma" kısmından Türkçe dil konuşma paketinin yüklü olması gerekir.

---

## Derleme ve Çalıştırma

1. Projenin kök dizininde bir uçbirim (PowerShell veya Komut İstemi) açın.
2. Projeyi derleyin:
   ```powershell
   dotnet build
   ```
3. Uygulamayı çalıştırın:
   ```powershell
   dotnet run --project Text2Speech2TextApp/Text2Speech2TextApp.csproj
   ```
