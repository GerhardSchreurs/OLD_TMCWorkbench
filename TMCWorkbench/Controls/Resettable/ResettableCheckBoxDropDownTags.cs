using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCDatabase.DBModel;
using TMCWorkbench.DB;

namespace TMCWorkbench.Controls.Resettable
{
    public class ResettableCheckBoxDropDownTags : ResettableCheckBoxDropDown, IRefreshableInit
    {
        private UCTags _form;

        private List<C_Track_Tag> _trackTagsWithTag;

        private void UpdateTracksWithTag()
        {
            if (_trackTagsWithTag == null)
                _trackTagsWithTag = DBManager.Instance.TracksTagsWithTag.ToList();
        }

        public void Update(int trackId)
        {
            if (trackId <= 0) return;
            UpdateTracksWithTag();

            var ids = _trackTagsWithTag.Where(x => x.FK_track_id == trackId);

        }


        public void Init(bool refresh = false)
        {
            if (_form == null) _form = new UCTags();

            DBManager.Instance.LoadTags(refresh);

            var selectQuery = from tag in DBManager.Instance.Tags
                        select new { tag.Name, tag.Tag_id };

            Init(_form, selectQuery, "Name", "Tag_id");
        }
    }
}
