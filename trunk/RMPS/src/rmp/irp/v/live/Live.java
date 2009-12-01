/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import com.amonsoft.rmps.irp.v.IAccount;
import com.amonsoft.rmps.irp.v.IConnect;
import com.amonsoft.rmps.irp.b.IContact;
import com.amonsoft.rmps.irp.b.IStatus;
import java.util.Date;
import java.util.List;
import net.sf.jml.MsnContact;
import net.sf.jml.MsnMessenger;
import net.sf.jml.MsnProtocol;
import net.sf.jml.MsnSwitchboard;
import net.sf.jml.MsnUserStatus;
import net.sf.jml.event.MsnAdapter;
import net.sf.jml.impl.MsnMessengerFactory;
import net.sf.jml.message.MsnControlMessage;
import net.sf.jml.message.MsnDatacastMessage;
import net.sf.jml.message.MsnInstantMessage;
import net.sf.jml.message.MsnSystemMessage;
import net.sf.jml.message.MsnUnknownMessage;
import rmp.irp.c.Control;
import rmp.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class Live extends MsnAdapter implements IAccount
{
    private Connect connect;
    private MsnMessenger messenger;
    private Session session;

    public Live()
    {
    }

    @Override
    public void exit()
    {
    }

    @Override
    public void sign(int status)
    {
        switch (status)
        {
            case IStatus.INIT:
                try
                {
                    connect = new Connect();
                    connect.load();

                    session = new Session();
                }
                catch (Exception exp)
                {
                }
                break;
            case IStatus.LINE:

                messenger = MsnMessengerFactory.createMsnMessenger(connect.getUser(), connect.getPwds());
                messenger.setSupportedProtocol(new MsnProtocol[]
                        {
                            MsnProtocol.MSNP12,
                            MsnProtocol.MSNP11,
                            MsnProtocol.MSNP10,
                            MsnProtocol.MSNP9,
                            MsnProtocol.MSNP8
                        });
                // messenger.setLogIncoming(true);
                // messenger.setLogOutgoing(true);
                messenger.addListener(this);
                messenger.login();
                messenger.getOwner().setInitStatus(MsnUserStatus.ONLINE);
                //messenger.getOwner().setDisplayName("Amon");
                messenger.getOwner().getDisplayName();
                break;
            case IStatus.DOWN:
                messenger.logout();
                LogUtil.wExit();
                break;
            default:
                break;
        }
    }

    @Override
    public IConnect getConnect()
    {
        return connect;
    }

    @Override
    public IContact getContact(String user)
    {
        return null;
    }

    @Override
    public List<IContact> getContact()
    {
        MsnContact[] cons = messenger.getContactList().getContacts();
        for (MsnContact con : cons)
        {
            System.out.println(con.getDisplayName());
            System.out.println(con.getEmail());
            System.out.println(con.getStatus());
            System.out.println(con.getPersonalMessage());
        }
        return null;
    }

    @Override
    public void exceptionCaught(MsnMessenger messenger, Throwable throwable)
    {
        LogUtil.log(new Date());
        LogUtil.log(throwable.toString());
    }

    @Override
    public void loginCompleted(MsnMessenger messenger)
    {
        LogUtil.log(new Date());
        LogUtil.log("loginCompleted.");

        Control.getInstance().loginCompleted(session);
    }

    @Override
    public void logout(MsnMessenger messenger)
    {
        LogUtil.log(new Date());
        LogUtil.log("logout.");

        Control.getInstance().willLogout(session);
    }

    @Override
    public void instantMessageReceived(MsnSwitchboard switchboard, MsnInstantMessage message, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("instantMessageReceived - ");
        LogUtil.log(friend.getEmail());
        LogUtil.log(message);

        session.switchboard = switchboard;
        session.contact.contact = friend;
        if ("~".equals(message.getContent()))
        {
            sign(IStatus.DOWN);
        }
        Control.getInstance().instantMessageReceived(session, new Message(message));
    }

    @Override
    public void systemMessageReceived(MsnMessenger messenger, MsnSystemMessage message)
    {
        LogUtil.log(new Date());
        LogUtil.log("systemMessageReceived - ");
        LogUtil.log(message);

        session.messenger = messenger;
        Control.getInstance().systemMessageReceived(session, null);
    }

    @Override
    public void controlMessageReceived(MsnSwitchboard switchboard, MsnControlMessage message, MsnContact contact)
    {
        LogUtil.log(new Date());
        LogUtil.log("controlMessageReceived");
        LogUtil.log(message);

        session.switchboard = switchboard;
        session.contact.contact = contact;
        Control.getInstance().controlMessageReceived(session, null);
    }

    @Override
    public void datacastMessageReceived(MsnSwitchboard switchboard, MsnDatacastMessage message, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("datacastMessageReceived - ");
        LogUtil.log(friend.getEmail());
        LogUtil.log(message);

        Control.getInstance().datacastMessageReceived(session, null);
    }

    @Override
    public void unknownMessageReceived(MsnSwitchboard switchboard, MsnUnknownMessage message, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("unknownMessageReceived - ");
        LogUtil.log(friend.getEmail());
        LogUtil.log(message);

    }

    @Override
    public void contactListInitCompleted(MsnMessenger messenger)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactListInitCompleted.");
    }

    @Override
    public void contactListSyncCompleted(MsnMessenger messenger)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactListSyncCompleted.");
    }

    @Override
    public void contactStatusChanged(MsnMessenger messenger, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactStatusChanged - ");
        LogUtil.log(friend.getEmail());
    }

    @Override
    public void ownerStatusChanged(MsnMessenger messenger)
    {
        LogUtil.log(new Date());
        LogUtil.log("ownerStatusChanged.");
    }

    @Override
    public void contactAddedMe(MsnMessenger messenger, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactAddedMe - ");
        LogUtil.log(friend.getEmail());
    }

    @Override
    public void contactRemovedMe(MsnMessenger messenger, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactRemovedMe - ");
        LogUtil.log(friend.getEmail());
    }

    @Override
    public void switchboardClosed(MsnSwitchboard switchboard)
    {
        LogUtil.log(new Date());
        LogUtil.log("switchboardClosed.");
    }

    @Override
    public void switchboardStarted(MsnSwitchboard switchboard)
    {
        LogUtil.log(new Date());
        LogUtil.log("switchboardStarted.");
    }

    @Override
    public void contactJoinSwitchboard(MsnSwitchboard switchboard, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactJoinSwitchboard - ");
        LogUtil.log(friend.getEmail());
    }

    @Override
    public void contactLeaveSwitchboard(MsnSwitchboard switchboard, MsnContact friend)
    {
        LogUtil.log(new Date());
        LogUtil.log("contactLeaveSwitchboard - ");
        LogUtil.log(friend.getEmail());
    }
}
