using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Uc;

namespace Me.Amon.Pwd.E.View
{
    public class ProPatternAction : APwdAction
    {
        public override void Add(ToolStripItem item, IViewModel viewModel)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
            Pwd.M.ViewModel model = viewModel as Pwd.M.ViewModel;
            if (model == null)
            {
                return;
            }

            bool ok = model.Pattern == CPwd.PATTERN_PRO;
            if (item is ToolStripMenuItem)
            {
                (item as ToolStripMenuItem).Checked = ok;
                return;
            }
            if (item is ToolStripButton)
            {
                (item as ToolStripButton).Checked = ok;
                return;
            }
        }

        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowAPro();
            }

            string cmd = null;
            if (sender is ToolStripItem)
            {
                ToolStripItem item = sender as ToolStripItem;
                object obj = item.Tag;
                if (obj == null || !(obj is string))
                {
                    return;
                }

                cmd = obj as string;
            }
            else if (sender is KeyStroke<APwd>)
            {
                KeyStroke<APwd> stroke = sender as KeyStroke<APwd>;
                cmd = stroke.Command;
            }

            if (string.IsNullOrWhiteSpace(cmd))
            {
                return;
            }

            foreach (string tmp in cmd.Split(';'))
            {
                string[] arr = cmd.Split(':');
                if (arr.Length != 2)
                {
                    continue;
                }

                ItemGroup group = IApp.GetItemGroup(arr[0]);
                if (group == null)
                {
                    continue;
                }
                group.Checked(arr[1]);
            }
        }
    }
}
