﻿namespace Me.Amon.Pwd.E.View
{
    public class WizPatternAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ShowAWiz();
            }
        }
    }
}
