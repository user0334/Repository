using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoatGraphics
{
	public partial class Form1 : Form
	{
		Boat boat; //объект-Лодка, который будет отрисовываться
		public Form1()
		{
			InitializeComponent();
		}

		//отрисовка на форме
		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics gr = Graphics.FromImage(bmp);
			boat?.Draw(gr);
			pictureBox1.Image = bmp;
		}

		//изменение размеров отрисовки
		private void pictureBox1_Resize(object sender, EventArgs e)
		{
			boat.ChangeBorders(pictureBox1.Width, pictureBox1.Height);
			Draw();
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			boat = new Boat(); //новая лодка
			//случайые координаты и цвет
			boat.Init(rnd.Next(100, 300), rnd.Next(1000, 2000),
			Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
			boat.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBox1.Width, pictureBox1.Height);
			toolStripStatusLabel1.Text = "Скорость:" + boat.Speed;
			toolStripStatusLabel2.Text = "Вес: " + boat.Weight;
			toolStripStatusLabel3.Text = "Цвет: " + boat.BodyColor.Name;
			Draw();
		}

		private void ButtonMove_Click(object sender, EventArgs e)
		{
			//получаем имя кнопки
			string name = (sender as Button).Name;
			switch (name)
			{
				case "buttonUp":
					boat?.Move(Direction.Up);
					break;
				case "buttonDown":
					boat?.Move(Direction.Down);
					break;
				case "buttonLeft":
					boat?.Move(Direction.Left);
					break;
				case "buttonRight":
					boat?.Move(Direction.Right);
					break;
			}
			Draw();
		}
	}
}
