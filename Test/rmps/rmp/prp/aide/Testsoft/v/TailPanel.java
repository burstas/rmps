/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.Testsoft.v;

import rmp.prp.aide.Testsoft.Testsoft;
import rmp.ui.link.WLinkLabel;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * PRPS窗口快捷面板
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class TailPanel
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 应用程序 */
    private Testsoft ms_MainSoft;
    /** 内嵌面板 */
    private javax.swing.JPanel tp_TailPanel;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     * 
     * @param soft
     * @param tailPanel
     */
    public TailPanel(Testsoft soft, javax.swing.JPanel tailPanel)
    {
        this.ms_MainSoft = soft;
        this.tp_TailPanel = tailPanel;
    }

    /**
     * 对象初始化
     * 
     * @return
     */
    public boolean wInit()
    {
        ica();

        ita();

        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 对外接口区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 布局显示区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 界面布局区域
    // ----------------------------------------------------
    /**
     * 界面布局初始化
     */
    private void ica()
    {
        ll_LinkLabl = new WLinkLabel();
        ll_LinkLabl.setText("启动窗口");
        tp_TailPanel.setLayout(new java.awt.FlowLayout());
        tp_TailPanel.add(ll_LinkLabl);
        ll_LinkLabl.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                ms_MainSoft.wShowView(Testsoft.VIEW_NORM);
            }
        });
    }

    // ----------------------------------------------------
    // 语言显示区域
    // ----------------------------------------------------
    /**
     * 界面语言初始化
     */
    private void ita()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 事件处理区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 公共方法区域
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 界面组件区域
    // ////////////////////////////////////////////////////////////////////////
    private WLinkLabel ll_LinkLabl;
}