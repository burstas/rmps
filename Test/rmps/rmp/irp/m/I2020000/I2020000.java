/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *    
 */
package rmp.irp.m.I2020000;

import java.io.DataInputStream;
import java.io.File;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import rmp.irp.c.Control;
import rmp.util.EnvUtil;
import rmp.util.LogUtil;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

import cons.EnvCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 邮政编码
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class I2020000 implements IService
{
    private static String path;
    private static String args;
    /**
     * 数据列表匹配
     */
    private static Pattern paPtn;
    /**
     * 单个数据匹配
     */
    private static Pattern piPtn;

    @Override
    public boolean wInit()
    {
        try
        {
            Document document = new SAXReader().read(new File(EnvUtil.getDataPath(EnvCons.FOLDER1_IRP, getCode() + ".xml")));
            Element element = (Element) document.selectSingleNode("/irps/I2020000/item[@id='配置']/map[@key='path']");
            if (element != null)
            {
                path = element.getText();
            }
            element = (Element) document.selectSingleNode("/irps/I2020000/item[@id='配置']/map[@key='args']");
            if (element != null)
            {
                args = element.getText();
            }

            paPtn = Pattern.compile("(\\[')(.*?)('\\])");
            piPtn = Pattern.compile("'(.*?)'");

            LogUtil.log(getName() + " 初始化成功！");
            return true;
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
            return false;
        }
    }

    @Override
    public String getCode()
    {
        return "52020000";
    }

    @Override
    public String getName()
    {
        return "邮政编码";
    }

    @Override
    public String getDescription()
    {
        return "邮政编码查询";
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        msg.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        msg.append(CharUtil.format("　　《{0}》服务目前支持15及18位身份证号码查询，并提供15位号码到18位号码的转换服务！", getName())).append(session.newLine());
        msg.append("　　您可以通过如下的方式使用此服务：").append(session.newLine());
        msg.append("　　1、直接输入您要查询的国家、地区或城市的名字：如上海；").append(session.newLine());
        msg.append("　　2、输入您要查询的国家、地区或城市的拼音：如shanghai；").append(session.newLine());
        msg.append("　　3、输入您要查询的国家、地区或城市的拼音首字母：如sh；").append(session.newLine());
        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(IProcess.STEP_DEFAULT);
        session.send(msg.toString());
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        msg.append("1、输入*或＊返回服务选择菜单；").append(session.newLine());
        msg.append("2、输入其它任意键继续当前服务；").append(session.newLine());
        session.send(msg.toString());
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        msg.append("您可以进行以下操作：").append(session.newLine());
        msg.append("<或《 向上翻页").append(session.newLine());
        msg.append("<<或《《 向上翻页").append(session.newLine());
        msg.append(">或》 向下翻页").append(session.newLine());
        msg.append(">>或》》 向下翻页").append(session.newLine());
        msg.append("?或？ 显示使用帮助；").append(session.newLine());
        msg.append("*或＊ 显示服务菜单；").append(session.newLine());
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        try
        {
            String key = message.getContent();
            IProcess proc = session.getProcess();

            // 地址校验
            if (!CharUtil.isValidate(key))
            {
                session.send("请输入您要查询的国家、地区或城市的名称或拼音！");
                return;
            }

            // 链接地址初始化
            URL url = new URL(path + '?' + CharUtil.format(args, key));
            URLConnection conn = url.openConnection();
            conn.setRequestProperty("Proxy-Connection", "Keep-Alive");
            conn.setUseCaches(false);
            conn.setDoInput(true);

            // 读取返回结果
            DataInputStream dis = new DataInputStream(conn.getInputStream());
            byte d[] = new byte[dis.available()];
            dis.read(d);
            String data = new String(d, "gb2312");

            // 保存用户查询结果
            Matcher matcher = paPtn.matcher(data);
            List<String> list = new ArrayList<String>();
            while (matcher.find())
            {
                list.add(matcher.group());
            }

            // 设置下一次操作状态
            proc.setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_COMMAND | IProcess.TYPE_CONTENT);
            proc.setStep(IProcess.STEP_DEFAULT);
            proc.setMost(list.size());
            session.setAttribute(getCode() + "_m", list);

            if (list.size() < 1)
            {
                session.send("请输入您要查询的国家、地区或城市的名称或拼音！");
            }
            else
            {
                // 发送结果信息
                showData(session, list.get(proc.getStep()));
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);

            // 设置下一次操作状态
            session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
        }
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
        IProcess proc = session.getProcess();
        List<?> list = (List<?>) session.getAttribute(getCode() + "_m");
        if (list == null || list.size() < 1)
        {
            session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_CONTENT);
            proc.setStep(IProcess.STEP_DEFAULT);
            session.send("请输入您要查询的国家、地区或城市的名称或拼音！");
            return;
        }

        int step = proc.getStep();
        if (step <= -1)
        {
            proc.setStep(IProcess.STEP_DEFAULT);
            session.send("已经是第一页！");
            return;
        }

        if (step >= proc.getMost())
        {
            proc.setStep(proc.getMost());
            session.send("已经是最后一页！");
            return;
        }

        session.getProcess().setType(IProcess.TYPE_KEYCODE | IProcess.TYPE_COMMAND | IProcess.TYPE_CONTENT);
        showData(session, "" + list.get(step));
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }

    private void showData(ISession session, String data)
    {
        StringBuffer message = new StringBuffer();

        // 结果信息格式化
        Matcher matcher = piPtn.matcher(data);
        List<String> list = new ArrayList<String>();
        while (matcher.find())
        {
            list.add(matcher.group().replaceAll("^'|'$", ""));
        }

        if (list.size() != 5)
        {
            message.append("数据查询错误，请重试！");
        }
        else
        {
            message.append("国家/地区/城市：").append(list.get(4)).append(session.newLine());
            message.append("编　码：").append(list.get(0)).append(session.newLine());
            message.append("区　号：").append(list.get(1)).append(session.newLine());
            message.append("所在地：").append(list.get(2)).append(' ').append(list.get(3)).append(session.newLine());
        }
        session.send(Control.appendPage(session, message).toString());
    }
}