﻿using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdq
{
    public interface IInput
    {
        Control Control { get; }

        bool Check();

        string Value { get; set; }

        Param Param { get; set; }
    }
}