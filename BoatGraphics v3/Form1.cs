using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoatGraphics
{
	public partial class Form1 : Form
	{
		IDrawObject boat; //объект-Лодка, который будет отрисовываться
		public Form1()
		{
			InitializeComponent();
		}

		public void SetBoat(IDrawObject boat)
		{
			this.boat = boat;
			Draw();
		}

		//отрисовка на форме
		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics gr = Graphics.FromImage(bmp);
			boat?.DrawObject(gr);
			pictureBox1.Image = bmp;
		}

		private void ButtonMove_Click(object sender, EventArgs e)
		{
			//получаем имя кнопки
			string name = (sender as Button).Name;
			switch (name)
			{
				case "buttonUp":
					boat?.MoveObject(Direction.Up);
					break;
				case "buttonDown":
					boat?.MoveObject(Direction.Down);
					break;
				case "buttonLeft":
					boat?.MoveObject(Direction.Left);
					break;
				case "buttonRight":
					boat?.MoveObject(Direction.Right);
					break;
			}
			Draw();
		}
	}
}
