﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.Amon.Bean.Att
{
    public class CallAtt : AAtt
    {
        public const int SPEC_CALL_CAT1 = 0;//控制类型
        public const int SPEC_CALL_CAT2 = 1;//显示模板

        public CallAtt()
            : base(TYPE_LINE, "", "")
        {
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[2];
            }
        }
    }
}