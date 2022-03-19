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
	//Главная форма приложения - с полем для отрисовки гавани
	public partial class FormHarbor : Form
	{
		//объект класса Гавани
		private readonly Harbor<Boat> harbor;
		//создание формы
		public FormHarbor()
		{
			InitializeComponent();
			//создание объект Гавани
			harbor = new Harbor<Boat> (pictureBoxHarbor.Width, pictureBoxHarbor.Height);
			Draw(); //первая отрисовка
		}
		//отрисовка гавани на форме
		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBoxHarbor.Width, pictureBoxHarbor.Height);
			Graphics g = Graphics.FromImage(bmp);
			harbor.Draw(g);
			pictureBoxHarbor.Image = bmp;
		}

		//Добавление объекта в класс-хранилище
		private void AddToHarbor(Boat boat)
		{
			if (harbor + boat) //применяем перегрузку оператора
			{
				Draw();
			}
			else
			{
				MessageBox.Show("Парковка переполнена");
			}
		}
		//кнопка пришварторвать простую лодку
		private void button1_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				AddToHarbor(new Boat(100, 1000, dialog.Color));
			}

		}
		//кнопка пришвартовать катамаран
		private void button2_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				ColorDialog dialogDop = new ColorDialog();
				if (dialogDop.ShowDialog() == DialogResult.OK)
				{
					AddToHarbor(new Catamaran(100, 1000, dialog.Color, dialogDop.Color,true, true));
				}
			}
		}

		//забрать лодку
		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
			{
				var boat = harbor - Convert.ToInt32(textBox1.Text);
				if (boat != null)
				{
					Form1 form1 = new Form1();
					form1.SetBoat(boat);
					form1.ShowDialog();
				}
				Draw();
			}
		}
	}
}
