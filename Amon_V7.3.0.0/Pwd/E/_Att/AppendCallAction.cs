﻿namespace Me.Amon.Pwd.E._Att
{
    public class AppendCallAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AppendAtt(Att.TYPE_CALL);
            }
        }
    }
}
