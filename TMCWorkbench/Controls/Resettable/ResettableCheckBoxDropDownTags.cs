using System.Linq;
using TMCWorkbench.DB;

namespace TMCWorkbench.Controls.Resettable
{
    public class ResettableCheckBoxDropDownTags : ResettableCheckBoxDropDown, IRefreshableInit
    {
        private UCTags _form;

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
