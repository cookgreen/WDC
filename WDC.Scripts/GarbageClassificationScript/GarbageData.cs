using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageClassificationScript
{
	public enum GarbageBox
	{
		Box1,
		Box2,
		Box3,
		Box4,
	}

	public class GarbageData
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public Bitmap image { get; set; }
		public GarbageBox Box { get; set; }
	}
}
