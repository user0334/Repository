using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoatGraphics
{
	public partial class FormBoatConfing : Form
	{
		Boat boat = null; //объектная переменная для отображения на форме

		//Событие
		private event BoatDelegate EventAddBoat;

		public FormBoatConfing()
		{
			InitializeComponent();
			buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
			this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
			this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
			this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
			this.panel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
			this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
			this.panel8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
			this.panel9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
		}
		//отрисовка лодки
		private void DrawBoat()
		{
			if (boat != null)
			{
				Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
				Graphics gr = Graphics.FromImage(bmp);
				boat.SetPosition(20, 5, pictureBox1.Width, pictureBox1.Height);
				boat.Draw(gr);
				pictureBox1.Image = bmp;
			}
		}

		// Добавление события
		public void AddEvent(BoatDelegate ev)
		{
			if (EventAddBoat == null)
			{
				EventAddBoat = new BoatDelegate(ev);
			}
			else
			{
				EventAddBoat += ev;
			}
		}

		//проверка получаемой информации
		private void panel1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		//действие при приеме перетаскиваемой информации
		private void panel1_DragDrop(object sender, DragEventArgs e)
		{
			switch (e.Data.GetData(DataFormats.Text).ToString())
			{
				case "boatLabel":
					boat = new Boat((int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, Color.White);
					break;
				case "catamaranLabel":
					boat = new Catamaran((int)numericUpDownSpeed.Value, (int)numericUpDownWeight.Value, Color.White, Color.Black, checkBoxFloats.Checked, checkBoxSail.Checked);
					break;
			}
			DrawBoat();
		}

		// Проверка получаемой информации (ее типа на соответствие требуемому)
		private void labelMainColor_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Color)))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void labelMainColor_DragDrop(object sender, DragEventArgs e)
		{
			if (sender is Control)
			{
				boat?.SetMainColor((Color)e.Data.GetData(typeof(Color)));
			}
			DrawBoat();
		}

		// отправляем цвет с панели
		private void PanelColor_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Panel).DoDragDrop((sender as Panel).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
		}

		private void LabelDopColor_DragDrop(object sender, DragEventArgs e)
		{
			if (sender is Control && boat is Catamaran)
			{
				((Catamaran)boat)?.SetDopColor((Color)e.Data.GetData(typeof(Color)));
			}
			DrawBoat();
		}

		//добавление машины
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			EventAddBoat?.Invoke(boat); //срабатывание события
			Close();
		}

		// передаем информацию при нажатии на Label
		private void LabelObject_MouseDown(object sender, MouseEventArgs e)
		{
			(sender as Label).DoDragDrop((sender as Label).Name, DragDropEffects.Move | DragDropEffects.Copy);
		}
	}
}
