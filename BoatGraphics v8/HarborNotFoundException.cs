using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatGraphics
{
	class HarborNotFoundException : Exception
	{
		public HarborNotFoundException(int i) : base("Не найдена лодка по месту " + i)
		{ }
	}
}
