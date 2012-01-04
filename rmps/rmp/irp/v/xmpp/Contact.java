/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.xmpp;

import java.util.List;

import org.jivesoftware.smack.RosterEntry;

import rmp.irp.comn.AContact;

import com.amonsoft.rmps.irp.b.ICatalog;
import com.amonsoft.rmps.irp.b.IPresence;

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
public class Contact extends AContact
{
    private RosterEntry contact;

    public Contact(RosterEntry contact)
    {
        this.contact = contact;
    }

    @Override
    public String getId()
    {
        return null;
    }

    @Override
    public String getUser()
    {
        return null;
    }

    @Override
    public String getName()
    {
        return null;
    }

    @Override
    public String getDisplayName()
    {
        return contact.getName();
    }

    @Override
    public String getEmail()
    {
        return contact.getUser();
    }

    @Override
    public IPresence getPresence()
    {
        return null;// contact.getStatus().toString();
    }

    @Override
    public String getPersonalMessage()
    {
        return "";
    }

    @Override
    public List<ICatalog> getCatalogs()
    {
        return null;
    }
}
