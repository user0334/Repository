using NLog;
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

		// Логгер
		private readonly Logger logger;


		//создание формы
		public FormHarbor()
		{
			InitializeComponent();
			harborCollection = new HarborCollection(pictureBoxHarbor.Width, pictureBoxHarbor.Height);
			logger = LogManager.GetCurrentClassLogger();
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
				try
				{
					if (harborCollection[listBox1.SelectedItem.ToString()] + boat)
					{
						Draw();
						logger.Info($"Добавлена лодка {boat}");
					}
					else
					{
						MessageBox.Show("Не удалось добавить");
					}
				}
				catch (HarborOverflowException ex)
				{
					MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (HarborAlreadyHaveException ex)
				{
					MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				try
				{
					var boat = harborCollection[listBox1.SelectedItem.ToString()] - Convert.ToInt32(textBox1.Text);
					if (boat != null)
					{
						Form1 form1 = new Form1();
						form1.SetBoat(boat);
						form1.ShowDialog();
					}
					logger.Info($"Изъята лодка {boat} с места {textBox1.Text}");

					Draw();
				}
				catch (HarborNotFoundException ex)
				{
					MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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
			logger.Info($"Добавили гавань {textBox2.Text}");
			harborCollection.AddHarbor(textBox2.Text);
			ReloadLevels();
		}

		//удалить гавань
		private void button4_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1)
			{
				if (MessageBox.Show($"Удалить гавань { listBox1.SelectedItem}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					harborCollection.DelHarbor(listBox1.SelectedItem.ToString());
					logger.Info($"Удалили гавань {listBox1.SelectedItem}");
					ReloadLevels();
				}
			}
		}

		//выбор гавани в списке названий
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			logger.Info($"Перешли в гавань { listBox1.SelectedItem}");
			Draw();
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					harborCollection.SaveData(saveFileDialog1.FileName);
					MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
					logger.Info("Сохранено в файл " + saveFileDialog1.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show("Не сохранилось", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					harborCollection.LoadData(openFileDialog1.FileName);
					MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
					logger.Info("Загружено из файла " + openFileDialog1.FileName);
					ReloadLevels();
					Draw();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
					MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void SortButton_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1)
			{
				harborCollection[listBox1.SelectedItem.ToString()].Sort();
				Draw();
				logger.Info("Сортировка уровней");
			}

		}
	}
}
