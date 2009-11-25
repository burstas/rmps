/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P30C0000;

import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "1.0.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.Testsoft_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P30C0000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P30C0000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P30C0000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 用户配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件配置数据 */
    String CFG_SOFT = "P30C0000.soft";
    // ////////////////////////////////////////////////////////////////////////
    // SOAP配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** SOAP文档路径 */
    String SOAP_FILE = "/prp/aide/P30C0000/soap0001.xml";
    /** SOAP发送路径 */
    String SOAP_POST = "http://www.webxml.com.cn/WebServices/IpAddressSearchWebService.asmx";
    /** SOAP主机地址 */
    String SOAP_HOST = "www.webxml.com.cn";
    /** SOAP内容类型 */
    String SOAP_TYPE = "text/xml; charset=utf-8";
    /** SOAP响应路径 */
    String SOAP_ACTION = "http://WebXml.com.cn/getCountryCityByIp";
}
