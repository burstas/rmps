/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.comn.help.C2010000;

import java.awt.image.BufferedImage;

import javax.swing.JMenu;
import javax.swing.JPanel;

import com.amonsoft.rmps.prp.ISoft;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 使用帮助
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class C2010000 implements ISoft
{

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInit()
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wDispose()
     */
    @Override
    public void wDispose()
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetDescription()
     */
    @Override
    public String wGetDescription()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wCode()
     */
    @Override
    public int wCode()
    {
        // TODO Auto-generated method stub
        return 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetIconImage(int)
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetMode()
     */
    @Override
    public int wGetMode()
    {
        // TODO Auto-generated method stub
        return 0;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetName()
     */
    @Override
    public String wGetName()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetPlusFolder()
     */
    @Override
    public String wGetPlusFolder()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetTitle()
     */
    @Override
    public String wGetTitle()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wGetVersion()
     */
    @Override
    public String wGetVersion()
    {
        // TODO Auto-generated method stub
        return null;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wInitMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wInitMenu(JMenu menu)
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wInitTail(javax.swing.JPanel)
     */
    @Override
    public boolean wInitTail(JPanel view)
    {
        // TODO Auto-generated method stub
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wSetPlusFolder(java.lang.String)
     */
    @Override
    public void wSetPlusFolder(String folder)
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowHelp()
     */
    @Override
    public void wShowHelp()
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowInfo()
     */
    @Override
    public void wShowInfo()
    {
        // TODO Auto-generated method stub
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wShowView(int)
     */
    @Override
    public javax.swing.JPanel wShowView(int modelIdx)
    {
        switch (modelIdx)
        {
            // 显示内嵌模式
            case VIEW_TAIL:
                return showTail();

            // 显示迷你模式
            case VIEW_MINI:
                return showMini();

            // 显示正常模式
            case VIEW_NORM:
                return showNorm();

            // 显示高级模式
            case VIEW_MAIN:
                return showMain();

            // 显示向导模式
            case VIEW_STEP:
                return showStep();

            default:
                return null;
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wStart()
     */
    @Override
    public boolean wStart()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.ISoft#wStop()
     */
    @Override
    public boolean wStop()
    {
        return true;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showMain()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showMini()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showNorm()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showStep()
    {
        return null;
    }

    /**
     * @return
     */
    private javax.swing.JPanel showTail()
    {
        return null;
    }

    /**
     * @param args
     */
    public static void main(String[] args)
    {
        // TODO Auto-generated method stub
    }
}
