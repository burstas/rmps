/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.Testsoft.v;

import rmp.prp.aide.Testsoft.Testsoft;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RPPS窗口快捷菜单
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class SubMenu
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 主应用程序 */
    private Testsoft ms_MainSoft;
    /** 主级联菜单 */
    private javax.swing.JMenu mm_MainMenu;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     * 
     * @param soft
     * @param menu
     */
    public SubMenu(Testsoft soft, javax.swing.JMenu menu)
    {
        this.ms_MainSoft = soft;
        this.mm_MainMenu = menu;
    }

    /**
     * 对象初始化
     * 
     * @return
     */
    public boolean wInit()
    {
        mm_MainMenu.setText(ms_MainSoft.wGetTitle());

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
}
