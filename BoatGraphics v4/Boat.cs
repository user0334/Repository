using System.Drawing;

namespace BoatGraphics
{
	//теперь лодка реализует интерфейс IDrawObject
	public class Boat : IDrawObject
	{
		public int Speed { get; private set; } //скорость
		public double Weight { get; private set; }
		public Color BodyColor { get; private set; }
		//добавляется расчет шага как поле класса
		public double Step => Speed * 100 / Weight;
		//координаты отрисовки
		protected double? startPosX = null;
		protected double? startPosY = null;
		//размеры области отрисовки
		private int? pictureWidth = null;
		private int? pictureHeight = null;
		//размеры объекта при отрисовке (константы)
		protected readonly int boatWidth = 60;
		protected readonly int boatHeight = 120;
		//признак перемещения объекта
		private bool makeStep;

		//конструктор класса
		public Boat(int speed, double weight, Color bodyColor)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
		}
		//расширенный конструктор
		protected Boat(int speed, double weight, Color bodyColor, int boatWidth, int boatHeight)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
			this.boatWidth = boatWidth;
			this.boatHeight = boatHeight;
		}

		//!!! задать позицию лодки
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
		//метод становится виртуальным, добавляем два параметра - отступы
		public virtual void Move(Direction direction, int leftIndent = 0, int topIndent = 0)
		{
			makeStep = false;
			//если не заданы границы
			if (!pictureWidth.HasValue || !pictureHeight.HasValue)
			{
				return;
			}
			switch (direction)
			{
				// вправо
				case Direction.Right:
					if (startPosX + boatWidth + Step + leftIndent < pictureWidth)
					{
						startPosX += Step;
						makeStep = true;
					}
					break;
				//влево
				case Direction.Left:
					if (startPosX - Step - leftIndent > 0)
					{
						startPosX -= Step;
						makeStep = true;
					}
					break;
				//вверх
				case Direction.Up:
					if (startPosY - Step - topIndent > 0)
					{
						startPosY -= Step;
						makeStep = true;
					}
					break;
				//вниз
				case Direction.Down:
					if (startPosY + boatHeight + Step + topIndent < pictureHeight)
					{
						startPosY += Step;
						makeStep = true;
					}
					break;
			}
		}
		//отрисовка лодки (метод теперь вирутальный)
		public virtual void Draw(Graphics g)
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

		//реализация методов интерфейса
		public void SetObject(float x, float y, int width, int height)
		{
			startPosX = x;
			startPosY = y;
			pictureWidth = width;
			pictureHeight = height;
		}

		public bool MoveObject(Direction direction)
		{
			Move(direction); //вызов реализованного метода
			return makeStep;
		}

		public void DrawObject(Graphics g)
		{
			Draw(g);
		}

		public (double Left, double Right, double Top, double Bottom) GetCurrentPosition()
		{
			return (startPosX.Value, startPosX.Value + boatWidth,
					startPosY.Value, startPosY.Value + boatHeight);
		}

	}
}
