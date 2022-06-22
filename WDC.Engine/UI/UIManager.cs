using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Game;
using System.Drawing;
using WDC.Core;

namespace WDC.UI
{
    public class UILayer
    {
        private List<UIObject> uiWidgets;

        public bool Visiable { get; set; }
        public List<UIObject> UIWidgets
        {
            get { return uiWidgets; }
        }

        public UILayer()
        {
            uiWidgets = new List<UIObject>();
        }

        public void Clear()
        {
            uiWidgets.Clear();
        }

        public void Render(Graphics g, IRenderer renderer)
        {
            foreach(var uiWidget in uiWidgets)
            {
                uiWidget.Render(g, renderer);
            }
        }
    }

    public class UIManager
    {
        private UILayer currentLayer;
        private Stack<UILayer> layerStack;
        private static UIManager instance;

        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIManager();
                }
                return instance;
            }
        }
        public UILayer CurrentLayer
        {
            get
            {
                return currentLayer;
            }
        }

        public UIManager()
        {
            instance = this;
            currentLayer = new UILayer();
            layerStack = new Stack<UILayer>();
            layerStack.Push(currentLayer);
        }

        public void StartNewWindow(Window window)
        {
            currentLayer.UIWidgets.Add(window);
        }

        public void StartNewWindowNewLayer(Window window)
        {
            currentLayer.Clear();
            layerStack.Pop();

            currentLayer = new UILayer();
            currentLayer.UIWidgets.Add(window);
            layerStack.Push(currentLayer);
        }

        public void StartNewWindowNewLayerKeepOld(Window window)
        {
            UILayer newLayer = new UILayer();
            newLayer.UIWidgets.Add(window);
            layerStack.Push(newLayer);
            currentLayer = newLayer;
        }

        public void InvisiableCurrentLayer()
        {
            UILayer newLayer = new UILayer();
            layerStack.Push(newLayer);
            currentLayer = newLayer;
            currentLayer.Visiable = false;
        }

        public void VisiableCurrentLayer()
        {
            if (!currentLayer.Visiable)
            {
                layerStack.Pop();
                currentLayer = layerStack.Peek();
            }
        }

        public void Render(Graphics g, IRenderer renderer)
        {
            currentLayer.Render(g, renderer);
        }
    }
}
