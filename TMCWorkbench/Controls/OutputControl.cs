using ModLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCDatabase.DBModel;
using TMCWorkbench.Model;

namespace TMCWorkbench.Controls
{
    public partial class OutputControl : UserControl
    {
        private bool showYoutube = false;
        private Bag _bag;
        private ModInfo _mod;
        private Track _track;
        private MetaDataControl _meta;
        private long _duration;
        private const string HEADER = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■";
        private readonly Regex _regRemoveNewLines = new Regex("(\r\n){2,}");
        private readonly Regex _regRemoveSpaces = new Regex("[ ]{1,}");
        private readonly Regex _regRemoveLeadingStringSpace = new Regex("^\\s", RegexOptions.Multiline);
        private readonly Regex _regLimitRemoveNewLines = new Regex("(\r?\n)");


        public void Init(Bag bag, MetaDataControl ctrMetaData, string footer)
        {
            if (ctrMetaData == null) throw new ArgumentException("MetaData is null");

            _meta = ctrMetaData;
            _mod = bag.Mod;
            _track = bag.Track;
            _duration = bag.Duration;
            _bag = bag;

            Clear();

            Refresh(_mod.SampleText, _mod.InstrumentText, _mod.SongText, footer);

            //var header = GenerateHeader();
            //var footer = footer;
            //var summary = GenerateSummary(header, footer);
        }

        public void Refresh(string samples, string instruments, string message, string footer)
        {
            var header = GenerateHeader();
            var summary = GenerateSummary(samples, instruments, message, header, footer);

            this.TextHeaderNew = header;
            this.TextSummaryNew = summary;
            this.TextFooterNew = footer;

            if (_bag.IsInDB)
            {
                //Org becomes db
                this.TextHeaderOrg = _track.YoutubeTextHeader;
                this.TextSummaryOrg = _track.YoutubeTextSummary;
                this.TextFooterOrg = _track.YoutubeTextFooter;
            }
            else
            {
                this.TextHeaderOrg = header;
                this.TextSummaryOrg = summary;
                this.TextFooterOrg = footer;
            }
        }

        private string GenerateParagraph(string title, string text)
        {
            if (text.IsNullOrEmpty()) return string.Empty;
            return $"{title}{C.BR}{HEADER}{C.BR}{text}{C.BR}{C.BR}";
        }

        private string CleanUpText(string text)
        {
            if (text.IsNullOrEmpty()) return string.Empty;

            //First, remove all newlines over 2
            text = _regRemoveNewLines.Replace(text, $"{C.BR}{C.BR}");
            text = text.Replace($"{C.BR}{C.BR}{C.BR}", $"{C.BR}{C.BR}");
            text = _regRemoveSpaces.Replace(text, " ");
            text = _regRemoveLeadingStringSpace.Replace(text, "");

            return text.Trim();
        }

        private string GenerateSummary(string samples_org, string instruments_org, string message_org, string header, string footer)
        {
            var output = new StringBuilder();

            var message = GenerateParagraph("MESSAGE", CleanUpText(message_org));
            var samples = GenerateParagraph("SAMPLES", CleanUpText(samples_org));
            var instruments = GenerateParagraph("INSTRUMENTS", CleanUpText(instruments_org));

            //Count 
            if (CountMessage() > C.YOUTUBEMAXLENGTH)
            {
                MessageBox.Show($"Over youtube limit 1: {CountMessage()}");
                //Try to shorten message
                message = _regLimitRemoveNewLines.Replace(message, "");
                message = RemoveHeader(message);
            }

            if (CountMessage() > C.YOUTUBEMAXLENGTH)
            {
                MessageBox.Show($"Over youtube limit 2: {CountMessage()}");
                //Try to shorten samples 
                samples = _regLimitRemoveNewLines.Replace(samples, "");
                samples = RemoveHeader(samples);
            }

            if (CountMessage() > C.YOUTUBEMAXLENGTH)
            {
                MessageBox.Show($"Over youtube limit 2: {CountMessage()}");
                //Try to shorten instruments 
                instruments = _regLimitRemoveNewLines.Replace(instruments, "");
                instruments = RemoveHeader(instruments);
            }

            if (CountMessage() > C.YOUTUBEMAXLENGTH)
            {
                MessageBox.Show($"Failed: {CountMessage()}");
                //Try to shorten instruments 
            }

            int CountMessage()
            {
                return header.Length + footer.Length + samples.Length + instruments.Length + message.Length;
            }

            string RemoveHeader(string s)
            {
                return s.Replace(HEADER, ": ");
            }

            output.Append(message);
            output.Append(samples);
            output.Append(instruments);

            var text = output.ToString().Trim();
            return text;
        }

        private string GenerateHeader()
        {
            //Artificial Sun(ARTIFSUN.IT) is a 120 bpm Impulse Tracker Noise track that was created in 1997
            //C djnonsens of eXploitation.

            //Acid Rain (ACIDRAIN.IT) is a 140 bpm alternative Impulse tracker track that was created in 1998.
            //© djnonsens of eXploitation.

            //Acid Rain (ACIDRAIN.IT) is an impulse tracker alternative track at 140 bpm that was created in 1998.
            //© djnonsens of eXploitation.

            //Acid Rain(ACIDRAIN.IT) is a 140 bpm Impulse tracker rave style track. 
            //© 1998 - djnonsens of eXploitation.

            //Alisia went home(ALISIA.MOD) is a 125 bpm Protracker track that was created in 1997.
            //© Unknown.

            var fileName = _meta.FileName;
            var title = _meta.TrackTitle;
            var style = _meta.GetStyleCalulated();
            var date = _meta.Date.HasValue ? _meta.Date.Value : new DateTime(1900, 1, 1);
            var composer = _meta.GetComposerCalculated();
            var scenegroup = _meta.GetScenegroupCalulated();
            var tracker = _meta.Tracker;
            var bpm = _meta.Bpm;

            var text = new StringBuilder();

            if (title.IsNullOrEmpty())
            {
                text.Append($"{fileName} ");
            }
            else
            {
                text.Append($"{title} ({fileName}) ");
            }

            text.Append($"is a {bpm} bpm ");

            if (style.IsNotNullOrEmpty())
            {
                text.Append($"{style} ");
            }

            text.Append($"track.");
            text.AppendLine();
            text.Append($"© {date.Year} - ");

            if (composer.IsNotNullOrEmpty() && scenegroup.IsNotNullOrEmpty())
            {
                text.Append($"{composer} of {scenegroup}.");
            }
            else if (composer.IsNotNullOrEmpty())
            {
                text.Append($"{composer}.");
            }
            else if (scenegroup.IsNotNullOrEmpty())
            {
                text.Append($"{scenegroup}.");
            }
            else
            {
                text.Append("Unknown.");
            }

            text.Append($" Tracked with {tracker}.");

            return text.ToString().Trim();
        }

        public void Clear()
        {
            txtHeader.Clear();
            txtHeaderYT.Clear();
            txtSummary.Clear();
            txtSummaryYT.Clear();
            txtFooter.Clear();
            txtFooterYT.Clear();
        }

        public string TextHeaderOrg
        {
            get => txtHeader.TextOrg;
            set
            {
                txtHeader.TextOrg = value;
                txtHeaderYT.TextOrg = value;
            }
        }

        public string TextHeaderNew
        {
            get => txtHeader.TextNew;
            set
            {
                txtHeader.TextNew = value;
                txtHeaderYT.TextNew = value;
            }
        }

        public string TextSummaryOrg
        {
            get => txtSummary.TextOrg;
            set
            {
                txtSummary.TextOrg = value;
                txtSummaryYT.TextOrg = value;
            }
        }

        public string TextSummaryNew
        {
            get => txtSummary.TextNew;
            set
            {
                txtSummary.TextNew = value;
                txtSummaryYT.TextNew = value;
            }
        }

        public string TextFooterOrg
        {
            get => txtFooter.TextOrg;
            set
            {
                txtFooter.TextOrg = value;
                txtFooterYT.TextOrg = value;
            }
        }

        public string TextFooterNew
        {
            get => txtFooter.TextNew;
            set
            {
                txtFooter.TextNew = value;
                txtFooterYT.TextNew = value;
            }
        }

        public string TextOutput
        {
            get
            {
                var output = $"{TextHeaderNew.Trim()}{C.BR}{C.BR}{TextSummaryNew.Trim()}";
                if (TextFooterNew.IsNotNullOrEmpty())
                {
                    output = $"{output}{C.BR}{C.BR}{TextFooterNew.Trim()}";
                }

                return output;
            }
        }

        public OutputControl()
        {
            InitializeComponent();

            DockFill();
            ShowNew();
        }

        public void Show(bool showNew = true)
        {
            if (showNew)
                ShowNew();
            else
                ShowOld();
        }


        public void ShowNew()
        {
            if (showYoutube)
                ShowNewYoutube();
            else
                ShowNewOriginal();
        }

        public void ShowOld()
        {
            if (showYoutube)
                ShowOldYoutube();
            else
                ShowOldOriginal();
        }

        void DockFill()
        {
            txtHeader.Dock = DockStyle.Fill;
            txtSummary.Dock = DockStyle.Fill;
            txtFooter.Dock = DockStyle.Fill;

            txtHeaderYT.Dock = DockStyle.Fill;
            txtSummaryYT.Dock = DockStyle.Fill;
            txtFooterYT.Dock = DockStyle.Fill;
        }

        private void ShowNewOriginal()
        {
            txtHeaderYT.Visible = false;
            txtSummaryYT.Visible = false;
            txtFooterYT.Visible = false;

            txtHeader.Visible = true;
            txtSummary.Visible = true;
            txtFooter.Visible = true;

            txtHeader.ShowNew();
            txtSummary.ShowNew();
            txtFooter.ShowNew();
        }

        private void ShowNewYoutube()
        {
            txtHeader.Visible = false;
            txtSummary.Visible = false;
            txtFooter.Visible = false;

            txtHeaderYT.TextNew = txtHeader.TextNew; //?

            txtHeaderYT.Visible = true;
            txtSummaryYT.Visible = true;
            txtFooterYT.Visible = true;

            txtHeaderYT.ShowNew();
            txtSummaryYT.ShowNew();
            txtFooterYT.ShowNew();
        }

        private void ShowOldOriginal()
        {
            txtHeaderYT.Visible = false;
            txtSummaryYT.Visible = false;
            txtFooterYT.Visible = false;

            txtHeader.Visible = true;
            txtSummary.Visible = true;
            txtFooter.Visible = true;

            txtHeaderYT.ShowOld();
            txtSummary.ShowOld();
            txtFooter.ShowOld();
        }

        private void ShowOldYoutube()
        {
            txtHeader.Visible = false;
            txtSummary.Visible = false;
            txtFooter.Visible = false;

            txtHeaderYT.TextNew = txtHeader.TextNew; //?

            txtHeaderYT.Visible = true;
            txtSummaryYT.Visible = true;
            txtFooterYT.Visible = true;

            txtHeaderYT.ShowOld();
            txtSummaryYT.ShowOld();
            txtFooterYT.ShowOld();
        }
    }
}
