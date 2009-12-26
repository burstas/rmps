/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.xmpp;

import java.io.File;

import org.jivesoftware.smack.Chat;
import org.jivesoftware.smack.XMPPException;

import rmp.irp.comn.ASession;

import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IMimeMessage;
import com.amonsoft.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class Session extends ASession
{
    Chat session;
    IContact contact;

    @Override
    public void send()
    {
    }

    @Override
    public void send(String message)
    {
        send(message, true);
    }

    @Override
    public void send(String message, boolean literal)
    {
        try
        {
            session.sendMessage(literal ? appendCopy(this, appendPath(this, new StringBuffer()).append(message)).toString() : message);
        }
        catch (XMPPException exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void send(IMessage message)
    {
        send(message, true);
    }

    @Override
    public void send(IMessage message, boolean literal)
    {
        try
        {
            if (message instanceof Message)
            {
                session.sendMessage(((Message) message).message);
            }
        }
        catch (XMPPException exp)
        {
            LogUtil.exception(exp);
        }
    }

    @Override
    public void send(IMimeMessage message)
    {
        send(message, true);
    }

    @Override
    public void send(IMimeMessage message, boolean literal)
    {
    }

    @Override
    public void send(File file)
    {
    }

    @Override
    public void reset()
    {
    }

    @Override
    public IContact getContact()
    {
        return contact;
    }

    @Override
    public IMessage createMessage()
    {
        return new Message(new org.jivesoftware.smack.packet.Message());
    }

    @Override
    public IMimeMessage createMimeMessage()
    {
        return null;
    }
}
