/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.m.root;

import com.amonsoft.rmps.imp.b.IMessage;
import com.amonsoft.rmps.imp.m.IService;
import com.amonsoft.rmps.imp.b.ISession;
import com.amonsoft.rmps.imp.b.IStatus;
import rmp.imp.Imps;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Root implements IService
{
    public Root()
    {
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String msg = message.getContent();
        String tmp = msg.toLowerCase();
        if ("exit".equals(tmp))
        {
            session.send("再见……");
            Imps.exit(0);
        }

        if (tmp.indexOf("step ") == 0)
        {
            String[] arr = tmp.toLowerCase().split(" ");
            if (arr.length < 3)
            {
                return;
            }

            tmp = arr[2];
            if ("online".equals(tmp))
            {
                Imps.step(arr[1], IStatus.LINE);
                return;
            }
            if ("offline".equals(tmp))
            {
                Imps.step(arr[1], IStatus.DOWN);
            }
            return;
        }
    }
}
