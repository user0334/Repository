﻿
namespace BoatGraphics
{
	partial class FormHarbor
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
			this.pictureBoxHarbor = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.addHarborButton = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxHarbor)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxHarbor
			// 
			this.pictureBoxHarbor.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxHarbor.Name = "pictureBoxHarbor";
			this.pictureBoxHarbor.Size = new System.Drawing.Size(658, 468);
			this.pictureBoxHarbor.TabIndex = 0;
			this.pictureBoxHarbor.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(691, 281);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(163, 29);
			this.button1.TabIndex = 1;
			this.button1.Text = "Добавить лодку";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(691, 368);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(163, 100);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Забрать лодку";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(48, 57);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Забрать";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(57, 31);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(36, 20);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Место";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(691, 28);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(163, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "Гавань простора";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(688, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Название";
			// 
			// addHarborButton
			// 
			this.addHarborButton.Location = new System.Drawing.Point(707, 57);
			this.addHarborButton.Name = "addHarborButton";
			this.addHarborButton.Size = new System.Drawing.Size(123, 23);
			this.addHarborButton.TabIndex = 6;
			this.addHarborButton.Text = "Добавить гавань";
			this.addHarborButton.UseVisualStyleBackColor = true;
			this.addHarborButton.Click += new System.EventHandler(this.addHarborButton_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(691, 97);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(163, 134);
			this.listBox1.TabIndex = 7;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(707, 237);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(123, 23);
			this.button4.TabIndex = 8;
			this.button4.Text = "Удалить гавань";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// FormHarbor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(875, 492);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.addHarborButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBoxHarbor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FormHarbor";
			this.Text = "Гавань для лодок и катамаранов";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxHarbor)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxHarbor;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button addHarborButton;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button4;
	}
}