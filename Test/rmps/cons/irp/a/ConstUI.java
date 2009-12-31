/*
 * FileName:       ConstUI.java
 * CreateDate:     2008-1-16 上午11:34:20
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package cons.irp.a;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-1-16 上午11:34:20
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public interface ConstUI
{
    /** 会话级别切换 */
    String COMN_MODE_NEXT = "~";
    String COMN_MODE_TOPS = "~~";

    /** 系统帮助标记 */
    String COMN_HELP_CN01 = "－";
    String COMN_HELP_EN01 = "-";

    /** 参数设置标记 */
    String COMN_PROP_CN01 = "〉";
    String COMN_PROP_CN02 = "》";
    String COMN_PROP_EN01 = ">";

    /** 用户公共信息维护对象 */
    String COMN_USER_PROP = "amon_prop";

    /** 使用帮助 */
    String SIGN_HELP_CN01 = "帮助";
    String SIGN_HELP_CN02 = "？";
    String SIGN_HELP_EN01 = "help";
    String SIGN_HELP_EN02 = "?";

    /** 软件简介 */
    String SIGN_INFO_CN01 = "简介";
    String SIGN_INFO_EN01 = "info";

    /** 代码示例 */
    String SIGN_CODE_CN01 = "示例";
    String SIGN_CODE_EN01 = "code";

    /** 会话对象 */
    String SIGN_SOFT_CN01 = "会话";
    String SIGN_SOFT_EN01 = "soft";

    String NEXT_LINE = "\n";

    /** 前缀：欢迎信息 */
    int PRE_WELCOME = 100;
    /** 前缀：帮助信息 */
    int PRE_HELP = 200;
    /** 前缀：简介信息 */
    int PRE_INFO = 300;
    /** 前缀：示例信息 */
    int PRE_CODE = 400;
    /**  */
    int PRE_SOFT = 400;

    // ========================================================================
    // 使用会话
    // ========================================================================
    /**  */
    /**  */
    String ROBOT_PRE = "ROBOT";

    // ========================================================================
    // 后缀解析
    // ========================================================================
    String P3010000 = "13010000";
    String P3010000_PRE = "P3010";

    // ========================================================================
    // 文件更名
    // ========================================================================
    String P3020000 = "13020000";
    String P3020000_PRE = "P3020";

    // ========================================================================
    // 编码查询
    // ========================================================================
    String P3030000 = "13030000";
    String P3030000_PRE = "P3030";
    /** 用户查询模式：1数值到字符查询；其它字符到数值查询 */
    String P3030000_USERMODE = "13030000_usermode";
    /** 是否显示二进制数据：1显示，其它不显示 */
    String P3030000_SHOWCOL02 = "13030000_showcol02";
    /** 是否显示八进制数据：1显示，其它不显示 */
    String P3030000_SHOWCOL08 = "13030000_showcol08";
    /** 是否显示十进制数据：1显示，其它不显示 */
    String P3030000_SHOWCOL10 = "13030000_showcol10";
    /** 是否显示十六进制数据：1显示，其它不显示 */
    String P3030000_SHOWCOL16 = "13030000_showcol16";
    /** 是否显示字符数据：1显示，其它不显示 */
    String P3030000_SHOWCOLCH = "13030000_showcolch";
    /** 是否显示字符数据：1显示，其它不显示 */
    String P3030000_FIXLENGTH = "13030000_fixlength";

    // ========================================================================
    // 迷你日历
    // ========================================================================
    String P3040000 = "13040000";
    String P3040000_PRE = "P3040";

    // ========================================================================
    // 数据安全
    // ========================================================================
    String P3050000 = "13050000";
    String P3050000_PRE = "P3050";

    // ========================================================================
    // 计算助理
    // ========================================================================
    String P3060000 = "13060000";
    String P3060000_PRE = "P3060";
    /** 是否显示运算步骤：1显示，其它不显示 */
    String P3060000_SHOWSTEPS = "13060000_showstep";
    /** 计算结果精度，默认为8 */
    String P3060000_PRECISION = "13060000_precision";

    // ========================================================================
    // 
    // ========================================================================
    String P3070000 = "13070000";
    String P3070000_PRE = "P3070";

    // ========================================================================
    // 
    // ========================================================================
    String P3080000 = "13080000";
    String P3080000_PRE = "P3080";

    // ========================================================================
    // 天气预报
    // ========================================================================
    String P3090000 = "13090000";
    String P3090000_PRE = "P3090";
    /** 今日天气趋势图片名称 */
    String P3090000_DAY11 = "13090000_day11";
    String P3090000_DAY12 = "13090000_day12";
    /** 次日天气趋势开始图片名称 */
    String P3090000_DAY21 = "13090000_day21";
    String P3090000_DAY22 = "13090000_day22";
    /** 三日天气趋势开始图片名称 */
    String P3090000_DAY31 = "13090000_day31";
    String P3090000_DAY32 = "13090000_day32";

    // ========================================================================
    // 
    // ========================================================================
    String P30A0000 = "130A0000";
    String P30A0000_PRE = "P30A0";

    // ========================================================================
    // 
    // ========================================================================
    String P30B0000 = "130B0000";
    String P30B0000_PRE = "P30B0";

    // ========================================================================
    // 
    // ========================================================================
    String P30C0000 = "130C0000";
    String P30C0000_PRE = "P30C0";
}