namespace Text2Speech2TextApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeaderSub = new Label();
            lblHeaderTitle = new Label();
            pnlMain = new TableLayoutPanel();
            grpTTS = new GroupBox();
            pnlTTSInputWrap = new Panel();
            txtTTSInput = new RichTextBox();
            lblTTSInput = new Label();
            pnlTTSControls = new Panel();
            lblTTSRate = new Label();
            lblTTSVolume = new Label();
            lblTTSVoice = new Label();
            trackTTSRate = new TrackBar();
            trackTTSVolume = new TrackBar();
            cmbTTSVoice = new ComboBox();
            panelTTSButtons = new FlowLayoutPanel();
            btnTTSSpeak = new Button();
            btnTTSPause = new Button();
            btnTTSResume = new Button();
            btnTTSStop = new Button();
            grpSTT = new GroupBox();
            pnlSTTOutputWrap = new Panel();
            txtSTTOutput = new RichTextBox();
            lblSTTOutput = new Label();
            pnlSTTControls = new Panel();
            lblSTTStatus = new Label();
            lblSTTLang = new Label();
            cmbSTTLanguage = new ComboBox();
            panelSTTButtons = new FlowLayoutPanel();
            btnSTTStart = new Button();
            btnSTTStop = new Button();
            btnSTTClear = new Button();
            btnSTTCopy = new Button();
            panelLogs = new Panel();
            grpLogs = new GroupBox();
            btnLogsClear = new Button();
            txtLogs = new RichTextBox();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            grpTTS.SuspendLayout();
            pnlTTSInputWrap.SuspendLayout();
            pnlTTSControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackTTSRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackTTSVolume).BeginInit();
            panelTTSButtons.SuspendLayout();
            grpSTT.SuspendLayout();
            pnlSTTOutputWrap.SuspendLayout();
            pnlSTTControls.SuspendLayout();
            panelSTTButtons.SuspendLayout();
            panelLogs.SuspendLayout();
            grpLogs.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblHeaderSub);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1008, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSub
            // 
            lblHeaderSub.AutoSize = true;
            lblHeaderSub.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHeaderSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblHeaderSub.Location = new Point(19, 44);
            lblHeaderSub.Name = "lblHeaderSub";
            lblHeaderSub.Size = new Size(475, 17);
            lblHeaderSub.TabIndex = 1;
            lblHeaderSub.Text = "Object-Oriented Programming Speech Services Studio (C# .NET 9.0 System.Speech)";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblHeaderTitle.ForeColor = Color.FromArgb(248, 250, 252);
            lblHeaderTitle.Location = new Point(16, 9);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(351, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Text ⇄ Speech ⇄ Text Studio";
            // 
            // pnlMain
            // 
            pnlMain.ColumnCount = 2;
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlMain.Controls.Add(grpTTS, 0, 0);
            pnlMain.Controls.Add(grpSTT, 1, 0);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 80);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.RowCount = 1;
            pnlMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlMain.Size = new Size(1008, 430);
            pnlMain.TabIndex = 1;
            // 
            // grpTTS
            // 
            grpTTS.BackColor = Color.FromArgb(30, 41, 59);
            grpTTS.Controls.Add(pnlTTSControls);
            grpTTS.Controls.Add(panelTTSButtons);
            grpTTS.Controls.Add(pnlTTSInputWrap);
            grpTTS.Controls.Add(lblTTSInput);
            grpTTS.Dock = DockStyle.Fill;
            grpTTS.FlatStyle = FlatStyle.Flat;
            grpTTS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpTTS.ForeColor = Color.FromArgb(241, 245, 249);
            grpTTS.Location = new Point(13, 13);
            grpTTS.Name = "grpTTS";
            grpTTS.Padding = new Padding(10);
            grpTTS.Size = new Size(488, 404);
            grpTTS.TabIndex = 0;
            grpTTS.TabStop = false;
            grpTTS.Text = "Text-to-Speech (TTS)";
            // 
            // pnlTTSInputWrap
            // 
            pnlTTSInputWrap.BackColor = Color.FromArgb(71, 85, 105);
            pnlTTSInputWrap.Controls.Add(txtTTSInput);
            pnlTTSInputWrap.Dock = DockStyle.Top;
            pnlTTSInputWrap.Location = new Point(10, 47);
            pnlTTSInputWrap.Name = "pnlTTSInputWrap";
            pnlTTSInputWrap.Padding = new Padding(1);
            pnlTTSInputWrap.Size = new Size(468, 120);
            pnlTTSInputWrap.TabIndex = 1;
            // 
            // txtTTSInput
            // 
            txtTTSInput.BackColor = Color.FromArgb(15, 23, 42);
            txtTTSInput.BorderStyle = BorderStyle.None;
            txtTTSInput.Dock = DockStyle.Fill;
            txtTTSInput.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTTSInput.ForeColor = Color.FromArgb(241, 245, 249);
            txtTTSInput.Location = new Point(1, 1);
            txtTTSInput.Name = "txtTTSInput";
            txtTTSInput.Size = new Size(466, 118);
            txtTTSInput.TabIndex = 0;
            txtTTSInput.Text = "Hello! Welcome to the Object-Oriented Programming Speech Studio application. You can type or edit any text here to hear it spoken.";
            // 
            // lblTTSInput
            // 
            lblTTSInput.Dock = DockStyle.Top;
            lblTTSInput.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTTSInput.ForeColor = Color.FromArgb(148, 163, 184);
            lblTTSInput.Location = new Point(10, 30);
            lblTTSInput.Name = "lblTTSInput";
            lblTTSInput.Size = new Size(468, 17);
            lblTTSInput.TabIndex = 0;
            lblTTSInput.Text = "Text to Synthesize (Editable):";
            // 
            // pnlTTSControls
            // 
            pnlTTSControls.Controls.Add(lblTTSRate);
            pnlTTSControls.Controls.Add(lblTTSVolume);
            pnlTTSControls.Controls.Add(lblTTSVoice);
            pnlTTSControls.Controls.Add(trackTTSRate);
            pnlTTSControls.Controls.Add(trackTTSVolume);
            pnlTTSControls.Controls.Add(cmbTTSVoice);
            pnlTTSControls.Dock = DockStyle.Fill;
            pnlTTSControls.Location = new Point(10, 167);
            pnlTTSControls.Name = "pnlTTSControls";
            pnlTTSControls.Size = new Size(468, 177);
            pnlTTSControls.TabIndex = 2;
            // 
            // lblTTSRate
            // 
            lblTTSRate.AutoSize = true;
            lblTTSRate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTTSRate.ForeColor = Color.FromArgb(148, 163, 184);
            lblTTSRate.Location = new Point(3, 107);
            lblTTSRate.Name = "lblTTSRate";
            lblTTSRate.Size = new Size(58, 17);
            lblTTSRate.TabIndex = 4;
            lblTTSRate.Text = "Speed: 0";
            // 
            // lblTTSVolume
            // 
            lblTTSVolume.AutoSize = true;
            lblTTSVolume.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTTSVolume.ForeColor = Color.FromArgb(148, 163, 184);
            lblTTSVolume.Location = new Point(3, 56);
            lblTTSVolume.Name = "lblTTSVolume";
            lblTTSVolume.Size = new Size(90, 17);
            lblTTSVolume.TabIndex = 2;
            lblTTSVolume.Text = "Volume: 100%";
            // 
            // lblTTSVoice
            // 
            lblTTSVoice.AutoSize = true;
            lblTTSVoice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTTSVoice.ForeColor = Color.FromArgb(148, 163, 184);
            lblTTSVoice.Location = new Point(3, 10);
            lblTTSVoice.Name = "lblTTSVoice";
            lblTTSVoice.Size = new Size(87, 17);
            lblTTSVoice.TabIndex = 0;
            lblTTSVoice.Text = "Choose Voice:";
            // 
            // trackTTSRate
            // 
            trackTTSRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackTTSRate.Location = new Point(110, 105);
            trackTTSRate.Minimum = -10;
            trackTTSRate.Name = "trackTTSRate";
            trackTTSRate.Size = new Size(355, 45);
            trackTTSRate.TabIndex = 5;
            trackTTSRate.TickStyle = TickStyle.None;
            // 
            // trackTTSVolume
            // 
            trackTTSVolume.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackTTSVolume.Location = new Point(110, 54);
            trackTTSVolume.Maximum = 100;
            trackTTSVolume.Name = "trackTTSVolume";
            trackTTSVolume.Size = new Size(355, 45);
            trackTTSVolume.TabIndex = 3;
            trackTTSVolume.TickStyle = TickStyle.None;
            trackTTSVolume.Value = 100;
            // 
            // cmbTTSVoice
            // 
            cmbTTSVoice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTTSVoice.BackColor = Color.FromArgb(15, 23, 42);
            cmbTTSVoice.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTTSVoice.FlatStyle = FlatStyle.Flat;
            cmbTTSVoice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbTTSVoice.ForeColor = Color.FromArgb(241, 245, 249);
            cmbTTSVoice.FormattingEnabled = true;
            cmbTTSVoice.Location = new Point(110, 7);
            cmbTTSVoice.Name = "cmbTTSVoice";
            cmbTTSVoice.Size = new Size(355, 25);
            cmbTTSVoice.TabIndex = 1;
            // 
            // panelTTSButtons
            // 
            panelTTSButtons.Controls.Add(btnTTSSpeak);
            panelTTSButtons.Controls.Add(btnTTSPause);
            panelTTSButtons.Controls.Add(btnTTSResume);
            panelTTSButtons.Controls.Add(btnTTSStop);
            panelTTSButtons.Dock = DockStyle.Bottom;
            panelTTSButtons.Location = new Point(10, 344);
            panelTTSButtons.Name = "panelTTSButtons";
            panelTTSButtons.Size = new Size(468, 50);
            panelTTSButtons.TabIndex = 3;
            // 
            // btnTTSSpeak
            // 
            btnTTSSpeak.BackColor = Color.FromArgb(59, 130, 246);
            btnTTSSpeak.FlatAppearance.BorderSize = 0;
            btnTTSSpeak.FlatStyle = FlatStyle.Flat;
            btnTTSSpeak.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTTSSpeak.ForeColor = Color.White;
            btnTTSSpeak.Location = new Point(3, 3);
            btnTTSSpeak.Name = "btnTTSSpeak";
            btnTTSSpeak.Size = new Size(100, 40);
            btnTTSSpeak.TabIndex = 0;
            btnTTSSpeak.Text = "🔊 Speak";
            btnTTSSpeak.UseVisualStyleBackColor = false;
            // 
            // btnTTSPause
            // 
            btnTTSPause.BackColor = Color.FromArgb(107, 114, 128);
            btnTTSPause.FlatAppearance.BorderSize = 0;
            btnTTSPause.FlatStyle = FlatStyle.Flat;
            btnTTSPause.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTTSPause.ForeColor = Color.White;
            btnTTSPause.Location = new Point(109, 3);
            btnTTSPause.Name = "btnTTSPause";
            btnTTSPause.Size = new Size(100, 40);
            btnTTSPause.TabIndex = 1;
            btnTTSPause.Text = "⏸ Pause";
            btnTTSPause.UseVisualStyleBackColor = false;
            // 
            // btnTTSResume
            // 
            btnTTSResume.BackColor = Color.FromArgb(107, 114, 128);
            btnTTSResume.FlatAppearance.BorderSize = 0;
            btnTTSResume.FlatStyle = FlatStyle.Flat;
            btnTTSResume.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTTSResume.ForeColor = Color.White;
            btnTTSResume.Location = new Point(215, 3);
            btnTTSResume.Name = "btnTTSResume";
            btnTTSResume.Size = new Size(100, 40);
            btnTTSResume.TabIndex = 2;
            btnTTSResume.Text = "▶ Resume";
            btnTTSResume.UseVisualStyleBackColor = false;
            // 
            // btnTTSStop
            // 
            btnTTSStop.BackColor = Color.FromArgb(239, 68, 68);
            btnTTSStop.FlatAppearance.BorderSize = 0;
            btnTTSStop.FlatStyle = FlatStyle.Flat;
            btnTTSStop.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTTSStop.ForeColor = Color.White;
            btnTTSStop.Location = new Point(321, 3);
            btnTTSStop.Name = "btnTTSStop";
            btnTTSStop.Size = new Size(100, 40);
            btnTTSStop.TabIndex = 3;
            btnTTSStop.Text = "⏹ Stop";
            btnTTSStop.UseVisualStyleBackColor = false;
            // 
            // grpSTT
            // 
            grpSTT.BackColor = Color.FromArgb(30, 41, 59);
            grpSTT.Controls.Add(pnlSTTControls);
            grpSTT.Controls.Add(panelSTTButtons);
            grpSTT.Controls.Add(pnlSTTOutputWrap);
            grpSTT.Controls.Add(lblSTTOutput);
            grpSTT.Dock = DockStyle.Fill;
            grpSTT.FlatStyle = FlatStyle.Flat;
            grpSTT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpSTT.ForeColor = Color.FromArgb(241, 245, 249);
            grpSTT.Location = new Point(507, 13);
            grpSTT.Name = "grpSTT";
            grpSTT.Padding = new Padding(10);
            grpSTT.Size = new Size(488, 404);
            grpSTT.TabIndex = 1;
            grpSTT.TabStop = false;
            grpSTT.Text = "Speech-to-Text (STT)";
            // 
            // pnlSTTOutputWrap
            // 
            pnlSTTOutputWrap.BackColor = Color.FromArgb(71, 85, 105);
            pnlSTTOutputWrap.Controls.Add(txtSTTOutput);
            pnlSTTOutputWrap.Dock = DockStyle.Top;
            pnlSTTOutputWrap.Location = new Point(10, 47);
            pnlSTTOutputWrap.Name = "pnlSTTOutputWrap";
            pnlSTTOutputWrap.Padding = new Padding(1);
            pnlSTTOutputWrap.Size = new Size(468, 120);
            pnlSTTOutputWrap.TabIndex = 1;
            // 
            // txtSTTOutput
            // 
            txtSTTOutput.BackColor = Color.FromArgb(15, 23, 42);
            txtSTTOutput.BorderStyle = BorderStyle.None;
            txtSTTOutput.Dock = DockStyle.Fill;
            txtSTTOutput.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSTTOutput.ForeColor = Color.FromArgb(241, 245, 249);
            txtSTTOutput.Location = new Point(1, 1);
            txtSTTOutput.Name = "txtSTTOutput";
            txtSTTOutput.ReadOnly = true;
            txtSTTOutput.Size = new Size(466, 118);
            txtSTTOutput.TabIndex = 0;
            txtSTTOutput.Text = "";
            // 
            // lblSTTOutput
            // 
            lblSTTOutput.Dock = DockStyle.Top;
            lblSTTOutput.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSTTOutput.ForeColor = Color.FromArgb(148, 163, 184);
            lblSTTOutput.Location = new Point(10, 30);
            lblSTTOutput.Name = "lblSTTOutput";
            lblSTTOutput.Size = new Size(468, 17);
            lblSTTOutput.TabIndex = 0;
            lblSTTOutput.Text = "Transcribed Text (Heard from mic):";
            // 
            // pnlSTTControls
            // 
            pnlSTTControls.Controls.Add(lblSTTStatus);
            pnlSTTControls.Controls.Add(lblSTTLang);
            pnlSTTControls.Controls.Add(cmbSTTLanguage);
            pnlSTTControls.Dock = DockStyle.Fill;
            pnlSTTControls.Location = new Point(10, 167);
            pnlSTTControls.Name = "pnlSTTControls";
            pnlSTTControls.Size = new Size(468, 177);
            pnlSTTControls.TabIndex = 2;
            // 
            // lblSTTStatus
            // 
            lblSTTStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSTTStatus.BackColor = Color.FromArgb(15, 23, 42);
            lblSTTStatus.BorderStyle = BorderStyle.FixedSingle;
            lblSTTStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSTTStatus.ForeColor = Color.FromArgb(239, 68, 68);
            lblSTTStatus.Location = new Point(6, 48);
            lblSTTStatus.Name = "lblSTTStatus";
            lblSTTStatus.Padding = new Padding(5);
            lblSTTStatus.Size = new Size(459, 116);
            lblSTTStatus.TabIndex = 2;
            lblSTTStatus.Text = "Status: Idle";
            lblSTTStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSTTLang
            // 
            lblSTTLang.AutoSize = true;
            lblSTTLang.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSTTLang.ForeColor = Color.FromArgb(148, 163, 184);
            lblSTTLang.Location = new Point(3, 10);
            lblSTTLang.Name = "lblSTTLang";
            lblSTTLang.Size = new Size(111, 17);
            lblSTTLang.TabIndex = 0;
            lblSTTLang.Text = "Select Language:";
            // 
            // cmbSTTLanguage
            // 
            cmbSTTLanguage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSTTLanguage.BackColor = Color.FromArgb(15, 23, 42);
            cmbSTTLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSTTLanguage.FlatStyle = FlatStyle.Flat;
            cmbSTTLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbSTTLanguage.ForeColor = Color.FromArgb(241, 245, 249);
            cmbSTTLanguage.FormattingEnabled = true;
            cmbSTTLanguage.Location = new Point(120, 7);
            cmbSTTLanguage.Name = "cmbSTTLanguage";
            cmbSTTLanguage.Size = new Size(345, 25);
            cmbSTTLanguage.TabIndex = 1;
            // 
            // panelSTTButtons
            // 
            panelSTTButtons.Controls.Add(btnSTTStart);
            panelSTTButtons.Controls.Add(btnSTTStop);
            panelSTTButtons.Controls.Add(btnSTTClear);
            panelSTTButtons.Controls.Add(btnSTTCopy);
            panelSTTButtons.Dock = DockStyle.Bottom;
            panelSTTButtons.Location = new Point(10, 344);
            panelSTTButtons.Name = "panelSTTButtons";
            panelSTTButtons.Size = new Size(468, 50);
            panelSTTButtons.TabIndex = 3;
            // 
            // btnSTTStart
            // 
            btnSTTStart.BackColor = Color.FromArgb(16, 185, 129);
            btnSTTStart.FlatAppearance.BorderSize = 0;
            btnSTTStart.FlatStyle = FlatStyle.Flat;
            btnSTTStart.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSTTStart.ForeColor = Color.White;
            btnSTTStart.Location = new Point(3, 3);
            btnSTTStart.Name = "btnSTTStart";
            btnSTTStart.Size = new Size(110, 40);
            btnSTTStart.TabIndex = 0;
            btnSTTStart.Text = "🎙️ Listen";
            btnSTTStart.UseVisualStyleBackColor = false;
            // 
            // btnSTTStop
            // 
            btnSTTStop.BackColor = Color.FromArgb(239, 68, 68);
            btnSTTStop.FlatAppearance.BorderSize = 0;
            btnSTTStop.FlatStyle = FlatStyle.Flat;
            btnSTTStop.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSTTStop.ForeColor = Color.White;
            btnSTTStop.Location = new Point(119, 3);
            btnSTTStop.Name = "btnSTTStop";
            btnSTTStop.Size = new Size(110, 40);
            btnSTTStop.TabIndex = 1;
            btnSTTStop.Text = "🛑 Stop";
            btnSTTStop.UseVisualStyleBackColor = false;
            // 
            // btnSTTClear
            // 
            btnSTTClear.BackColor = Color.FromArgb(75, 85, 99);
            btnSTTClear.FlatAppearance.BorderSize = 0;
            btnSTTClear.FlatStyle = FlatStyle.Flat;
            btnSTTClear.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSTTClear.ForeColor = Color.White;
            btnSTTClear.Location = new Point(235, 3);
            btnSTTClear.Name = "btnSTTClear";
            btnSTTClear.Size = new Size(100, 40);
            btnSTTClear.TabIndex = 2;
            btnSTTClear.Text = "🧹 Clear";
            btnSTTClear.UseVisualStyleBackColor = false;
            // 
            // btnSTTCopy
            // 
            btnSTTCopy.BackColor = Color.FromArgb(75, 85, 99);
            btnSTTCopy.FlatAppearance.BorderSize = 0;
            btnSTTCopy.FlatStyle = FlatStyle.Flat;
            btnSTTCopy.Font = new Font("Segoe UI Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSTTCopy.ForeColor = Color.White;
            btnSTTCopy.Location = new Point(341, 3);
            btnSTTCopy.Name = "btnSTTCopy";
            btnSTTCopy.Size = new Size(100, 40);
            btnSTTCopy.TabIndex = 3;
            btnSTTCopy.Text = "📋 Copy";
            btnSTTCopy.UseVisualStyleBackColor = false;
            // 
            // panelLogs
            // 
            panelLogs.Controls.Add(grpLogs);
            panelLogs.Dock = DockStyle.Bottom;
            panelLogs.Location = new Point(0, 510);
            panelLogs.Name = "panelLogs";
            panelLogs.Padding = new Padding(10);
            panelLogs.Size = new Size(1008, 151);
            panelLogs.TabIndex = 2;
            // 
            // grpLogs
            // 
            grpLogs.BackColor = Color.FromArgb(30, 41, 59);
            grpLogs.Controls.Add(btnLogsClear);
            grpLogs.Controls.Add(txtLogs);
            grpLogs.Dock = DockStyle.Fill;
            grpLogs.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpLogs.ForeColor = Color.FromArgb(241, 245, 249);
            grpLogs.Location = new Point(10, 10);
            grpLogs.Name = "grpLogs";
            grpLogs.Padding = new Padding(10);
            grpLogs.Size = new Size(988, 131);
            grpLogs.TabIndex = 0;
            grpLogs.TabStop = false;
            grpLogs.Text = "OOP Event & System Logs";
            // 
            // btnLogsClear
            // 
            btnLogsClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogsClear.BackColor = Color.FromArgb(75, 85, 99);
            btnLogsClear.FlatAppearance.BorderSize = 0;
            btnLogsClear.FlatStyle = FlatStyle.Flat;
            btnLogsClear.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogsClear.ForeColor = Color.White;
            btnLogsClear.Location = new Point(902, 16);
            btnLogsClear.Name = "btnLogsClear";
            btnLogsClear.Size = new Size(76, 22);
            btnLogsClear.TabIndex = 1;
            btnLogsClear.Text = "Clear Logs";
            btnLogsClear.UseVisualStyleBackColor = false;
            // 
            // txtLogs
            // 
            txtLogs.BackColor = Color.FromArgb(15, 23, 42);
            txtLogs.BorderStyle = BorderStyle.None;
            txtLogs.Dock = DockStyle.Fill;
            txtLogs.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtLogs.ForeColor = Color.FromArgb(148, 163, 184);
            txtLogs.Location = new Point(10, 28);
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.Size = new Size(968, 93);
            txtLogs.TabIndex = 0;
            txtLogs.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1008, 661);
            Controls.Add(pnlMain);
            Controls.Add(panelLogs);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            MinimumSize = new Size(1024, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OOP Speech Studio (Text-to-Speech & Speech-to-Text)";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            grpTTS.ResumeLayout(false);
            pnlTTSInputWrap.ResumeLayout(false);
            pnlTTSControls.ResumeLayout(false);
            pnlTTSControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackTTSRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackTTSVolume).EndInit();
            panelTTSButtons.ResumeLayout(false);
            grpSTT.ResumeLayout(false);
            pnlSTTOutputWrap.ResumeLayout(false);
            pnlSTTControls.ResumeLayout(false);
            pnlSTTControls.PerformLayout();
            panelSTTButtons.ResumeLayout(false);
            panelLogs.ResumeLayout(false);
            grpLogs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSub;
        private TableLayoutPanel pnlMain;
        private GroupBox grpTTS;
        private GroupBox grpSTT;
        private Label lblTTSInput;
        private Panel pnlTTSInputWrap;
        private RichTextBox txtTTSInput;
        private Panel pnlTTSControls;
        private ComboBox cmbTTSVoice;
        private Label lblTTSVoice;
        private TrackBar trackTTSVolume;
        private Label lblTTSVolume;
        private Label lblTTSRate;
        private TrackBar trackTTSRate;
        private FlowLayoutPanel panelTTSButtons;
        private Button btnTTSSpeak;
        private Button btnTTSPause;
        private Button btnTTSResume;
        private Button btnTTSStop;
        private Panel pnlSTTOutputWrap;
        private RichTextBox txtSTTOutput;
        private Label lblSTTOutput;
        private Panel pnlSTTControls;
        private Label lblSTTLang;
        private ComboBox cmbSTTLanguage;
        private Label lblSTTStatus;
        private FlowLayoutPanel panelSTTButtons;
        private Button btnSTTStart;
        private Button btnSTTStop;
        private Button btnSTTClear;
        private Button btnSTTCopy;
        private Panel panelLogs;
        private GroupBox grpLogs;
        private RichTextBox txtLogs;
        private Button btnLogsClear;
    }
}
