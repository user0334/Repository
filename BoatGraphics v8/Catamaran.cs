using System;
using System.Drawing;

namespace BoatGraphics
{
	//катамаран наследутеся от лодки
	public class Catamaran : Boat, IEquatable<Catamaran>
	{
		//дополнительный цвет
		public Color DopColor { private set; get; }
		//смена доп цвета
		public void SetDopColor(Color color) => DopColor = color;

		//признаки наличия поплавков и паруса
		public bool Floats { private set; get; }
		public bool Sail { private set; get; }

		//конструктор
		public Catamaran(int speed, double weight, Color bodyColor, Color dopColor, bool floats, bool sail) :
			base(speed, weight, bodyColor, 80, 140) //вызов родительского конструктора с установкой значений констант-размеров
		{
			DopColor = dopColor;
			Floats = floats;
			Sail = sail;
		}

		//конструктор для создания объекта из строки
		public Catamaran(string info) : base(info)
		{
			string[] strs = info.Split(_separator);
			if (strs.Length == 6)
			{
				DopColor = Color.FromName(strs[3]);
				//DopColor = Color.FromArgb(strs[3]);
				Floats = Convert.ToBoolean(strs[4]);
				Sail = Convert.ToBoolean(strs[5]);
			}

		}

		//переопределение метода перемещения
		public override void Move(Direction direction, int leftIndent = 25, int topIndent = 0)
		{
			base.Move(direction, leftIndent, topIndent);
		}

		//переопределение метода отрисовки
		public override void Draw(Graphics g)
		{
			if (!startPosX.HasValue || !startPosY.HasValue)
			{
				return;
			}
			
			Brush dopBrush = new SolidBrush(DopColor);
			//рисуется основная часть
			base.Draw(g);
			//поплавки по бокам
			if (Floats)
			{
				g.FillEllipse(dopBrush, (float)startPosX - 15, (float)startPosY + 10, 15, (float)(0.5 * boatHeight));
				g.FillEllipse(dopBrush, (float)startPosX + boatWidth - 2, (float)startPosY + 10, 15, (float)(0.5 * boatHeight));
			}
			//парус поверх корпуса
			if (Sail)
			{
				Pen pen = new Pen(Color.White);
				g.DrawArc(pen, (float)startPosX, (float)(startPosY + 0.55*boatHeight), boatWidth, 15, 0, 180);
			}	
		}

		public override string ToString() => $"{base.ToString()}{_separator}{DopColor.Name}{_separator}{Floats}{_separator}{Sail}";

		public bool Equals(Catamaran other)
		{
			return base.Equals(other) && (this.DopColor == other.DopColor) && (this.Sail == other.Sail) && (this.Floats == other.Floats);
		}
	}
}
