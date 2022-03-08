using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGraphics
{
	class Boat
	{
		public int Speed { get; private set; } //скорость
		public double Weight { get; private set; }
		public Color BodyColor { get; private set; }
		//координаты отрисовки
		private double? startPosX = null;
		private double? startPosY = null;
		//размеры области отрисовки
		private int? pictureWidth = null;
		private int? pictureHeight = null;
		//размеры объекта при отрисовке (константы)
		protected readonly int boatWidth = 60;
		protected readonly int boatHeight = 120;

		//задать значения свойствам
		public void Init(int speed, double weight, Color bodyColor)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
		}
		//задать позицию лодки
		public void SetPosition(int x, int y, int width, int height)
		{
			startPosX = x;
			startPosY = y;
			pictureWidth = width;
			pictureHeight = height;
		}

		//изменить границы отрисовки
		public void ChangeBorders(int width, int height)
		{
			pictureWidth = width;
			pictureHeight = height;
			if (startPosX + boatWidth > width)
			{
				startPosX = width - boatWidth;
			}
			if (startPosY + boatHeight > height)
			{
				startPosY = height - boatHeight;
			}
		}
		//установить направление движения
		public void Move(Direction direction)
		{
			//если не заданы границы
			if (!pictureWidth.HasValue || !pictureHeight.HasValue)
			{
				return;
			}
			double step = Speed * 100 / Weight; //перемещение зависит от скорости и веса
			switch (direction)
			{
				// вправо
				case Direction.Right:
					if (startPosX + boatWidth + step < pictureWidth)
					{
						startPosX += step;
					}
					break;
				//влево
				case Direction.Left:
					if (startPosX - step > 0)
					{
						startPosX -= step;
					}
					break;
				//вверх
				case Direction.Up:
					if (startPosY - step > 0)
					{
						startPosY -= step;
					}
					break;
				//вниз
				case Direction.Down:
					if (startPosY + boatHeight + step < pictureHeight)
					{
						startPosY += step;
					}
					break;
			}
		}
		//отрисовка лодки
		public void Draw(Graphics g)
		{
			if (!startPosX.HasValue || !startPosY.HasValue)
			{
				return;
			}


			//корпус лодки - многоугольник
			int x = (int)startPosX;
			int y = (int)startPosY;
			Point[] bodyPoints = { new Point(x, y), new Point(x, y + (int)(0.75 * boatHeight)), new Point(x+(int)(boatWidth/2), y + boatHeight),
								   new Point(x + boatWidth, y + (int)(0.75 * boatHeight)), new Point(x + boatWidth, y)};
			SolidBrush brush = new SolidBrush(BodyColor); //кисть для закраски
			g.FillPolygon(brush, bodyPoints);
			//кабина (или палуба) - синего цвета
			brush.Color = Color.Blue;
			g.FillEllipse(brush, x + boatWidth / 4, y + boatHeight / 8, boatWidth / 2, (int)(boatHeight * 0.55));
		}
	}
}
