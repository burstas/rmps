﻿namespace Me.Amon.Pwd.E.User
{
    public class PkeyAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.PkeyEdit();
            }
        }
    }
}
