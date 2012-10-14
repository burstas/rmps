using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Model
{
    public sealed class ViewModel
    {
        private UserModel _UserModel;
        private string _Pattern;
        private string _LookPath;
        private DFAccess _LookProp;
        private string _FeelPath;
        private DFAccess _FeelProp;
        private DFAccess _UserProp;

        public ViewModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        #region 视图数据
        public string Pattern
        {
            get
            {
                return _Pattern;
            }
            set
            {
                value = value.ToLower();
                if (value == EPwd.PATTERN_PRO || value == EPwd.PATTERN_WIZ || value == EPwd.PATTERN_PAD)
                {
                    _Pattern = value;
                }
                else
                {
                    _Pattern = EPwd.PATTERN_WIZ;
                }
            }
        }

        public string Skin { get; set; }

        public int WindowState { get; set; }

        public bool MenuBarVisible { get; set; }

        public bool ToolBarVisible { get; set; }

        public bool FindBarVisible { get; set; }

        public bool EchoBarVisible { get; set; }

        public bool CatTreeVisible { get; set; }

        public bool KeyListVisible { get; set; }

        public bool NavPaneVisible { get; set; }

        public int HSplitDistance
        {
            get
            {
                return _HSplitDistance;
            }
            set
            {
                _HSplitDistance = value < 0 ? 188 : value;
            }
        }
        private int _HSplitDistance = 188;

        public int VSplitDistance
        {
            get
            {
                return _VSplitDistance;
            }
            set
            {
                _VSplitDistance = value < 0 ? 152 : value;
            }
        }
        private int _VSplitDistance = 152;

        public int WindowLocX { get; set; }
        public int WindowLocY { get; set; }

        public int WindowDimW
        {
            get
            {
                return _WindowDimW;
            }
            set
            {
                _WindowDimW = value < 1 ? 584 : value;
            }
        }
        private int _WindowDimW = 584;

        public int WindowDimH
        {
            get
            {
                return _WindowDimH;
            }
            set
            {
                _WindowDimH = value < 1 ? 412 : value;
            }
        }
        private int _WindowDimH = 412;

        private Dictionary<string, Image> _Imgs;
        public Image GetImage(string key)
        {
            key = _FeelProp.Get(key);
            if (string.IsNullOrEmpty(key))
            {
                return BeanUtil.NaN16;
            }

            if (_Imgs.ContainsKey(key))
            {
                return _Imgs[key];
            }

            Image img = BeanUtil.ReadImage(Path.Combine(_FeelPath, key), BeanUtil.NaN16);
            _Imgs[key] = img;
            return img;
        }

        public Image GetImage(string key, string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                return BeanUtil.NaN16;
            }

            if (Path.IsPathRooted(file))
            {
                file = Path.Combine(Application.StartupPath, file);
            }

            if (!string.IsNullOrEmpty(key))
            {
                if (_Imgs.ContainsKey(key))
                {
                    return _Imgs[key];
                }

                Image img = BeanUtil.ReadImage(file, BeanUtil.NaN16);
                _Imgs[key] = img;
                return img;
            }

            return BeanUtil.ReadImage(file, BeanUtil.NaN16);
        }
        #endregion

        public void Load()
        {
            #region Look
            _LookPath = Path.Combine("Skin", "Look", _UserModel.Look);
            _LookProp = new DFAccess();
            _LookProp.Load(Path.Combine(_LookPath, EApp.FILE_LOOK));
            #endregion

            #region Feel
            _FeelPath = Path.Combine("Skin", "Feel", _UserModel.Feel);
            _FeelProp = new DFAccess();
            _FeelProp.Load(Path.Combine(_FeelPath, EApp.FILE_FEEL));

            if (_Imgs == null)
            {
                _Imgs = new Dictionary<string, Image>();
            }
            else
            {
                _Imgs.Clear();
            }
            #endregion

            #region 视图
            _UserProp = new DFAccess();
            _UserProp.Load(Path.Combine(_UserModel.Home, EApp.USER_CFG));
            Pattern = _UserProp.Get("Pattern", "");
            string tmp = _UserProp.Get("WindowState", "0");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowState = int.Parse(tmp);
            }
            MenuBarVisible = EApp.VALUE_TRUE == _UserProp.Get("MenuBar", EApp.VALUE_TRUE).ToLower();
            ToolBarVisible = EApp.VALUE_TRUE == _UserProp.Get("ToolBar", EApp.VALUE_TRUE).ToLower();
            EchoBarVisible = EApp.VALUE_TRUE == _UserProp.Get("EchoBar", EApp.VALUE_TRUE).ToLower();
            FindBarVisible = EApp.VALUE_TRUE == _UserProp.Get("FindBar", EApp.VALUE_TRUE).ToLower();
            NavPaneVisible = EApp.VALUE_TRUE == _UserProp.Get("NavPane", EApp.VALUE_TRUE).ToLower();
            CatTreeVisible = EApp.VALUE_TRUE == _UserProp.Get("CatTree", EApp.VALUE_TRUE).ToLower();
            KeyListVisible = EApp.VALUE_TRUE == _UserProp.Get("KeyList", EApp.VALUE_TRUE).ToLower();

            tmp = _UserProp.Get("HSplitDistance", "200");
            if (CharUtil.IsValidateLong(tmp))
            {
                HSplitDistance = int.Parse(tmp);
            }
            tmp = _UserProp.Get("VSplitDistance", "160");
            if (CharUtil.IsValidateLong(tmp))
            {
                VSplitDistance = int.Parse(tmp);
            }

            tmp = _UserProp.Get("DimW", "600");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowDimW = int.Parse(tmp);
            }
            tmp = _UserProp.Get("DimH", "450");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowDimH = int.Parse(tmp);
            }
            tmp = _UserProp.Get("LocX", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowLocX = int.Parse(tmp);
            }
            else
            {
                WindowLocX = (SystemInformation.WorkingArea.Width - WindowDimW) >> 1;
            }
            tmp = _UserProp.Get("LocY", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowLocY = int.Parse(tmp);
            }
            else
            {
                WindowLocY = (SystemInformation.WorkingArea.Height - WindowDimH) >> 1;
            }
            #endregion
        }

        public void Save()
        {
            _UserProp.Set("Pattern", Pattern);

            _UserProp.Set("WindowState", WindowState.ToString());

            _UserProp.Set("LocX", WindowLocX.ToString());
            _UserProp.Set("LocY", WindowLocY.ToString());
            _UserProp.Set("DimW", WindowDimW.ToString());
            _UserProp.Set("DimH", WindowDimH.ToString());

            _UserProp.Set("MenuBar", MenuBarVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);
            _UserProp.Set("ToolBar", ToolBarVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);
            _UserProp.Set("EchoBar", EchoBarVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);
            _UserProp.Set("FindBar", FindBarVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);

            _UserProp.Set("NavPane", NavPaneVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);
            _UserProp.Set("CatTree", CatTreeVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);
            _UserProp.Set("KeyList", KeyListVisible ? EApp.VALUE_TRUE : EApp.VALUE_FALSE);

            _UserProp.Set("HSplitDistance", _HSplitDistance.ToString());
            _UserProp.Set("VSplitDistance", _VSplitDistance.ToString());

            _UserProp.Save(Path.Combine(_UserModel.Home, EApp.USER_CFG));
        }
    }
}