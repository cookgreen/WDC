using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Physics
{
	public class CollideManager
	{
		private static CollideManager instance;
		public static CollideManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CollideManager();
				}
				return instance;
			}
		}

		public CollideManager()
		{ 
		}
	}
}
