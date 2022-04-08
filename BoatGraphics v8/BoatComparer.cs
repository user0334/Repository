using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGraphics
{
	//класс реализующий сравнение объектов
	class BoatComparer : IComparer<IDrawObject>
	{
		public int Compare(IDrawObject x, IDrawObject y)
		{
			if (x != null && y != null) //объекты не пусты
			{
				if (x.GetType().Name.Equals("Boat") && y.GetType().Name.Equals("Boat"))
				{
					return ComparerBoat((Boat)x, (Boat)y); //сравнение простых лодок
				}
				else if (x.GetType().Name.Equals("Catamaran") && y.GetType().Name.Equals("Catamaran"))
				{
					return ComparerCatamaran((Catamaran)x, (Catamaran)y);
				}
				else if (x.GetType().Name.Equals("Boat") && y.GetType().Name.Equals("Catamaran"))
				{
					return -1; //лодка < катамарана
				}
				else
				{
					return 1;
				}
			}
			else
			{
				return 0;
			}
		}

		private int ComparerBoat(Boat x, Boat y)
		{
			if (x.Speed != y.Speed)
			{
				if (x.Speed < y.Speed)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else if (x.Weight != y.Weight)
			{
				if (x.Weight < y.Weight)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else if (!x.BodyColor.Equals(y.BodyColor))
			{
				if (x.BodyColor.ToArgb() < y.BodyColor.ToArgb())
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else
				return 0;
		}
		private int ComparerCatamaran(Catamaran x, Catamaran y)
		{
			if (x.Speed != y.Speed)
			{
				if (x.Speed < y.Speed)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else if (x.Weight != y.Weight)
			{
				if (x.Weight < y.Weight)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else if (!x.BodyColor.Equals(y.BodyColor))
			{
				if (x.BodyColor.ToArgb() < y.BodyColor.ToArgb())
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else if (x.Floats != y.Floats)
			{
				if (!x.Floats)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else if (x.Sail != y.Sail)
			{
				if (!x.Sail)
				{
					return -1;
				}
				else
				{
					return 1;
				}
			}
			else
				return 0;
		}
	}
}
