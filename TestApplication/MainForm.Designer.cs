namespace TestApplication {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.layoutForm = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.listDevices = new System.Windows.Forms.ListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.splitDetailsVisuals = new System.Windows.Forms.SplitContainer();
            this.layoutProperties = new System.Windows.Forms.TableLayoutPanel();
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFlags = new System.Windows.Forms.Label();
            this.lblAxes = new System.Windows.Forms.Label();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.txtAxes = new System.Windows.Forms.TextBox();
            this.lblButtons = new System.Windows.Forms.Label();
            this.lblPOVs = new System.Windows.Forms.Label();
            this.lblSamplePeriod = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.lblHardware = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.txtButtons = new System.Windows.Forms.TextBox();
            this.txtPOVs = new System.Windows.Forms.TextBox();
            this.txtSamplePeriod = new System.Windows.Forms.TextBox();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.txtHardware = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.inputRenderer = new TestApplication.InputRenderControl();
            this.layoutForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetailsVisuals)).BeginInit();
            this.splitDetailsVisuals.Panel1.SuspendLayout();
            this.splitDetailsVisuals.Panel2.SuspendLayout();
            this.splitDetailsVisuals.SuspendLayout();
            this.layoutProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 33;
            this.updateTimer.Tick += new System.EventHandler(this.timer_tick);
            // 
            // layoutForm
            // 
            this.layoutForm.ColumnCount = 3;
            this.layoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.25847F));
            this.layoutForm.Controls.Add(this.btnRefresh, 0, 0);
            this.layoutForm.Controls.Add(this.listDevices, 0, 1);
            this.layoutForm.Controls.Add(this.btnLoad, 1, 0);
            this.layoutForm.Controls.Add(this.splitDetailsVisuals, 2, 1);
            this.layoutForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutForm.Location = new System.Drawing.Point(0, 0);
            this.layoutForm.Name = "layoutForm";
            this.layoutForm.RowCount = 2;
            this.layoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutForm.Size = new System.Drawing.Size(784, 361);
            this.layoutForm.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.refreshList);
            // 
            // listDevices
            // 
            this.layoutForm.SetColumnSpan(this.listDevices, 2);
            this.listDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(3, 32);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(242, 326);
            this.listDevices.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(84, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.displayListItem);
            // 
            // splitDetailsVisuals
            // 
            this.splitDetailsVisuals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDetailsVisuals.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitDetailsVisuals.Location = new System.Drawing.Point(251, 32);
            this.splitDetailsVisuals.Name = "splitDetailsVisuals";
            // 
            // splitDetailsVisuals.Panel1
            // 
            this.splitDetailsVisuals.Panel1.Controls.Add(this.layoutProperties);
            // 
            // splitDetailsVisuals.Panel2
            // 
            this.splitDetailsVisuals.Panel2.Controls.Add(this.inputRenderer);
            this.splitDetailsVisuals.Size = new System.Drawing.Size(530, 326);
            this.splitDetailsVisuals.SplitterDistance = 226;
            this.splitDetailsVisuals.TabIndex = 6;
            // 
            // layoutProperties
            // 
            this.layoutProperties.AutoSize = true;
            this.layoutProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutProperties.ColumnCount = 2;
            this.layoutProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutProperties.Controls.Add(this.lblDeviceType, 0, 0);
            this.layoutProperties.Controls.Add(this.lblSize, 0, 1);
            this.layoutProperties.Controls.Add(this.lblFlags, 0, 2);
            this.layoutProperties.Controls.Add(this.lblAxes, 0, 3);
            this.layoutProperties.Controls.Add(this.txtDeviceType, 1, 0);
            this.layoutProperties.Controls.Add(this.txtSize, 1, 1);
            this.layoutProperties.Controls.Add(this.txtFlags, 1, 2);
            this.layoutProperties.Controls.Add(this.txtAxes, 1, 3);
            this.layoutProperties.Controls.Add(this.lblButtons, 0, 4);
            this.layoutProperties.Controls.Add(this.lblPOVs, 0, 5);
            this.layoutProperties.Controls.Add(this.lblSamplePeriod, 0, 6);
            this.layoutProperties.Controls.Add(this.lblResolution, 0, 7);
            this.layoutProperties.Controls.Add(this.lblFirmware, 0, 8);
            this.layoutProperties.Controls.Add(this.lblHardware, 0, 9);
            this.layoutProperties.Controls.Add(this.lblDriver, 0, 10);
            this.layoutProperties.Controls.Add(this.txtButtons, 1, 4);
            this.layoutProperties.Controls.Add(this.txtPOVs, 1, 5);
            this.layoutProperties.Controls.Add(this.txtSamplePeriod, 1, 6);
            this.layoutProperties.Controls.Add(this.txtResolution, 1, 7);
            this.layoutProperties.Controls.Add(this.txtFirmware, 1, 8);
            this.layoutProperties.Controls.Add(this.txtHardware, 1, 9);
            this.layoutProperties.Controls.Add(this.txtDriver, 1, 10);
            this.layoutProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutProperties.Location = new System.Drawing.Point(0, 0);
            this.layoutProperties.Name = "layoutProperties";
            this.layoutProperties.RowCount = 12;
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutProperties.Size = new System.Drawing.Size(226, 326);
            this.layoutProperties.TabIndex = 5;
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeviceType.Location = new System.Drawing.Point(3, 0);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(100, 26);
            this.lblDeviceType.TabIndex = 0;
            this.lblDeviceType.Text = "Device Type";
            this.lblDeviceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSize
            // 
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.Location = new System.Drawing.Point(3, 26);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(100, 26);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlags
            // 
            this.lblFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFlags.Location = new System.Drawing.Point(3, 52);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(100, 26);
            this.lblFlags.TabIndex = 2;
            this.lblFlags.Text = "Flags";
            this.lblFlags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAxes
            // 
            this.lblAxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxes.Location = new System.Drawing.Point(3, 78);
            this.lblAxes.Name = "lblAxes";
            this.lblAxes.Size = new System.Drawing.Size(100, 26);
            this.lblAxes.TabIndex = 3;
            this.lblAxes.Text = "Axes";
            this.lblAxes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeviceType.Location = new System.Drawing.Point(109, 3);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.ReadOnly = true;
            this.txtDeviceType.Size = new System.Drawing.Size(114, 20);
            this.txtDeviceType.TabIndex = 4;
            // 
            // txtSize
            // 
            this.txtSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSize.Location = new System.Drawing.Point(109, 29);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(114, 20);
            this.txtSize.TabIndex = 5;
            // 
            // txtFlags
            // 
            this.txtFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFlags.Location = new System.Drawing.Point(109, 55);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.ReadOnly = true;
            this.txtFlags.Size = new System.Drawing.Size(114, 20);
            this.txtFlags.TabIndex = 6;
            // 
            // txtAxes
            // 
            this.txtAxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAxes.Location = new System.Drawing.Point(109, 81);
            this.txtAxes.Name = "txtAxes";
            this.txtAxes.ReadOnly = true;
            this.txtAxes.Size = new System.Drawing.Size(114, 20);
            this.txtAxes.TabIndex = 7;
            // 
            // lblButtons
            // 
            this.lblButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblButtons.Location = new System.Drawing.Point(3, 104);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(100, 26);
            this.lblButtons.TabIndex = 8;
            this.lblButtons.Text = "Buttons";
            this.lblButtons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPOVs
            // 
            this.lblPOVs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPOVs.Location = new System.Drawing.Point(3, 130);
            this.lblPOVs.Name = "lblPOVs";
            this.lblPOVs.Size = new System.Drawing.Size(100, 26);
            this.lblPOVs.TabIndex = 9;
            this.lblPOVs.Text = "POVs";
            this.lblPOVs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSamplePeriod
            // 
            this.lblSamplePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSamplePeriod.Location = new System.Drawing.Point(3, 156);
            this.lblSamplePeriod.Name = "lblSamplePeriod";
            this.lblSamplePeriod.Size = new System.Drawing.Size(100, 26);
            this.lblSamplePeriod.TabIndex = 10;
            this.lblSamplePeriod.Text = "FF Sample Period";
            this.lblSamplePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResolution
            // 
            this.lblResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResolution.Location = new System.Drawing.Point(3, 182);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(100, 26);
            this.lblResolution.TabIndex = 11;
            this.lblResolution.Text = "FF Min Resolution";
            this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFirmware
            // 
            this.lblFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirmware.Location = new System.Drawing.Point(3, 208);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(100, 26);
            this.lblFirmware.TabIndex = 12;
            this.lblFirmware.Text = "Firmware Version";
            this.lblFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHardware
            // 
            this.lblHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHardware.Location = new System.Drawing.Point(3, 234);
            this.lblHardware.Name = "lblHardware";
            this.lblHardware.Size = new System.Drawing.Size(100, 26);
            this.lblHardware.TabIndex = 13;
            this.lblHardware.Text = "Hardware Revision";
            this.lblHardware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDriver
            // 
            this.lblDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDriver.Location = new System.Drawing.Point(3, 260);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(100, 26);
            this.lblDriver.TabIndex = 14;
            this.lblDriver.Text = "FF Driver Version";
            this.lblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtButtons
            // 
            this.txtButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtButtons.Location = new System.Drawing.Point(109, 107);
            this.txtButtons.Name = "txtButtons";
            this.txtButtons.ReadOnly = true;
            this.txtButtons.Size = new System.Drawing.Size(114, 20);
            this.txtButtons.TabIndex = 15;
            // 
            // txtPOVs
            // 
            this.txtPOVs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPOVs.Location = new System.Drawing.Point(109, 133);
            this.txtPOVs.Name = "txtPOVs";
            this.txtPOVs.ReadOnly = true;
            this.txtPOVs.Size = new System.Drawing.Size(114, 20);
            this.txtPOVs.TabIndex = 16;
            // 
            // txtSamplePeriod
            // 
            this.txtSamplePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSamplePeriod.Location = new System.Drawing.Point(109, 159);
            this.txtSamplePeriod.Name = "txtSamplePeriod";
            this.txtSamplePeriod.ReadOnly = true;
            this.txtSamplePeriod.Size = new System.Drawing.Size(114, 20);
            this.txtSamplePeriod.TabIndex = 17;
            // 
            // txtResolution
            // 
            this.txtResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResolution.Location = new System.Drawing.Point(109, 185);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.ReadOnly = true;
            this.txtResolution.Size = new System.Drawing.Size(114, 20);
            this.txtResolution.TabIndex = 18;
            // 
            // txtFirmware
            // 
            this.txtFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFirmware.Location = new System.Drawing.Point(109, 211);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.ReadOnly = true;
            this.txtFirmware.Size = new System.Drawing.Size(114, 20);
            this.txtFirmware.TabIndex = 19;
            // 
            // txtHardware
            // 
            this.txtHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHardware.Location = new System.Drawing.Point(109, 237);
            this.txtHardware.Name = "txtHardware";
            this.txtHardware.ReadOnly = true;
            this.txtHardware.Size = new System.Drawing.Size(114, 20);
            this.txtHardware.TabIndex = 20;
            // 
            // txtDriver
            // 
            this.txtDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDriver.Location = new System.Drawing.Point(109, 263);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.ReadOnly = true;
            this.txtDriver.Size = new System.Drawing.Size(114, 20);
            this.txtDriver.TabIndex = 21;
            // 
            // inputRenderer
            // 
            this.inputRenderer.Device = null;
            this.inputRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputRenderer.Location = new System.Drawing.Point(0, 0);
            this.inputRenderer.Name = "inputRenderer";
            this.inputRenderer.Size = new System.Drawing.Size(300, 326);
            this.inputRenderer.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.layoutForm);
            this.Name = "MainForm";
            this.Text = "TestApplication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.layoutForm.ResumeLayout(false);
            this.splitDetailsVisuals.Panel1.ResumeLayout(false);
            this.splitDetailsVisuals.Panel1.PerformLayout();
            this.splitDetailsVisuals.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDetailsVisuals)).EndInit();
            this.splitDetailsVisuals.ResumeLayout(false);
            this.layoutProperties.ResumeLayout(false);
            this.layoutProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.TableLayoutPanel layoutForm;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox listDevices;
        private System.Windows.Forms.Button btnLoad;
        private InputRenderControl inputRenderer;
        private System.Windows.Forms.TableLayoutPanel layoutProperties;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblFlags;
        private System.Windows.Forms.Label lblAxes;
        private System.Windows.Forms.Label lblButtons;
        private System.Windows.Forms.Label lblPOVs;
        private System.Windows.Forms.Label lblSamplePeriod;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Label lblHardware;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.TextBox txtAxes;
        private System.Windows.Forms.TextBox txtButtons;
        private System.Windows.Forms.TextBox txtPOVs;
        private System.Windows.Forms.TextBox txtSamplePeriod;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.TextBox txtHardware;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.SplitContainer splitDetailsVisuals;
    }
}

