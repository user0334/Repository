using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoatGraphics
{
	//параметривзированный класс Гавань
	public class Harbor<T> where T : class, IDrawObject
	{
		private readonly T[] places; //массив объектов
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
			places = new T[width * height]; //возможное количество объектов получается из размеров
			pictureWidth = picWidth;
			pictureHeight = picHeight;
		}

		//перегрузка оператора сложения - добавить объект в массив
		public static bool operator +(Harbor<T> harbor, T boat)
		{
			for (int i = 0; i < harbor.places.Length; i++)
			{
				if (harbor.places[i] == null)
				{
					int ii = i / (harbor.pictureWidth / harbor.placeSizeWidth);
					int jj = i - (ii * (harbor.pictureWidth / harbor.placeSizeWidth));
					boat.SetObject(jj * harbor.placeSizeWidth + 20, ii * harbor.placeSizeHeight + 5, harbor.pictureWidth, harbor.pictureHeight);
					harbor.places[i] = boat;
					return true;
				}
			}
			return false;
		}

		//перегрузка оператора вычитания - извлечь объект по номеру
		public static T operator -(Harbor<T> harbor, int index)
		{
			T result = harbor.places[index];
			if (result != null)
			{
				harbor.places[index] = null;
			}
			return result;
		}
		//метод отрисовки гавани
		public void Draw(Graphics g)
		{
			DrawMarking(g);
			for (int i = 0; i < places.Length; i++)
			{
				places[i]?.DrawObject(g);
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
					//линия рамзетки
					g.DrawLine(pen, i * placeSizeWidth, j * placeSizeHeight, 
						       i * placeSizeWidth + placeSizeWidth / 2, j * placeSizeHeight);
				}
				g.DrawLine(pen, i * placeSizeWidth, 0, i * placeSizeWidth, 
						   (pictureHeight / placeSizeHeight) * placeSizeHeight);
			}
		}
	}
}
