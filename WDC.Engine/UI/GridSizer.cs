using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public class GridSizer : Sizer
    {
        private readonly int column;
        private readonly int row;
        private List<GridSizerColumn> columns;
        private List<GridSizerRow> rows;
        private Dictionary<Tuple<int, int>, Tuple<Widget, int, int>> widgetPositions;

        public List<GridSizerColumn> Columns
        {
            get { return columns; }
        }
        public List<GridSizerRow> Rows
        {
            get { return rows; }
        }

        public GridSizer(int column, int row, Window window)
        {
            this.column = column;
            this.row = row;
            widgetPositions = new Dictionary<Tuple<int, int>, Tuple<Widget, int, int>>();
            columns = new List<GridSizerColumn>();
            rows = new List<GridSizerRow>();
        }

        public void AddWidget(int row, int col, Widget widget, int colSpan = 0, int rowSpan = 0)
        {
            Tuple<int, int> t1= new Tuple<int, int>(row, col);
            if(!widgetPositions.ContainsKey(t1))
            {
                Tuple<Widget, int, int> t2 = new Tuple<Widget, int, int>(widget, rowSpan, colSpan);
                widgetPositions.Add(t1, t2);
            }
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            base.Render(g, renderer);
        }
    }

    public class GridSizerColumn 
    {
    }

    public class GridSizerRow
    {

    }
}
