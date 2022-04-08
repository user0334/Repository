﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;

namespace BoatGraphics
{
	public class HarborCollection : IEnumerator<string>, IEnumerable<string>
	{
		// Словарь (хранилище) с гаванями
		readonly Dictionary<string, Harbor<Boat>> harborStages;
		
		// Возвращение списка названий парковок
		public List<string> Keys => harborStages.Keys.ToList();

		// Текущий элемент для вывода через IEnumerator (будет обращаться по своему индексу к ключу словаря, по которму будет возвращаться запись)
		private int currentIndex = -1;
		//возвращение текущего элемента
		public string Current => Keys[currentIndex];
		object IEnumerator.Current => Keys[currentIndex];

		// размеры окна отрисовки
		private readonly int pictureWidth;
		private readonly int pictureHeight;

		public HarborCollection(int pictureWidth, int pictureHeight)
		{
			harborStages = new Dictionary<string, Harbor<Boat>>();
			this.pictureWidth = pictureWidth;
			this.pictureHeight = pictureHeight;
		}
		//добавление гавани
		public void AddHarbor(string name)
		{
			if (!harborStages.ContainsKey(name))
				this.harborStages.Add(name, new Harbor<Boat>(pictureWidth, pictureHeight));
		}
		//удаление гавани по имени
		public void DelHarbor(string name)
		{
			if (this.harborStages.ContainsKey(name)) //если гавань с заданным именем есть
				harborStages.Remove(name);
		}
		//доступ к гавани - обращение к парковке по названию
		public Harbor<Boat> this[string ind]
		{
			get
			{
				if (harborStages.ContainsKey(ind))
					return harborStages[ind];
				else
					return null;
			}
			set
			{
				if (harborStages.ContainsKey(ind))
					harborStages[ind] = value;
			}
		}


		// Метод записи информации в файл
		private void WriteToFile(string text, FileStream stream)
		{
			byte[] info = new UTF8Encoding(true).GetBytes(text);
			stream.Write(info, 0, info.Length);
		}

		//разделитель при записи
		protected readonly char separator = ';';

		// Сохранение информации о лодках в файл
		public void SaveData(string filename)
		{
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (FileStream fs = new FileStream(filename, FileMode.Create))
			{
				WriteToFile($"HarborCollection{Environment.NewLine}", fs);
				foreach (var level in harborStages)
				{
					//Начинаем парковку
					WriteToFile($"Harbor{separator}{level.Key}{Environment.NewLine}", fs);
					foreach (var boat in level.Value.GetNext())
					{
						//если место не пустое
						if (boat != null)
						{
							WriteToFile($"{boat.GetType().Name}{separator}{boat}{ Environment.NewLine}", fs);
						}
					}
				}
			}
	}

		// Загрузка информации по автомобилям на парковках из файла
		public void LoadData(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new Exception("Файл не найден");
			}
			string bufferTextFromFile = "";
			using (FileStream fs = new FileStream(filename, FileMode.Open))
			{
				byte[] b = new byte[fs.Length];
				UTF8Encoding temp = new UTF8Encoding(true);
				while (fs.Read(b, 0, b.Length) > 0)
				{
					bufferTextFromFile += temp.GetString(b);
				}
			}
			var strs = bufferTextFromFile.Split(new char[] { '\n', '\r' },
			StringSplitOptions.RemoveEmptyEntries);
			if (!strs[0].Contains("HarborCollection"))
			{
				//если нет такой записи, то это не те данные
				throw new Exception("Неверный формат файла");
			}
			//очищаем записи
			harborStages.Clear();
			Boat boat = null;
			string key = string.Empty;
			for (int i = 1; i < strs.Length; ++i)
			{
				//идем по считанным записям
				if (strs[i].Contains("Harbor"))
				{
					//начинаем новую гавань
					key = strs[i].Split(separator)[1];
					harborStages.Add(key, new Harbor<Boat>(pictureWidth, pictureHeight));
					continue;
				}
				if (strs[i].Split(separator)[0] == "Boat")
				{
					boat = new Boat(strs[i].Replace("Boat" + separator, ""));
				}
				else if (strs[i].Split(separator)[0] == "Catamaran")
				{
					boat = new Catamaran(strs[i].Replace("Catamaran" + separator, ""));
				}
				_ = harborStages[key] + boat;
			}
		}

		public void Dispose()
		{
			//не потребуется
		}

		public void Reset() => currentIndex = -1;

		public bool MoveNext()
		{
			currentIndex++;
			return (currentIndex < Keys.Count);
		}

		//Получение ссылки на объект от класса, реализующего IEnumerator
		public IEnumerator<string> GetEnumerator() => this;

		// Получение ссылки на объект от класса, реализующего IEnumerator
		IEnumerator IEnumerable.GetEnumerator() => this;


	}
}
