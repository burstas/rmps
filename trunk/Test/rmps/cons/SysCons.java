/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统统一常量定义类<br />
 * 如PRP、ERP、MRP、WRP各大系统的统一常量定义
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface SysCons
{
    /**
     * 运行模式：Applet
     */
    String MODE_APPLET = "applet";
    /**
     * 运行模式：Web Start
     */
    String MODE_WSTART = "wstart";
    /**
     * 运行模式：插件
     */
    String MODE_PLUGIN = "plugin";
    // ////////////////////////////////////////////////////////////////////////
    // 文件格式常量
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 文件后缀常量
    // ----------------------------------------------------
    /** 正式数据文件的后缀名称，即(W)in(S)hine (D)ata File Format. */
    String EXTS_DATA = ".wsd";
    /** 网页文件默认后缀 */
    String EXTS_HTML = ".htm";
    /** 图标文件默认后缀 */
    String EXTS_ICON = ".png";
    /** 关于软件后缀名称，即(W)in(s)hine (I)nfo File Format */
    String EXTS_INFO = ".wsi";
    /** 语言资源文件默认后缀 */
    String EXTS_LANG = ".wsl";
    /** 图像文件默认后缀 */
    String EXTS_PICT = ".png";
    /** 交换数据文件的后缀名称：即(S)(W)a(P) Data File Format. */
    String EXTS_SWAP = ".swp";
    /** 临时数据文件的后缀名称：即(T)e(M)(P) Data File Format. */
    String EXTS_TEMP = ".tmp";
    /** 文本文件默认后缀 */
    String EXTS_TEXT = ".txt";
    // ----------------------------------------------------
    // 文件格式标记信息
    // ----------------------------------------------------
    /** 数据来源标记，用于标记当前文档格式为RMPS系统格式数据。 此数值即ASCII字符集中的".WSD". */
    int FILE_HEAD_SIGN = 0x4453572E;
    /** 文件结束标记，即字符"Amon" */
    int FILE_TAIL_SIGN = 0x6E6F6D41;
    /** 当前文档格式对应系统版本标记，其对应信息如下： 字符串：01.000.060601.0001 存储值：0x0100 0060 6010 0010 */
    long FILE_VERSION = 0x0100006060100010L;
    /** 文本输出使用编码方案 */
    String FILE_ENCODING = "UTF-8";
    /** 系统默认使用的图像文件格式 */
    String FILE_IMAGETYPE = "PNG";
    // ////////////////////////////////////////////////////////////////////////
    // 操作系统平台区分常量
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数值标记
    // ----------------------------------------------------
    /** 所有平台 */
    int OS_IDX_ALL = 0x00000000;
    /** Linux平台 */
    int OS_IDX_LINUX = 0x00100000;
    /** Mac平台 */
    int OS_IDX_MACINTOSH = 0x00200000;
    /** Windows平台 */
    int OS_IDX_WINDOWS = 0x00400000;
    /** Uinx平台 */
    int OS_IDX_UNIX = 0x00800000;
    /** 未知平台（其它平台） */
    int OS_IDX_UNKNOWN = 0x00080000;
    /** 移动平台 */
    int OS_IDX_MOBILE = 0x00040000;
    // ----------------------------------------------------
    // 字符标记
    // ----------------------------------------------------
    /** Linux平台 */
    String OS_STR_LINUX = "linux";
    /** Mac平台 */
    String OS_STR_MACOS = "macintosh";
    /** Windows平台 */
    String OS_STR_WINDOWS = "windows";
    /** Uinx平台 */
    String OS_STR_UNIX = "unix";
    /** 未知平台（其它平台） */
    String OS_STR_UNKNOWN = "";
    /** 移动平台 */
    String OS_STR_MOBILE = "mobile";
    // ////////////////////////////////////////////////////////////////////////
    // 处理器架构常量
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数值标记
    // ----------------------------------------------------
    /** 未知 */
    int BITS_IDX_00 = 0x10000000;
    /** 1位 */
    int BITS_IDX_01 = 0x00000001;
    /** 2位 */
    int BITS_IDX_02 = 0x00000010;
    /** 4位 */
    int BITS_IDX_04 = 0x00000100;
    /** 8位 */
    int BITS_IDX_08 = 0x00001000;
    /** 16位 */
    int BITS_IDX_16 = 0x00010000;
    /** 32位 */
    int BITS_IDX_32 = 0x00100000;
    /** 64位 */
    int BITS_IDX_64 = 0x01000000;
    // ----------------------------------------------------
    // 字符标记
    // ----------------------------------------------------
    /** 未知 */
    String BITS_STR_00 = "其它";
    /** 1位 */
    String BITS_STR_01 = "1";
    /** 2位 */
    String BITS_STR_02 = "2";
    /** 4位 */
    String BITS_STR_04 = "4";
    /** 8位 */
    String BITS_STR_08 = "8";
    /** 16位 */
    String BITS_STR_16 = "16";
    /** 32位 */
    String BITS_STR_32 = "32";
    /** 64位 */
    String BITS_STR_64 = "64";
    // ////////////////////////////////////////////////////////////////////////
    // 系统共用资源
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数据库常量
    // ----------------------------------------------------
    /** 默认Hash字段字符长度 */
    int DBCD_HASH_SIZE = 16;
    /** 默认链接字段字符长度 */
    int DBCD_LINK_SIZE = 1024;
    /** 默认附注字段字符长度 */
    int DBCD_DESP_SIZE = 2048;
    /** 数据库当前时间 */
    String DBCD_DATE_TIME = "NOW";
    // ----------------------------------------------------
    // 图标控制常量
    // ----------------------------------------------------
    /** 大小为16像素的图像附加名称 */
    String ICON_SIZE_0016 = "0010";
    /** 大小为24像素的图像附加名称 */
    String ICON_SIZE_0024 = "0018";
    /** 大小为32像素的图像附加名称 */
    String ICON_SIZE_0032 = "0020";
    /** 大小为48像素的图像附加名称 */
    String ICON_SIZE_0048 = "0030";
    /** 大小为64像素的图像附加名称 */
    String ICON_SIZE_0064 = "0040";
    /** 大小为72像素的图像附加名称 */
    String ICON_SIZE_0072 = "0048";
    /** 大小为80像素的图像附加名称 */
    String ICON_SIZE_0080 = "0050";
    /** 大小为96像素的图像附加名称 */
    String ICON_SIZE_0096 = "0060";
    /** 大小为48像素的图像附加名称 */
    String ICON_SIZE_0128 = "0080";
    /** 大小为256像素的图像附加名称 */
    String ICON_SIZE_0256 = "0100";
    // ----------------------------------------------------
    // 界面默认常量
    // ----------------------------------------------------
    /** 界面默认使用语言：简体中文 */
    String UI_LANGHASH = "qqqqqaadedvccyfg";
    /** 界面默认使用语言：简体中文 */
    String UI_LANGNAME = "简体中文";
    /** 界面默认使用皮肤 */
    String UI_SKINHASH = "default";
    /** 界面皮肤显示文本 */
    String UI_SKINNAME = "默认皮肤";
    /** 网站首页 */
    String HOMEPAGE = "http://www.amonsoft.cn/";
    /** 软件更新配置文件 */
    String UPDTFILE = HOMEPAGE + "down/amon.xml";
    /** 电子邮件 */
    String MAILADDR = "Amon.CT@163.com";
    /** 启动模式标记 */
    String ARGS_WEBSTART = "JavaWebStart";
    /**     */
    char[] UPPER_DIGEST =
    {
        'Q', 'A', 'Z', 'W', 'S', 'X', 'E', 'D', 'C', 'R', 'F', 'V', 'T', 'G', 'B', 'Y'
    };
    /**     */
    char[] LOWER_DIGEST =
    {
        'q', 'a', 'z', 'w', 's', 'x', 'e', 'd', 'c', 'r', 'f', 'v', 't', 'g', 'b', 'y'
    };
    /**     */
    char[] UPPER_NUMBER =
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };
    /**     */
    char[] LOWER_NUMBER =
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
        'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    };
}
