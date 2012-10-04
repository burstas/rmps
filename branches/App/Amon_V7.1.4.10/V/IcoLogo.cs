using System.ComponentModel;
using System.Windows.Forms;
using Me.Amon.Properties;

namespace Me.Amon.V
{
    public class IcoLogo : ILogo
    {
        public IcoLogo(PictureBox pBox, IContainer container)
        {
            pBox.Image = Resources.Logo24;
        }

        #region 接口实现
        public void DoWork()
        {
        }

        public void MouseMove()
        {
        }

        public void KeyPress()
        {
        }

        public void DoStop()
        {
        }
        #endregion
    }
}