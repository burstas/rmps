﻿using Me.Amon.Uc;

namespace Me.Amon.Sec.Uc.DoUi
{
    class ScryptoDef : Scrypto
    {
        public ScryptoDef(ASec asec, Do od)
            : base(asec, od)
        {
        }

        public override void InitKey(string key)
        {
            _Do.CbType.SelectedIndex = 0;

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void ChangedType(Item type)
        {
            _Do.TbData.Text = "";
            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override bool Check()
        {
            return true;
        }

        public override void Begin()
        {
        }

        public override void End()
        {
        }
    }
}