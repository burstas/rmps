/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3050000;

import java.awt.image.BufferedImage;
import java.security.Security;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JMenu;
import javax.swing.JPanel;

import rmp.Rmps;
import rmp.comn.C1010000.C1010000;
import rmp.comn.user.UserInfo;
import rmp.prp.Prps;
import rmp.prp.aide.P3050000.v.NormPanel;
import rmp.prp.aide.P3050000.v.TailPanel;
import rmp.util.BeanUtil;
import rmp.util.EnvUtil;
import rmp.util.FileUtil;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;

import com.amonsoft.bean.WForm;
import com.amonsoft.cons.ConsSys;
import com.amonsoft.rmps.prp.IPrpPlus;
import com.amonsoft.util.DeskUtil;
import com.amonsoft.util.LangUtil;

import cons.EnvCons;
import cons.id.PrpCons;
import cons.prp.aide.P3050000.ConstUI;
import cryptix.jce.provider.CryptixCrypto;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 数据安全
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class P3050000 extends WForm implements IPrpPlus
{
    // ////////////////////////////////////////////////////////////////////////
    // 控制变量区域
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 逻辑控制区域
    // ----------------------------------------------------
    /** 当前运行状态标记：参见AppCons.APP_MODE_*** */
    private static int appMode;
    /** 语言资源 */
    private static Properties langRes;
    /** RMPS系统运行目录 */
    private static String baseFolder = "";
    /** 插件程序运行目录 */
    private static String plusFolder = "";
    // ----------------------------------------------------
    // 界面显示区域
    // ----------------------------------------------------
    private TailPanel tp_TailPanel = null;
    private NormPanel np_NormPanel = null;
    private LangUtil langUtil;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////

    /**
     * 默认构造函数
     */
    public P3050000()
    {
    }

    // ////////////////////////////////////////////////////////////////////////
    // 接口实现区域
    // ////////////////////////////////////////////////////////////////////////
    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    @Override
    public boolean wInitView()
    {
        wInit(false);

        // 注册算法提供商
        if (Security.getProvider("CryptixCrypto") == null)
        {
            CryptixCrypto cryptix = new CryptixCrypto();
            Security.addProvider(cryptix);
        }
        return true;
    }

    @Override
    public boolean wInitLang()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public boolean wInitData()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#dispose()
     */
    @Override
    public boolean wClosing()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getBaseFolder()
     */
    @Override
    public String wGetBaseFolder()
    {
        return baseFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#setBaseFolder(java.lang.String)
     */
    @Override
    public void wSetBaseFolder(String folder)
    {
        baseFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftDescription()
     */
    @Override
    public String wGetDescription()
    {
        return langUtil.getMesg(ConstUI.RES_DESCRIPTION, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getHomepage()
     */
    @Override
    public String wGetHomepage()
    {
        return ConstUI.URL_SOFT;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftLogo()
     */
    @Override
    public BufferedImage wGetIconImage(int type)
    {
        return BeanUtil.getLogoImage();
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftID()
     */
    @Override
    public int wCode()
    {
        return PrpCons.P3050000_I;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftName()
     */
    @Override
    public String wGetName()
    {
        return langUtil.getMesg(ConstUI.RES_NAME, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wGetPlusFolder()
     */
    @Override
    public String wGetPlusFolder()
    {
        return plusFolder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wSetPlusFolder(java.lang.String)
     */
    @Override
    public void wSetPlusFolder(String folder)
    {
        plusFolder = folder;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getTitle()
     */
    @Override
    public String wGetTitle()
    {
        return langUtil.getMesg(ConstUI.RES_TITLE, "");
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#getSoftVersion()
     */
    @Override
    public String wGetVersion()
    {
        return ConstUI.VER_CODE;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#initSoftMenu(javax.swing.JMenu)
     */
    @Override
    public boolean wShowMenu(JMenu menu)
    {
        return false;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#initSoftTail(javax.swing.JPanel)
     */
    @Override
    public boolean wShowTail(JPanel view)
    {
        if (tp_TailPanel == null)
        {
            tp_TailPanel = new TailPanel(this, view);
            tp_TailPanel.wInit();
        }
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowHelp()
     */
    @Override
    public void wShowHelp()
    {
        try
        {
            DeskUtil.open(EnvCons.FOLDER0_HELP + EnvCons.COMN_SP_FILE + "index.html");
        }
        catch (Exception ex)
        {
            Logger.getLogger(P3050000.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowInfo()
     */
    @Override
    public void wShowInfo()
    {
        C1010000.setInfo(EnvUtil.getLangPath(EnvCons.COMN_SOFT_INFO, PrpCons.P3050000_S, baseFolder));
        Prps.getSoftInfo().wSetBaseFolder(baseFolder);
        Prps.getSoftInfo().wShowView(VIEW_NORM);
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wShowView(int)
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
     * @see rmp.face.IPrpPlus#wIconified()
     */
    @Override
    public boolean wIconified()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IPrpPlus#wDeiconified()
     */
    @Override
    public boolean wDeiconified()
    {
        return true;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 模块接口区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 程序当前运行方式：Application、Applet、Web Start
     * 
     * @return
     */
    public static int getAppMode()
    {
        return appMode;
    }

    /**
     * 语言资源查询
     * 
     * @param mesgId
     *            语言资源索引
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId)
    {
        if (langRes == null)
        {
            langRes = new Properties();

            // 语言资源信息读取
            try
            {
                FileUtil.readLangRes(langRes, EnvUtil.getLangPath(EnvCons.COMN_SOFT_LANG, PrpCons.P3050000_S, baseFolder));
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                MesgUtil.showMessageDialog(null, exp.getMessage());
            }
        }
        return langRes.getProperty(mesgId);
    }

    /**
     * 语言资源查询
     * 
     * @param mesgId
     *            语言资源索引
     * @param defMesg
     *            默认语言资源
     * @return 语言资源内容
     */
    public static String getMesg(String mesgId, String defMesg)
    {
        String v = getMesg(mesgId);
        return v != null ? v : defMesg;
    }

    // ////////////////////////////////////////////////////////////////////////
    // 界面显示区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 
     */
    private javax.swing.JPanel showMain()
    {
        return null;
    }

    /**
     * 
     */
    private javax.swing.JPanel showMini()
    {
        return null;
    }

    /**
     * 显示正常面板
     */
    private javax.swing.JPanel showNorm()
    {
        // 面板实例化
        if (np_NormPanel == null)
        {
            np_NormPanel = new NormPanel(this);
            np_NormPanel.wInit();
        }

        setContentPane(np_NormPanel);
        pack();
        center(null);
        if (!isVisible())
        {
            setVisible(true);
        }
        return np_NormPanel;
    }

    /**
     * 
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

    /*
     * (non-Javadoc)
     * 
     * @see java.applet.Applet#wInit()
     */
    @Override
    public void init()
    {
        // 启动模式标记
        appMode = ConsSys.MODE_APPLET;
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_JNLP;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        Rmps.setUser(ui);

        // 显示主窗口 启动应用程序
        wShowView(VIEW_NORM);
    }

    /**
     * @param args
     */
    public static void main(String[] args)
    {
        // 启动模式标记
        appMode = getAppMode(args);
        // 运行目录标记
        baseFolder = EnvCons.COMN_PATH_HOME;

        UserInfo ui = new UserInfo("Amon", "amon");
        ui.wInit();
        Rmps.setUser(ui);

        // 1、 启动系统日志
        LogUtil.wInit("log");

        // 2、 运行环境检测
        if (!Rmps.checkJre())
        {
            System.exit(0);
            return;
        }

        // 3、 用户配置加载
        if (!ui.loadCfg(baseFolder, appMode))
        {
            System.exit(0);
            return;
        }

        // 4、 应用界面风格
        if (!Rmps.initLnF())
        {
            System.exit(0);
            return;
        }

        // 5、引用应用对象
        P3050000 soft = new P3050000();
        soft.wInitView();
        soft.wShowView(VIEW_MINI);
    }
}