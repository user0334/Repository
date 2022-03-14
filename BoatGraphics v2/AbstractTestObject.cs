using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGraphics
{
	//класс тестирования с общей логикой
	public abstract class AbstractTestObject
	{
		protected int pictureWidth;
		protected int pictureHeight;
		protected IDrawObject _object; //объект для тестировния

		//установка объекта
		public void Init(IDrawObject obj)
		{
			_object = obj;
		}

		//установка позиции
		public virtual bool SetPosition(int pictureWidth, int pictureHeight)
		{
			if (_object == null)
			{
				return false;
			}
			if (pictureWidth == 0 || pictureHeight == 0)
			{
				return false;
			}
			_object.SetObject(0, 0, pictureWidth, pictureHeight);
			this.pictureHeight = pictureHeight;
			this.pictureWidth = pictureWidth;
			return true;
		}
		//тестирование
		public abstract string TestObject();

	}
}
