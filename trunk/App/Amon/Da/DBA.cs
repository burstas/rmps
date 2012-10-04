﻿using System.Collections.Generic;
using Me.Amon.Gtd.M;
using Me.Amon.M;
using Me.Amon.Pwd.M;

namespace Me.Amon.Da
{
    public interface DBA
    {
        bool Suspended { get; }

        void Suspend();

        void Resume();

        void CloseConnect();

        /// <summary>
        /// 读取数据版本
        /// </summary>
        /// <returns></returns>
        Dbv DbVersion { get; }

        #region 数据更新
        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="vcs"></param>
        void SaveVcs(Vcs vcs);

        /// <summary>
        /// 存储日志
        /// </summary>
        /// <param name="log"></param>
        void SaveLog(Log log);
        #endregion

        #region 数据删除
        /// <summary>
        /// 逻辑移除
        /// </summary>
        /// <param name="vcs"></param>
        void RemoveVcs(Vcs vcs);

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="vcs"></param>
        void DeleteVcs(Vcs vcs);

        void DeleteLog(Log log);
        #endregion

        #region 字符操作
        IList<Udc> ListUdc();
        #endregion

        #region 类别操作
        Cat ReadCat(string catId);

        IList<Cat> FindCat(string appId, string catMeta);

        IList<Cat> ListCat(string appId, string parentId);
        #endregion

        #region 记录操作
        Key ReadKey(string keyId);

        IList<Key> FindKey(string keyMeta);

        IList<Key> ListKey(string catId);

        IList<Key> FindKeyByLabel(int label);

        IList<Key> FindKeyByMajor(int major);
        #endregion

        #region 日志操作
        KeyLog ReadKeyLog(string logId);

        IList<KeyLog> ListKeyLog(string keyId);
        #endregion

        #region 模板操作
        IList<Lib> ListLib();
        #endregion

        #region 目录操作
        IList<Dir> ListDir();
        #endregion

        #region 定时任务
        IList<MGtd> ListGtdWithRef();

        IList<MGtd> FindKeyByGtdExpired();
        #endregion
    }
}