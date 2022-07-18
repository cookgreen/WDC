using DefendCastleScript.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WDC.Core;
using WDC.Game;
using WDC.Script;
using WDC.UI;
using WDC.Xml;

namespace DefendCastleScript
{
    public class DefendCastleScript : WDCScript
    {
        private List<Actor> defenderArchers;
        private Actor defenderArcher;
        private Actor enemySpearman;
        private Actor enemyKnight;
        private Actor enemyCrossbowman;

        private string scriptDataDir;
        private string iconFile;
        private int winHeight;
        private int winWidth;
        private Engine engine;

        public string Icon
        {
            get { return iconFile; }
        }

        public void Init(Engine engine)
        {
            this.engine = engine;

            defenderArchers = new List<Actor>();

            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth;
        }

        public void BeforeRunScript()
        {
            scriptDataDir = Path.Combine(Environment.CurrentDirectory, "Data//DefendCastleScript//");
            string scriptSpriteDataDir = Path.Combine(scriptDataDir, "Sprites");
            string scriptSettingsDataDir = Path.Combine(scriptDataDir, "Settings");
            string scriptIconDataDir = Path.Combine(scriptDataDir, "Icon");

            AnimatedSpriteInfoList animatedSpriteInfoList = AnimatedSpriteInfoList.Parse(Path.Combine(scriptSettingsDataDir, "anim.xml"));

            string spearmanSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "SpearmanSprite.png");
            string knightSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "KnightSprite.png");
            string crossbowmanSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "CrossbowmanSprite.png");
            string archerSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "ArcherSprite.png");

            AnimatedSpriteInfo spearmanSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Spearman").FirstOrDefault();
            AnimatedSpriteInfo knightSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Knight").FirstOrDefault();
            AnimatedSpriteInfo crossbowmanSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Crossbowman").FirstOrDefault();
            AnimatedSpriteInfo archerSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Archer").FirstOrDefault();

            AnimatedSprite spearmanSprite = new AnimatedSprite(new Bitmap(spearmanSpriteSheetBitmapFile), spearmanSpriteInfo, new PointF());
            AnimatedSprite knightSprite = new AnimatedSprite(new Bitmap(knightSpriteSheetBitmapFile), knightSpriteInfo, new PointF());
            AnimatedSprite crossbowmanSprite = new AnimatedSprite(new Bitmap(crossbowmanSpriteSheetBitmapFile), crossbowmanSpriteInfo, new PointF());
            AnimatedSprite archerSprite = new AnimatedSprite(new Bitmap(archerSpriteSheetBitmapFile), archerSpriteInfo, new PointF());

            enemySpearman = new Actor(spearmanSprite, new Dictionary<string, string>()
            {
                { "HP", "120"},
                { "Armour", "10"},
                { "Speed", "30"},
            });
            enemyKnight = new Actor(knightSprite, new Dictionary<string, string>()
            {
                { "HP", "240"},
                { "Armour", "30"},
                { "Speed", "15"},
            });
            enemyCrossbowman = new Actor(crossbowmanSprite, new Dictionary<string, string>()
            {
                { "HP", "180"},
                { "Armour", "17"},
                { "Speed", "18"},
                { "Damage", "25"},
            });
            defenderArcher = new Actor(archerSprite, new Dictionary<string, string>()
            {
                { "HP", "220"},
                { "Armour", "20"},
                { "Speed", "0"},
                { "Damage", "40"},
                { "PromotionHPRate", "0.5"},
            });

            for (int i = 0; i < 4; i++)
            {
                defenderArchers.Add(defenderArcher);
            }

            iconFile = Path.Combine(scriptIconDataDir, "icon.ico");
        }

        public void Render(Graphics g, IRenderer renderer)
        {
        }
    }
}
