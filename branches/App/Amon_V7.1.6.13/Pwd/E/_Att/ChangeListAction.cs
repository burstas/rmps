﻿namespace Me.Amon.Pwd.E._Att
{
    public class ChangeListAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ChangeAtt(Att.TYPE_LIST);
            }
        }
    }
}
