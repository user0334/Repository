using System.Collections.Generic;
using System.Linq;

namespace BoatGraphics
{
	public class HarborCollection
	{
		// Словарь (хранилище) с гаванями
		readonly Dictionary<string, Harbor<Boat>> harborStages;
		
		// Возвращение списка названий парковок
		public List<string> Keys => harborStages.Keys.ToList();
		// размеры окна отрисовки
		private readonly int pictureWidth;
		private readonly int pictureHeight;

		public HarborCollection(int pictureWidth, int pictureHeight)
		{
			harborStages = new Dictionary<string, Harbor<Boat>>();
			this.pictureWidth = pictureWidth;
			this.pictureHeight = pictureHeight;
		}
		//добавление гавани
		public void AddHarbor(string name)
		{
			if (!harborStages.ContainsKey(name))
				this.harborStages.Add(name, new Harbor<Boat>(pictureWidth, pictureHeight));
		}
		//удаление гавани по имени
		public void DelHarbor(string name)
		{
			if (this.harborStages.ContainsKey(name)) //если гавань с заданным именем есть
				harborStages.Remove(name);
		}
		//доступ к гавани - обращение к парковке по названию
		public Harbor<Boat> this[string ind]
		{
			get
			{
				if (harborStages.ContainsKey(ind))
					return harborStages[ind];
				else
					return null;
			}
			set
			{
				if (harborStages.ContainsKey(ind))
					harborStages[ind] = value;
			}
		}

	}
}
