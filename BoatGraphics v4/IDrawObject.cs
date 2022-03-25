using System.Drawing;

namespace BoatGraphics
{
	public interface IDrawObject
	{
		double Step { get; }
		Color BodyColor { get; }

		//установка позиции
		void SetObject(float x, float y, int width, int height);
		//метод перемещения
		bool MoveObject(Direction direction);
		//метод отрисовки
		void DrawObject(Graphics g);
		//текущая позиция в виде кортежа
		(double Left, double Right, double Top, double Bottom) GetCurrentPosition();
	}
}
