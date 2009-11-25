/*
 * FileName:       AsocUserData.java
 * CreateDate:     Jul 4, 2007 2:34:49 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import rmp.face.WUserData;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;
import cons.prp.aide.extparse.LangRes;

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
 * 日期： Jul 4, 2007 2:34:49 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class AsocUserData extends WUserData
{
    /** 特别后缀索引 */
    private String asocIndx;
    /** 备选软件索引(已有) */
    private String softIndx_O;
    /** 备选软件索引(新增) */
    private String softIndx;
    /** 备选软件描述 */
    private String asocDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        asocIndx = ConstUI.DEF_ASOCHASH;
        softIndx = ConstUI.DEF_SOFTHASH;
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WUserData#t2db()
     */
    @ Override
    public boolean t2db()
    {
        asocDesp = StringUtil.toDBText(asocDesp);
        return true;
    }

    /**
     * @return the asocDesp
     */
    public String getAsocDesp()
    {
        return asocDesp;
    }

    /**
     * @param asocDesp the asocDesp to set
     */
    public boolean setAsocDesp(String asocDesp)
    {
        validate = CheckUtil.isValidateLength(asocDesp, DB0008.ASOCDATA_ASOCDESP_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.ASOC_COMN_TEXT_ASOCDESP, ""
                + DB0008.ASOCDATA_ASOCDESP_SIZE);
            return false;
        }

        this.asocDesp = asocDesp;
        return true;
    }

    /**
     * @return the asocIndx
     */
    public String getAsocIndx()
    {
        return asocIndx;
    }

    /**
     * @param asocIndx the asocIndx to set
     */
    public boolean setAsocIndx(String asocIndx)
    {
        this.asocIndx = asocIndx;
        return true;
    }

    /**
     * 此字段仅在数据更新时使用，用于更新已有软件数据
     * 
     * @return the softIndx
     */
    public String getSoftIndx_O()
    {
        return softIndx_O;
    }

    /**
     * @param softIndx the softIndx to set
     */
    public boolean setSoftIndx_O(String softIndx)
    {
        validate = CheckUtil.isValidate(softIndx) && !ConstUI.DEF_SOFTHASH.equals(softIndx);

        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.ASOC_COMN_TEXT_ASOCSOFT);
            return false;
        }
        this.softIndx_O = softIndx;

        return true;
    }

    /**
     * @return the softIndx
     */
    public String getSoftIndx()
    {
        return softIndx;
    }

    /**
     * @param softIndx the softIndx to set
     */
    public boolean setSoftIndx(String softIndx)
    {
        validate = CheckUtil.isValidate(softIndx) && !ConstUI.DEF_SOFTHASH.equals(softIndx);

        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.ASOC_COMN_TEXT_ASOCSOFT);
            return false;
        }
        this.softIndx = softIndx;

        return true;
    }
}
