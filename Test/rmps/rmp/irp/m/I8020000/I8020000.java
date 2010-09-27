/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp.m.I8020000;

import java.util.HashMap;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import rmp.bean.K1SV1S;
import rmp.irp.c.Control;

import com.amonsoft.rmps.irp.b.IMessage;
import com.amonsoft.rmps.irp.b.IProcess;
import com.amonsoft.rmps.irp.b.ISession;
import com.amonsoft.rmps.irp.m.IService;
import com.amonsoft.util.CharUtil;

import cons.irp.ConsEnv;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 正则运算
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author amon
 * 
 */
public class I8020000 implements IService
{
    private HashMap<String, String> hash;

    @Override
    public boolean wInit()
    {
        hash = new HashMap<String, String>(4);
        hash.put("0", Constant.MATCHER_TEST);
        hash.put("1", Constant.MATCHER_SPLIT);
        hash.put("2", Constant.MATCHER_MATCH);
        hash.put("3", Constant.MATCHER_SEARCH);
        hash.put("4", Constant.MATCHER_REPLACE);
        return true;
    }

    @Override
    public String getCode()
    {
        return "58020000";
    }

    @Override
    public String getName()
    {
        return "正则运算";
    }

    @Override
    public String getDescription()
    {
        return "正则运算";
    }

    @Override
    public List<K1SV1S> getHelpTips()
    {
        return null;
    }

    @Override
    public void doInit(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doInit(session, msg);
        doHelp(session, msg.append(session.newLine()));

        msg.append(session.newLine()).append("第一步：请输入匹配模式").append(session.newLine());

        session.getProcess().setType(IProcess.TYPE_NACTION | IProcess.TYPE_CONTENT);
        session.getProcess().setStep(Constant.STEP_PATTERN);
        session.send(msg.toString());

        session.setAttribute(getCode() + Constant.SESSION_PATTERN, null);
        session.setAttribute(getCode() + Constant.SESSION_MATCHER, null);
        session.setAttribute(getCode() + Constant.SESSION_CHARSET, null);
    }

    @Override
    public void doHelp(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doHelp(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doMenu(ISession session, IMessage message)
    {
        StringBuffer msg = new StringBuffer();
        doMenu(session, msg);
        session.send(msg.toString());
    }

    @Override
    public void doDeal(ISession session, IMessage message)
    {
        String txt = message.getContent();
        String tmp = txt.trim();
        StringBuffer msg = new StringBuffer(session.newLine());
        IProcess pro = session.getProcess();

        // 功能选择
        if (!IProcess.ITEM_DEFAULT.equals(pro.getItem()))
        {
            // 输入模式切换
            if ("1".equals(tmp))
            {
                pro.setItem(IProcess.ITEM_DEFAULT);
                if (pro.getStep() == Constant.STEP_CHARONE)
                {
                    pro.setStep(Constant.STEP_CHARSET);
                    session.send(msg.append("请输入后续验证数据！").append(session.newLine()).toString());
                }
                else
                {
                    pro.setStep(Constant.STEP_CHARONE);
                    session.send(msg.append("请输入新的验证数据！").append(session.newLine()).toString());
                }
                return;
            }
            // 选择验证方法
            if ("2".equals(tmp))
            {
                doMenu(session, msg);
                pro.setItem(IProcess.ITEM_DEFAULT);
                pro.setStep(Constant.STEP_MATCHER);
                session.send(msg.toString());
                return;
            }
            // 修改匹配模式
            if ("3".equals(tmp))
            {
                pro.setItem(IProcess.ITEM_DEFAULT);
                pro.setStep(Constant.STEP_PATTERN);
                session.send(msg.append("请输入新的匹配模式！").append(session.newLine()).toString());
                return;
            }
            // 显示服务菜单
            if (ConsEnv.KEY_FUNC.equals(tmp))
            {
                if (pro.setFunc(".."))
                {
                    Control.getService(pro.getFunc()).doInit(session, message);
                }
                return;
            }

            // 容错处理
            if (!"0".equals(tmp))
            {
                msg.append("小木不能确认您当前的操作！").append(session.newLine());
                doStep(session, msg);
                session.send(msg.toString());
                return;
            }

            // 继续当前输入
            pro.setItem(IProcess.ITEM_DEFAULT);
            txt = ConsEnv.KEY_HELP;
            tmp = txt;
        }

        if (ConsEnv.KEY_FUNC.equals(tmp))
        {
            doStep(session, msg);
            pro.setItem(Constant.ITEM_SUBMENU);
            session.send(msg.toString());
            return;
        }

        // 输入表达式
        if (pro.getStep() == Constant.STEP_PATTERN)
        {
            if (!CharUtil.isValidate(txt))
            {
                session.send(msg.append("匹配模式不能为空，请重新输入！").append(session.newLine()).toString());
                return;
            }
            session.setAttribute(getCode() + Constant.SESSION_PATTERN, txt);

            // 判断字符串
            if (session.getAttribute(getCode() + Constant.SESSION_MATCHER) == null)
            {
                // 第一次使用服务
                msg.append("第二步：选择验证方法").append(session.newLine());
                doMenu(session, msg);
                session.send(msg.toString());
                pro.setStep(Constant.STEP_MATCHER);
            }
            else
            {
                // 内容更新，显示运算结果
                showData(session, msg);
            }
            return;
        }

        // 选择运算符
        if (pro.getStep() == Constant.STEP_MATCHER)
        {
            if (!CharUtil.isValidate(tmp))
            {
                doMenu(session, msg);
                session.send(msg.toString());
                return;
            }
            session.setAttribute(getCode() + Constant.SESSION_MATCHER, tmp);

            // 判断字符串
            if (session.getAttribute(getCode() + Constant.SESSION_CHARSET) == null)
            {
                // 第一次使用服务
                session.send(msg.append("第三步：输入验证数据").append(session.newLine()).toString());
                pro.setStep(Constant.STEP_CHARONE);
            }
            else
            {
                // 内容更新，显示运算结果
                showData(session, msg);
            }
            return;
        }

        // 单匹配数据输入
        if (pro.getStep() == Constant.STEP_CHARONE)
        {
            if (!CharUtil.isValidate(txt))
            {
                session.send(msg.append("待验证数据不能为空，请重新输入！").append(session.newLine()).toString());
                return;
            }
            session.setAttribute(getCode() + Constant.SESSION_CHARSET, txt);

            // 内容更新，显示运算结果
            showData(session, msg);
            return;
        }

        // 多匹配数据输入
        if (pro.getStep() == Constant.STEP_CHARSET)
        {
            if (CharUtil.isValidate(txt))
            {
                session.setAttribute(getCode() + Constant.SESSION_CHARSET, session.getAttribute(getCode() + Constant.SESSION_CHARSET) + txt);
            }
            showData(session, msg);
            return;
        }
    }

    @Override
    public void doStep(ISession session, IMessage message)
    {
    }

    @Override
    public void doExit(ISession session, IMessage message)
    {
    }

    @Override
    public void doRoot(ISession session, IMessage message)
    {
    }

    private StringBuffer doInit(ISession session, StringBuffer message)
    {
        message.append(CharUtil.format("欢迎使用《{0}》服务！", getName())).append(session.newLine());
        message.append(CharUtil.format("　　《{0}》服务支持常用正则表达式算法，如test、split、search、replace等！", getName())).append(session.newLine());
        return message;
    }

    private StringBuffer doHelp(ISession session, StringBuffer message)
    {
        message.append("您可以通过如下的方式使用此服务：").append(session.newLine());
        message.append("　　1、输入正则表达式；").append(session.newLine());
        message.append("　　2、选择正则验证方法；").append(session.newLine());
        message.append("　　3、输入要验证的字符串；").append(session.newLine());
        message.append("　　有关正则表达式的详细信息，请访问：http://www.regexlab.com/zh/regref.htm").append(session.newLine());
        return message;
    }

    private StringBuffer doMenu(ISession session, StringBuffer message)
    {
        int c = hash.size();
        if (c > 10)
        {
            c = 10;
        }
        for (int i = 0; i < c; i += 1)
        {
            message.append(i).append('、').append(hash.get("" + i)).append(session.newLine());
        }
        message.append("请输入对应的数字选择您要使用的验证方法：").append(session.newLine());
        return message;
    }

    private StringBuffer doStep(ISession session, StringBuffer message)
    {
        message.append("0、继续当前数据输入；").append(session.newLine());
        message.append(CharUtil.format("1、切换为{0}输入模式；", session.getProcess().getStep() == Constant.STEP_CHARONE ? "连续" : "单次")).append(session.newLine());
        message.append("2、选择其它验证方法；").append(session.newLine());
        message.append("3、更新当前匹配模式；").append(session.newLine());
        message.append("*、返回服务选择菜单；").append(session.newLine());
        message.append("请选择您要进行的操作：").append(session.newLine());
        return message;
    }

    private void showData(ISession session, StringBuffer message)
    {
        try
        {
            String p = (String) session.getAttribute(getCode() + Constant.SESSION_PATTERN);// 表达式
            String m = hash.get((String) session.getAttribute(getCode() + Constant.SESSION_MATCHER));// 运算符
            String t = (String) session.getAttribute(getCode() + Constant.SESSION_CHARSET);// 字符串
            message.append("匹配模式：").append(p).append(session.newLine());
            message.append("验证方法：").append(m).append(session.newLine());
            message.append("测试数据：").append(t).append(session.newLine());
            message.append("运行结果：");
            if (Constant.MATCHER_TEST.equals(m))
            {
                message.append(Pattern.matches(p, t)).append(session.newLine());
            }
            else if (Constant.MATCHER_MATCH.equals(m))
            {
                Matcher r = Pattern.compile(p).matcher(t);
                while (r.find())
                {
                    message.append(r.start()).append(session.newLine());
                }
            }
            else if (Constant.MATCHER_SPLIT.equals(m))
            {
                for (String s : t.split(p))
                {
                    message.append(s).append(session.newLine());
                }
            }
            else if (Constant.MATCHER_SEARCH.equals(m))
            {
                Matcher r = Pattern.compile(p).matcher(t);
                while (r.find())
                {
                    message.append(r.group()).append(session.newLine());
                }
            }
            else if (Constant.MATCHER_REPLACE.equals(m))
            {
                message.append(session.newLine()).append(t.replaceAll(p, "■")).append(session.newLine());
            }
        }
        catch (Exception exp)
        {
            message.append(exp.getMessage()).append(session.newLine());
        }

        session.send(message.toString());
    }
}