namespace Lap08
{
    partial class Form2
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
            Male = new RadioButton();
            txtName = new TextBox();
            txtEmail = new TextBox();
            lblName = new Label();
            lblEmail = new Label();
            btnRegister = new Button();
            ChkFootball = new CheckBox();
            ChkTennis = new CheckBox();
            ChkSwimming = new CheckBox();
            lblGender = new Label();
            Female = new RadioButton();
            lblHobbies = new Label();
            ValidationName = new Label();
            ValidationEmail = new Label();
            ValidationHobbies = new Label();
            lblSuccess = new Label();
            SuspendLayout();
            // 
            // Male
            // 
            Male.AutoSize = true;
            Male.Location = new Point(158, 248);
            Male.Name = "Male";
            Male.Size = new Size(98, 36);
            Male.TabIndex = 6;
            Male.TabStop = true;
            Male.Text = "Male";
            Male.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(158, 63);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(158, 148);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 39);
            txtEmail.TabIndex = 12;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.Location = new Point(25, 63);
            lblName.Name = "lblName";
            lblName.Size = new Size(88, 32);
            lblName.TabIndex = 11;
            lblName.Text = "Name:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(25, 148);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(83, 32);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(405, 425);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 46);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // ChkFootball
            // 
            ChkFootball.AutoSize = true;
            ChkFootball.Location = new Point(158, 335);
            ChkFootball.Name = "ChkFootball";
            ChkFootball.Size = new Size(132, 36);
            ChkFootball.TabIndex = 15;
            ChkFootball.Text = "Football";
            ChkFootball.UseVisualStyleBackColor = true;
            // 
            // ChkTennis
            // 
            ChkTennis.AutoSize = true;
            ChkTennis.Location = new Point(323, 335);
            ChkTennis.Name = "ChkTennis";
            ChkTennis.Size = new Size(114, 36);
            ChkTennis.TabIndex = 16;
            ChkTennis.Text = "Tennis";
            ChkTennis.UseVisualStyleBackColor = true;
            // 
            // ChkSwimming
            // 
            ChkSwimming.AutoSize = true;
            ChkSwimming.Location = new Point(463, 335);
            ChkSwimming.Name = "ChkSwimming";
            ChkSwimming.Size = new Size(158, 36);
            ChkSwimming.TabIndex = 17;
            ChkSwimming.Text = "Swimming";
            ChkSwimming.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGender.Location = new Point(25, 248);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(105, 32);
            lblGender.TabIndex = 18;
            lblGender.Text = "Gender:";
            // 
            // Female
            // 
            Female.AutoSize = true;
            Female.Location = new Point(323, 248);
            Female.Name = "Female";
            Female.Size = new Size(122, 36);
            Female.TabIndex = 19;
            Female.TabStop = true;
            Female.Text = "Female";
            Female.UseVisualStyleBackColor = true;
            // 
            // lblHobbies
            // 
            lblHobbies.AutoSize = true;
            lblHobbies.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHobbies.Location = new Point(25, 335);
            lblHobbies.Name = "lblHobbies";
            lblHobbies.Size = new Size(115, 32);
            lblHobbies.TabIndex = 20;
            lblHobbies.Text = "Hobbies:";
            // 
            // ValidationName
            // 
            ValidationName.AutoSize = true;
            ValidationName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ValidationName.ForeColor = Color.Red;
            ValidationName.Location = new Point(382, 66);
            ValidationName.Name = "ValidationName";
            ValidationName.Size = new Size(472, 32);
            ValidationName.TabIndex = 21;
            ValidationName.Text = "Name must contain at least 5 characters";
            ValidationName.Visible = false;
            // 
            // ValidationEmail
            // 
            ValidationEmail.AutoSize = true;
            ValidationEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ValidationEmail.ForeColor = Color.Red;
            ValidationEmail.Location = new Point(382, 148);
            ValidationEmail.Name = "ValidationEmail";
            ValidationEmail.Size = new Size(263, 32);
            ValidationEmail.TabIndex = 22;
            ValidationEmail.Text = "Email must contain @";
            ValidationEmail.Visible = false;
            // 
            // ValidationHobbies
            // 
            ValidationHobbies.AutoSize = true;
            ValidationHobbies.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ValidationHobbies.ForeColor = Color.Red;
            ValidationHobbies.Location = new Point(638, 335);
            ValidationHobbies.Name = "ValidationHobbies";
            ValidationHobbies.Size = new Size(315, 32);
            ValidationHobbies.TabIndex = 23;
            ValidationHobbies.Text = "Choose at least one hobby";
            ValidationHobbies.Visible = false;
            // 
            // lblSuccess
            // 
            lblSuccess.AutoSize = true;
            lblSuccess.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSuccess.ForeColor = Color.ForestGreen;
            lblSuccess.Location = new Point(260, 507);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(428, 32);
            lblSuccess.TabIndex = 24;
            lblSuccess.Text = "Thank you, your registration is valid";
            lblSuccess.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 592);
            Controls.Add(lblSuccess);
            Controls.Add(ValidationHobbies);
            Controls.Add(ValidationEmail);
            Controls.Add(ValidationName);
            Controls.Add(lblHobbies);
            Controls.Add(Female);
            Controls.Add(lblGender);
            Controls.Add(ChkSwimming);
            Controls.Add(Male);
            Controls.Add(ChkTennis);
            Controls.Add(ChkFootball);
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(lblName);
            Controls.Add(lblEmail);
            Controls.Add(btnRegister);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton Male;
        private TextBox txtName;
        private TextBox txtEmail;
        private Label lblName;
        private Label lblEmail;
        private Button btnRegister;
        private CheckBox ChkFootball;
        private CheckBox ChkTennis;
        private CheckBox ChkSwimming;
        private Label lblGender;
        private RadioButton Female;
        private Label lblHobbies;
        private Label ValidationName;
        private Label ValidationEmail;
        private Label ValidationHobbies;
        private Label lblSuccess;
    }
}
