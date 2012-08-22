﻿using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcMonth : UserControl, ITime
    {
        public UcMonth()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd != null && mgtd.Dates.Count == 1)
            {
                ADates dates = mgtd.Dates[0];
                if (dates.Type == CGtd.TYPE_MINOR_EACH)
                {
                    RbEach.Checked = true;
                    SpEach.Value = dates.Values[0];
                    return;
                }

                if (dates.Type == CGtd.TYPE_MINOR_WHEN)
                {
                    RbWhen.Checked = true;
                    foreach (int val in dates.Values)
                    {
                        SpWhen.Value = val;
                    }
                    return;
                }
            }
            RbEach.Checked = true;
        }

        public bool SaveData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return false;
            }

            ADates dates;
            if (mgtd.Dates.Count == 1)
            {
                dates = mgtd.Dates[0];
            }
            else
            {
                dates = new Dates.Month();
                mgtd.Dates.Add(dates);
            }

            if (RbEach.Checked)
            {
                dates.Type = CGtd.TYPE_MINOR_EACH;
                dates.Values.Clear();
                dates.Values.Add(decimal.ToInt32(SpEach.Value));
                return true;
            }

            if (RbWhen.Checked)
            {
                dates.Type = CGtd.TYPE_MINOR_WHEN;
                dates.Values.Clear();
                dates.Values.Add(decimal.ToInt32(SpWhen.Value));
                return true;
            }

            return false;
        }
        #endregion

        #region 事件处理
        private void RbEach_CheckedChanged(object sender, EventArgs e)
        {
            SpEach.Enabled = true;
            SpWhen.Enabled = false;
        }

        private void RbWhen_CheckedChanged(object sender, EventArgs e)
        {
            SpEach.Enabled = false;
            SpWhen.Enabled = true;
        }
        #endregion
    }
}
