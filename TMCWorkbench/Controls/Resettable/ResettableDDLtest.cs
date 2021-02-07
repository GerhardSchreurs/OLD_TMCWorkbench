using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMCWorkbench.Controls.Resettable
{
    public class ResettableDDLtest : ResettableDropDown
    {
        public ResettableDDLtest()
        {

        }

        public void Init()
        {
            var query = from tracker in DB.DBManager.Instance.Trackers
                        select new { tracker.Name, tracker.Tracker_id };

            Init(query.ToList(), "Name", "Tracker_id");
        }
    }
}
