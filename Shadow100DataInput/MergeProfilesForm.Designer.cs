namespace Shadow100DataInput
{
    partial class MergeProfilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Profile1SelectionComboBox = new System.Windows.Forms.ComboBox();
            this.MergedProfileNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Profile2SelectionComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MergeProfilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select which profiles will be merged";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profile 1";
            // 
            // Profile1SelectionComboBox
            // 
            this.Profile1SelectionComboBox.FormattingEnabled = true;
            this.Profile1SelectionComboBox.Location = new System.Drawing.Point(12, 67);
            this.Profile1SelectionComboBox.Name = "Profile1SelectionComboBox";
            this.Profile1SelectionComboBox.Size = new System.Drawing.Size(199, 28);
            this.Profile1SelectionComboBox.TabIndex = 2;
            this.Profile1SelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.Profile1SelectionComboBox_SelectedIndexChanged);
            // 
            // MergedProfileNameTextBox
            // 
            this.MergedProfileNameTextBox.Location = new System.Drawing.Point(12, 133);
            this.MergedProfileNameTextBox.Name = "MergedProfileNameTextBox";
            this.MergedProfileNameTextBox.Size = new System.Drawing.Size(404, 26);
            this.MergedProfileNameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "New Profile Name";
            // 
            // Profile2SelectionComboBox
            // 
            this.Profile2SelectionComboBox.FormattingEnabled = true;
            this.Profile2SelectionComboBox.Location = new System.Drawing.Point(217, 67);
            this.Profile2SelectionComboBox.Name = "Profile2SelectionComboBox";
            this.Profile2SelectionComboBox.Size = new System.Drawing.Size(199, 28);
            this.Profile2SelectionComboBox.TabIndex = 6;
            this.Profile2SelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.Profile2SelectionComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Profile 2";
            // 
            // MergeProfilesButton
            // 
            this.MergeProfilesButton.Location = new System.Drawing.Point(12, 166);
            this.MergeProfilesButton.Name = "MergeProfilesButton";
            this.MergeProfilesButton.Size = new System.Drawing.Size(404, 40);
            this.MergeProfilesButton.TabIndex = 7;
            this.MergeProfilesButton.Text = "Merge Profiles";
            this.MergeProfilesButton.UseVisualStyleBackColor = true;
            this.MergeProfilesButton.Click += new System.EventHandler(this.MergeProfilesButton_Click);
            // 
            // MergeProfilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 223);
            this.Controls.Add(this.MergeProfilesButton);
            this.Controls.Add(this.Profile2SelectionComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MergedProfileNameTextBox);
            this.Controls.Add(this.Profile1SelectionComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MergeProfilesForm";
            this.Text = "Profile Merge Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Profile1SelectionComboBox;
        private System.Windows.Forms.TextBox MergedProfileNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Profile2SelectionComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MergeProfilesButton;
    }
}