using WDC.Xml;

namespace SpriteSheetGenerator
{
    public partial class frmMain : Form
    {
        private SpriteSheetConfig sheetConfig;
        private Dictionary<string, Tuple<int, bool, ImageList.ImageCollection>> sequences;

        public frmMain(SpriteSheetConfig sheetConfig, string defaultSequenceName)
        {
            InitializeComponent();
            this.sheetConfig = sheetConfig;
            sequenceList.TabPages[0].Text = defaultSequenceName;
            sequences = new Dictionary<string, Tuple<int,bool, ImageList.ImageCollection>>
            {
                { defaultSequenceName, null }
            };

            mnuEditDeleteSequence.DropDownItems.Clear();
            mnuEditDeleteSequence.DropDownItems.Add(defaultSequenceName).Click += SequenceItem_Click; ;
        }

        private void SequenceItem_Click(object? sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            string sequenceName = item.Text;
            if(sequences.ContainsKey(sequenceName))
            {
                sequences.Remove(sequenceName);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            sequences.Clear();
            foreach(TabPage tabPage in sequenceList.TabPages)
            {
                var control = tabPage.Controls[0] as ucSpriteSequence;
                sequences[tabPage.Text] = new Tuple<int, bool, ImageList.ImageCollection>(
                    control.Start, control.IsLoop, control.Images);
            }

            frmSaveSpriteDialog saveSpriteWin = new frmSaveSpriteDialog(sheetConfig, sequences);
            saveSpriteWin.ShowDialog();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mnuEditDeleteSequence.DropDownItems.Count == 1)
            {
                mnuEditDeleteSequence.Enabled = false;
            }
            else
            {
                mnuEditDeleteSequence.Enabled = true;
            }

            mnuEditDeleteSequence.DropDownItems.Clear();
            var sequenceNames = sequences.Keys;
            for (int i = 0; i < sequenceNames.Count; i++)
            {
                var item = mnuEditDeleteSequence.DropDownItems.Add(sequenceNames.ElementAt(i));
                item.Click += SequenceItem_Click;
            }
        }

        private void mnuEditNewSequence_Click(object sender, EventArgs e)
        {
            frmSequence sequenceWin = new frmSequence();
            if(sequenceWin.ShowDialog() == DialogResult.OK)
            {
                TabPage page = new TabPage();
                page.Text = sequenceWin.NewSequenceName;
                
                ucSpriteSequence ucSpriteSequence = new ucSpriteSequence();
                ucSpriteSequence.Dock = DockStyle.Fill;
                
                page.Controls.Clear();
                page.Controls.Add(ucSpriteSequence);
                sequenceList.TabPages.Add(page);

                sequences.Add(sequenceWin.NewSequenceName, null);
            }

        }
    }
}