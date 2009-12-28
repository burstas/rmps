/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.v.live;

import com.amonsoft.rmps.irp.v.IConnect;

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
public class Connect implements IConnect
{
    private String user;
    private String pwds;

    public Connect()
    {
    }

    @Override
    public boolean load()
    {
        user = "Amon.CT@live.com";
        pwds = "Viq8183";
        return true;
    }

    @Override
    public String getUser()
    {
        return user;
    }

    @Override
    public String getPwds()
    {
        return pwds;
    }

    @Override
    public String getMail()
    {
        return user;
    }

    /**
     * @return the host
     */
    @Override
    public String getHost()
    {
        return "";
    }

    /**
     * @param host
     *            the host to set
     */
    public void setHost(String host)
    {
    }

    @Override
    public String getServer()
    {
        return "";
    }

    @Override
    public int getPort()
    {
        return 0;
    }
}