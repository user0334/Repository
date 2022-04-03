using System.Collections.Generic;
using System.Drawing;

namespace BoatGraphics
{
	//параметривзированный класс Гавань
	public class Harbor<T> where T : class, IDrawObject
	{
		private readonly List<T> places; //список объектов
		private readonly int maxCount; //максимальное количество мест
		//размеры окна отрисовки
		private readonly int pictureWidth;
		private readonly int pictureHeight;
		//размеры затона для одного корабля
		private readonly int placeSizeWidth = 140;
		private readonly int placeSizeHeight = 160;

		//конструктор
		public Harbor(int picWidth, int picHeight)
		{
			int width = picWidth / placeSizeWidth;
			int height = picHeight / placeSizeHeight;
			maxCount = width * height; //возможное количество объектов получается из размеров
			pictureWidth = picWidth;
			pictureHeight = picHeight;
			places = new List<T>(); //пустой список
		}

		//перегрузка оператора сложения - добавить объект в массив
		public static bool operator +(Harbor<T> harbor, T boat)
		{
			if (harbor.places.Count < harbor.maxCount) //если список не заполнен
			{
				//int ii = i / (harbor.pictureWidth / harbor.placeSizeWidth);
				//int jj = i - (ii * (harbor.pictureWidth / harbor.placeSizeWidth));
				//boat.SetObject(jj * harbor.placeSizeWidth + 20, ii * harbor.placeSizeHeight + 5, harbor.pictureWidth, harbor.pictureHeight);
				harbor.places.Add(boat);
				return true;
			}
			else
				return false;
		}

		//перегрузка оператора вычитания - извлечь объект по номеру
		public static T operator -(Harbor<T> harbor, int index)
		{
			T result = null; //вернем либо null, либо объект
			if (index >= 0 && index < harbor.places.Count)
			{
				result = harbor.places[index]; //запоминаем объект
				harbor.places.RemoveAt(index); //удаляем из списка
			}
			return result;
		}

		//метод отрисовки гавани
		public void Draw(Graphics g)
		{
			DrawMarking(g);
			for (int i = 0; i < places.Count; i++)
			{
				int ii = i / (pictureWidth / placeSizeWidth);
				int jj = i - (ii * (pictureWidth /placeSizeWidth));
				places[i].SetObject(jj * placeSizeWidth + 20, ii * placeSizeHeight + 5, pictureWidth,pictureHeight);
				//places[i].SetObject(5 + i / 5 * placeSizeWidth + 5, i % 5 * placeSizeHeight + 15, pictureWidth, pictureHeight);
				places[i].DrawObject(g);
			}
		}


		//отрисовка затонов для кораблей
		private void DrawMarking(Graphics g)
		{
			Pen pen = new Pen(Color.Black, 3);
			for (int i = 0; i < pictureWidth / placeSizeWidth; i++)
			{
				for (int j = 0; j < pictureHeight / placeSizeHeight + 1; ++j)
				{
					//линия разметки
					g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight, 
						       i * placeSizeWidth + placeSizeWidth / 2, j * placeSizeHeight);
				}
				g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth, 
						   (pictureHeight / placeSizeHeight) * placeSizeHeight);
			}
		}

		// Функция получения элементов из списка
		public IEnumerable<T> GetNext()
		{
			foreach (var elem in places)
			{
				yield return elem;
			}
		}

	}
}
