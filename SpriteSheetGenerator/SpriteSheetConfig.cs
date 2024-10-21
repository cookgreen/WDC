using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetGenerator
{
    public enum SpriteSheetOrientation
    {
        Vertical,
        Horizontal
    }

    public class SpriteSheetConfig
    {
        private Size sheetSize;
        private Size spriteSize;
        private SpriteSheetOrientation orientation;

        public Size SheetSize { get { return sheetSize; } }
        public Size SpriteSize { get { return spriteSize; } }
        public SpriteSheetOrientation Orientation { get { return orientation; } }

        public SpriteSheetConfig(Size sheetSize, Size spriteSize) 
        {
            this.sheetSize = sheetSize;
            this.spriteSize = spriteSize;

            if (sheetSize.Width >= spriteSize.Height)
            {
                orientation = SpriteSheetOrientation.Horizontal;
            }
            else if (sheetSize.Width < spriteSize.Height)
            {
                orientation= SpriteSheetOrientation.Vertical;
            }
        }
        public SpriteSheetConfig(SpriteSheetOrientation orientation, Size spriteSize)
        {
            this.orientation = orientation;
            this.spriteSize = spriteSize;
        }
    }
}
