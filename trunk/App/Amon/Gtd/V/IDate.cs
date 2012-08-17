﻿using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    interface IDate
    {
        Control Control { get; }

        void ShowData(MGtd mgtd);

        bool SaveData(MGtd mgtd);
    }
}
