/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.bean;

import java.io.Serializable;

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
public class K1IV3S implements Serializable, Cloneable
{
    /** 区分键值 */
    private int k;
    /** 显示信息 */
    private String v1;
    /** 提示信息 */
    private String v2;
    /** 实际信息 */
    private String v3;

    /**
     * 
     */
    public K1IV3S()
    {
    }

    /**
     * @param k
     * @param v1
     * @param v2
     * @param v3
     */
    public K1IV3S(int k, String v1, String v2, String v3)
    {
        this.k = k;
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    /**
     * @return the k
     */
    public int getK()
    {
        return k;
    }

    /**
     * @param k the k to set
     */
    public void setK(int k)
    {
        this.k = k;
    }

    /**
     * @return the v1
     */
    public String getV1()
    {
        return v1;
    }

    /**
     * @param v1 the v1 to set
     */
    public void setV1(String v1)
    {
        this.v1 = v1;
    }

    /**
     * @return the v2
     */
    public String getV2()
    {
        return v2;
    }

    /**
     * @param v2 the v2 to set
     */
    public void setV2(String v2)
    {
        this.v2 = v2;
    }

    /**
     * @return the v3
     */
    public String getV3()
    {
        return v3;
    }

    /**
     * @param v3 the v3 to set
     */
    public void setV3(String v3)
    {
        this.v3 = v3;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#clone()
     */
    public Object clone() throws CloneNotSupportedException
    {
        K1IV3S kv = (K1IV3S) super.clone();
        kv.setK(getK());
        kv.setV1(getV1());
        kv.setV2(getV2());
        kv.setV3(getV3());
        return kv;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object obj)
    {
        // 比较对象为K1IV2S时，判断两都的Key是否相同
        if (obj instanceof K1IV3S)
        {
            K1IV3S kv = (K1IV3S) obj;
            return getK() == kv.getK();
        }

        // 比较对象为String时，判断两都的显示值是否相同
        if (getV1() != null)
        {
            return getV1().equals(obj);
        }

        // 两都同时为NULL时，认为两都相同
        return obj == null;

    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#toString()
     */
    public String toString()
    {
        return v1;
    }
    /** serialVersionUID */
    private static final long serialVersionUID = -6193908676696837884L;
}