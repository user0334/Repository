using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGraphics
{
	class HarborOverflowException : Exception
	{
		//исключение на случай, если вся гавань заполнена
		public HarborOverflowException() : base("В гавани нет свободных мест")
		{ }

	}
}
