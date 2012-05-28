﻿using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class SaveIclAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            IApp.SaveFileDialog.Filter = EApp.FILE_SAVE_ICL;
            if (DialogResult.OK != IApp.SaveFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.SaveIcl(IApp.SaveFileDialog.FileName);
        }
    }
}
