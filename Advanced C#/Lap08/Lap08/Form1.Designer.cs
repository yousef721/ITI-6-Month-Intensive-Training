namespace Lap08
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Convert = new Button();
            Result = new Label();
            Unit = new Label();
            Value = new Label();
            txtResult = new TextBox();
            txtValue = new TextBox();
            UnitPanel = new Panel();
            MileToMeter = new RadioButton();
            MeterToMile = new RadioButton();
            MeterToKilometer = new RadioButton();
            UnitPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Convert
            // 
            Convert.Location = new Point(389, 358);
            Convert.Name = "Convert";
            Convert.Size = new Size(150, 46);
            Convert.TabIndex = 1;
            Convert.Text = "Convert";
            Convert.UseVisualStyleBackColor = true;
            Convert.Click += Convert_Click;
            // 
            // Result
            // 
            Result.AutoSize = true;
            Result.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Result.Location = new Point(27, 154);
            Result.Name = "Result";
            Result.Size = new Size(91, 32);
            Result.TabIndex = 3;
            Result.Text = "Result:";
            // 
            // Unit
            // 
            Unit.AutoSize = true;
            Unit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Unit.ForeColor = SystemColors.ActiveCaptionText;
            Unit.ImageAlign = ContentAlignment.TopCenter;
            Unit.Location = new Point(94, 11);
            Unit.Name = "Unit";
            Unit.Size = new Size(152, 32);
            Unit.TabIndex = 4;
            Unit.Text = "Choose Unit";
            Unit.TextAlign = ContentAlignment.TopCenter;
            // 
            // Value
            // 
            Value.AutoSize = true;
            Value.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Value.ForeColor = SystemColors.ControlText;
            Value.Location = new Point(27, 69);
            Value.Name = "Value";
            Value.Size = new Size(83, 32);
            Value.TabIndex = 5;
            Value.Text = "Value:";
            // 
            // txtResult
            // 
            txtResult.Location = new Point(148, 154);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(200, 39);
            txtResult.TabIndex = 6;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(148, 69);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(200, 39);
            txtValue.TabIndex = 7;
            // 
            // UnitPanel
            // 
            UnitPanel.Controls.Add(MileToMeter);
            UnitPanel.Controls.Add(MeterToMile);
            UnitPanel.Controls.Add(MeterToKilometer);
            UnitPanel.Controls.Add(Unit);
            UnitPanel.Location = new Point(580, 47);
            UnitPanel.Name = "UnitPanel";
            UnitPanel.Size = new Size(329, 276);
            UnitPanel.TabIndex = 8;
            // 
            // MileToMeter
            // 
            MileToMeter.AutoSize = true;
            MileToMeter.Location = new Point(31, 175);
            MileToMeter.Name = "MileToMeter";
            MileToMeter.Size = new Size(192, 36);
            MileToMeter.TabIndex = 7;
            MileToMeter.TabStop = true;
            MileToMeter.Text = "Mile to Meter";
            MileToMeter.UseVisualStyleBackColor = true;
            // 
            // MeterToMile
            // 
            MeterToMile.AutoSize = true;
            MeterToMile.Location = new Point(31, 124);
            MeterToMile.Name = "MeterToMile";
            MeterToMile.Size = new Size(192, 36);
            MeterToMile.TabIndex = 6;
            MeterToMile.TabStop = true;
            MeterToMile.Text = "Meter to Mile";
            MeterToMile.UseVisualStyleBackColor = true;
            // 
            // MeterToKilometer
            // 
            MeterToKilometer.AutoSize = true;
            MeterToKilometer.Checked = true;
            MeterToKilometer.Location = new Point(31, 73);
            MeterToKilometer.Name = "MeterToKilometer";
            MeterToKilometer.Size = new Size(248, 36);
            MeterToKilometer.TabIndex = 5;
            MeterToKilometer.TabStop = true;
            MeterToKilometer.Text = "Meter to Kilometer";
            MeterToKilometer.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 450);
            Controls.Add(UnitPanel);
            Controls.Add(txtValue);
            Controls.Add(txtResult);
            Controls.Add(Value);
            Controls.Add(Result);
            Controls.Add(Convert);
            Name = "Form1";
            Text = "Form1";
            UnitPanel.ResumeLayout(false);
            UnitPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Convert;
        private Label Result;
        private Label Unit;
        private Label Value;
        private TextBox txtResult;
        private TextBox txtValue;
        private Panel UnitPanel;
        private RadioButton MileToMeter;
        private RadioButton MeterToMile;
        private RadioButton MeterToKilometer;
    }
}
