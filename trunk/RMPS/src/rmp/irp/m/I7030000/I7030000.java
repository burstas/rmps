/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I7030000;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * I7030000
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class I7030000 implements IService
{
    @Override
    public boolean wInit()
    {
        LogUtil.log(getName() + " 初始化成功！");
        return true;
    }

    @Override
    public String getCode()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getName()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public String getDescription()
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }
}
