﻿namespace Me.Amon.Pwd.E._Att
{
    public class EditPasteAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.PasteAtt();
            }
        }
    }
}