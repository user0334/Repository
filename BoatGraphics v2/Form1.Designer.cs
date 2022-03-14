
namespace BoatGraphics
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonUp = new System.Windows.Forms.Button();
			this.buttonLeft = new System.Windows.Forms.Button();
			this.buttonDown = new System.Windows.Forms.Button();
			this.buttonRight = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonTest = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(743, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(743, 428);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
			// 
			// buttonCreate
			// 
			this.buttonCreate.Location = new System.Drawing.Point(12, 391);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(100, 23);
			this.buttonCreate.TabIndex = 2;
			this.buttonCreate.Text = "Новая лодка";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonUp
			// 
			this.buttonUp.Location = new System.Drawing.Point(596, 362);
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new System.Drawing.Size(55, 23);
			this.buttonUp.TabIndex = 3;
			this.buttonUp.Text = "Вверх";
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Click += new System.EventHandler(this.ButtonMove_Click);
			// 
			// buttonLeft
			// 
			this.buttonLeft.Location = new System.Drawing.Point(533, 391);
			this.buttonLeft.Name = "buttonLeft";
			this.buttonLeft.Size = new System.Drawing.Size(57, 23);
			this.buttonLeft.TabIndex = 4;
			this.buttonLeft.Text = "Влево";
			this.buttonLeft.UseVisualStyleBackColor = true;
			this.buttonLeft.Click += new System.EventHandler(this.ButtonMove_Click);
			// 
			// buttonDown
			// 
			this.buttonDown.Location = new System.Drawing.Point(596, 391);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new System.Drawing.Size(57, 23);
			this.buttonDown.TabIndex = 5;
			this.buttonDown.Text = "Вниз";
			this.buttonDown.UseVisualStyleBackColor = true;
			this.buttonDown.Click += new System.EventHandler(this.ButtonMove_Click);
			// 
			// buttonRight
			// 
			this.buttonRight.Location = new System.Drawing.Point(659, 391);
			this.buttonRight.Name = "buttonRight";
			this.buttonRight.Size = new System.Drawing.Size(57, 23);
			this.buttonRight.TabIndex = 7;
			this.buttonRight.Text = "Вправо";
			this.buttonRight.UseVisualStyleBackColor = true;
			this.buttonRight.Click += new System.EventHandler(this.ButtonMove_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 391);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Новый катамаран";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonTest
			// 
			this.buttonTest.Location = new System.Drawing.Point(12, 12);
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Size = new System.Drawing.Size(100, 23);
			this.buttonTest.TabIndex = 9;
			this.buttonTest.Text = "Провести тест";
			this.buttonTest.UseVisualStyleBackColor = true;
			this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Выход за границы"});
			this.comboBox1.Location = new System.Drawing.Point(128, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(743, 450);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.buttonTest);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonRight);
			this.Controls.Add(this.buttonDown);
			this.Controls.Add(this.buttonLeft);
			this.Controls.Add(this.buttonUp);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Перещение графического объекта - Лодка";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button buttonUp;
		private System.Windows.Forms.Button buttonLeft;
		private System.Windows.Forms.Button buttonDown;
		private System.Windows.Forms.Button buttonRight;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonTest;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}

