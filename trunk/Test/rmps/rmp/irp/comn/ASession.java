/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.comn;

import java.util.HashMap;

import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;

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
public abstract class ASession implements ISession
{
    private IProcess process;
    private HashMap<String, Object> attribute;

    public ASession()
    {
        attribute = new HashMap<String, Object>();
    }

    @Override
    public void setAttribute(String key, Object obj)
    {
        attribute.put(key, obj);
    }

    @Override
    public Object getAttribute(String key)
    {
        return attribute.get(key);
    }

    @Override
    public String newLine()
    {
        return "\n";
    }

    @Override
    public IProcess getProcess()
    {
        if (process == null)
        {
            process = new Process();
        }
        return process;
    }

    /**
     * 添加路径信息
     * 
     * @param session
     * @param message
     * @return
     */
    protected static StringBuffer appendPath(ISession session, StringBuffer message)
    {
        IProcess process = session.getProcess();
        message.append("当前操作：/").append(process.getFunc()).append('（');
        IService service = Control.getService(process.getFunc());
        if (service != null)
        {
            message.append(service.getName());
        }
        message.append("）：").append(session.newLine());
        message.append('〖');
        int type = session.getProcess().getType();
        if ((type & IProcess.TYPE_NACTION) != 0)
        {
            message.append("锁定-");
        }
        if (type == IProcess.TYPE_DEFAULT)
        {
            message.append("默认、");
        }
        if ((type & IProcess.TYPE_KEYCODE) != 0)
        {
            message.append("服务、");
        }
        if ((type & IProcess.TYPE_COMMAND) != 0)
        {
            message.append("命令、");
        }
        if ((type & IProcess.TYPE_CONTENT) != 0)
        {
            message.append("内容、");
        }
        message.deleteCharAt(message.length() - 1);
        message.append('〗').append(session.newLine());
        message.append("---------------------------------").append(session.newLine());
        return message;
    }

    /**
     * 添加版权信息
     * 
     * @param session
     * @param message
     * @return
     */
    protected static StringBuffer appendCopy(ISession session, StringBuffer message)
    {
        message.append(session.newLine()).append("---------------------------------");
        message.append(session.newLine()).append("〖*菜单 ?帮助〗");
        message.append(session.newLine()).append("© Amonsoft @ http://amonsoft.com/");
        return message;
    }
}