using System;
using System.Drawing;
using System.Windows.Forms;

namespace BoatGraphics
{
	//Главная форма приложения - с полем для отрисовки гавани
	public partial class FormHarbor : Form
	{
		//коллекция гаваней
		private readonly HarborCollection harborCollection;
		//создание формы
		public FormHarbor()
		{
			InitializeComponent();
			harborCollection = new HarborCollection(pictureBoxHarbor.Width, pictureBoxHarbor.Height);
		}
		//заполнение listBox ключами из словаря
		private void ReloadLevels()
		{
			int index = listBox1.SelectedIndex;
			listBox1.Items.Clear();
			for (int i = 0; i < harborCollection.Keys.Count; i++)
			{
				listBox1.Items.Add(harborCollection.Keys[i]);
			}
			if (listBox1.Items.Count > 0 && (index == -1 || index >= listBox1.Items.Count))
			{
				listBox1.SelectedIndex = 0;
			}
			else if (listBox1.Items.Count > 0 && index > -1 && index < listBox1.Items.Count)
			{
				listBox1.SelectedIndex = index;
			}
		}

		//отрисовка выбранной гавани на форме
		private void Draw()
		{
			if (listBox1.SelectedIndex > -1)
			{
				Bitmap bmp = new Bitmap(pictureBoxHarbor.Width, pictureBoxHarbor.Height);
				Graphics g = Graphics.FromImage(bmp);
				harborCollection[listBox1.SelectedItem.ToString()].Draw(g);
				pictureBoxHarbor.Image = bmp;
			}
		}

		//Добавление объекта в класс-хранилище
		private void AddToHarbor(Boat boat)
		{
			if (boat != null && listBox1.SelectedIndex > -1)
			{
				if (harborCollection[listBox1.SelectedItem.ToString()] + boat)
				{
					Draw();
				}
				else
				{
					MessageBox.Show("Гавань переполнена");
				}
			}
		}
		//кнопка Добавить лодку
		private void button1_Click(object sender, EventArgs e)
		{
			var formBoatConfig = new FormBoatConfing();
			formBoatConfig.AddEvent(AddToHarbor);
			formBoatConfig.Show();

		}
		//кнопка пришвартовать катамаран
		private void button2_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					ColorDialog dialogDop = new ColorDialog();
					if (dialogDop.ShowDialog() == DialogResult.OK)
					{
						AddToHarbor(new Catamaran(100, 1000, dialog.Color, dialogDop.Color, true, true));
					}
				}
			}
		}

		//забрать лодку
		private void button3_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1 && textBox1.Text != "")
			{
				var boat = harborCollection[listBox1.SelectedItem.ToString()] - Convert.ToInt32(textBox1.Text);
				if (boat != null)
				{
					Form1 form1 = new Form1();
					form1.SetBoat(boat);
					form1.ShowDialog();
				}
				Draw();
			}
		}

		//нажатие на кнопку Добавить гавань
		private void addHarborButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				MessageBox.Show("Введите название гавани", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			harborCollection.AddHarbor(textBox2.Text);
			ReloadLevels();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1)
			{
				if (MessageBox.Show($"Удалить гавань { listBox1.SelectedItem}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					harborCollection.DelHarbor(listBox1.SelectedItem.ToString());
					ReloadLevels();
				}
			}
		}

		//выбор гавани в списке названий
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Draw();
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if (harborCollection.SaveData(saveFileDialog1.FileName))
				{
					MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Не сохранилось", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

		private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if (harborCollection.LoadData(openFileDialog1.FileName))
				{
					MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ReloadLevels();
					Draw();
				}
				else
				{
					MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
