using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public enum ViewType
    {
        Tile,
        Icon,
        Details
    }
    public class GDIListViewItem
    {
        public Image Image { get; set; }
        public string Text { get; set; }
    }

    public class GDIListView : Widget
    {
        private ViewType viewType;
        private List<GDIListViewItem> items;
        public List<GDIListViewItem> Items { get { return items; } }

        public GDIListView(ViewType viewType)
        {
            this.viewType = viewType;
            items = new List<GDIListViewItem>();
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            switch(viewType)
            {
                case ViewType.Tile:
                    
                    break;
                case ViewType.Icon:
                    break;
                case ViewType.Details:
                    break;
            }
        }
    }
}
