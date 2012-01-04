/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3050000.v;

import rmp.prp.aide.P3050000.P3050000;
import rmp.ui.link.WLinkLabel;

import com.amonsoft.rmps.prp.IPrpPlus;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public class TailPanel
{
    private IPrpPlus soft;
    private javax.swing.JPanel tailPanel;

    /**
     * @param tailPanel
     */
    public TailPanel(IPrpPlus soft, javax.swing.JPanel tailPanel)
    {
        this.soft = soft;
        this.tailPanel = tailPanel;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        WLinkLabel lk = new WLinkLabel();
        lk.setText("启动窗口");
        tailPanel.setLayout(new java.awt.FlowLayout());
        tailPanel.add(lk);
        lk.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                soft.wShowView(P3050000.VIEW_NORM);
            }
        });
        return true;
    }
}
