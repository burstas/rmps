/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp;

import com.amonsoft.rmps.irp.b.IStatus;
import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.util.LogUtil;
import cons.irp.ConsEnv;
import java.util.HashMap;
import rmp.irp.v.gtalk.GTalk;
import rmp.irp.v.jabber.Jabber;
import rmp.irp.v.live.Live;
import rmp.irp.v.meebo.Meebo;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Irps
{
    private static HashMap<String, IAccount> accounts;
    private static java.awt.MenuItem irpsItem;

    public static void init(java.awt.Menu menu)
    {
        if (menu == null)
        {
            return;
        }

        main(null);

        irpsItem = new java.awt.MenuItem("MSN");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Live();
                account.sign(IStatus.INIT);
                account.sign(IStatus.SIGN);
                accounts.put(ConsEnv.IM_LIVE, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("GTalk");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new GTalk();
                account.sign(IStatus.INIT);
                account.sign(IStatus.SIGN);
                accounts.put(ConsEnv.IM_LIVE, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("meebo");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Meebo();
                account.sign(IStatus.INIT);
                account.sign(IStatus.SIGN);
                accounts.put(ConsEnv.IM_LIVE, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("jabber");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Jabber();
                account.sign(IStatus.INIT);
                account.sign(IStatus.SIGN);
                accounts.put(ConsEnv.IM_LIVE, account);
            }
        });
        menu.add(irpsItem);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args)
    {
        LogUtil.wInit();

        accounts = new HashMap<String, IAccount>();
//        IAccount account;

//        account = new GTalk();
//        account.sign(IStatus.INIT);
//        account.sign(IStatus.SIGN);
//        accounts.put(ConsEnv.IM_LIVE, account);

//        account = new Fetion();
//        account.sign(IStatus.INIT);
//        account.sign(IStatus.LINE);
//        accounts.put(ConsEnv.IM_FETION, account);
    }

    public static void exit(int status)
    {
        for (IAccount acc : accounts.values())
        {
            acc.sign(IStatus.DOWN);
        }
        System.exit(status);
    }

    public static void step(String account, int status)
    {
        IAccount acc = accounts.get(account);
        if (acc != null)
        {
            acc.sign(status);
        }
    }
}
