﻿using System;
using System.Collections.Generic;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Me.Amon.Bean;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Da
{
    public class DBObject
    {
        private string _DbPath;
        private IObjectContainer _Container;
        private UserModel _UserModel;

        #region 构造函数
        public DBObject()
        {
        }

        public void Init(UserModel userModel)
        {
            _UserModel = userModel;
            _DbPath = Path.Combine(userModel.Home, IEnv.FILE_DB);

            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(Cat)).ObjectField("Id").Indexed(true);
            config.Common.ObjectClass(typeof(Rec)).ObjectField("Title").Indexed(true);
            config.Common.ObjectClass(typeof(Rec)).ObjectField("MetaKey").Indexed(true);
            _Container = Db4oEmbedded.OpenFile(_DbPath);
        }
        #endregion

        #region 连接管理
        public void CloseConnect()
        {
            if (_Container != null)
            {
                _Container.Close();
                _Container = null;
            }
        }
        #endregion

        public void SaveVcs(Vcs vcs)
        {
            if (vcs.Operate == DBConst.OPT_DEFAULT)
            {
                vcs.Version += 1;
            }

            if (vcs.Operate > DBConst.OPT_INSERT)
            {
                vcs.Operate += 1;
            }

            vcs.UserCode = _UserModel.Code;
            vcs.UpdateTime = DateTime.Now;
            if (!CharUtil.IsValidateHash(vcs.Id))
            {
                vcs.Id = HashUtil.UtcTimeInHex(false);
                vcs.CreateTime = vcs.UpdateTime;
            }
            _Container.Store(vcs);
        }

        /// <summary>
        /// 逻辑移除
        /// </summary>
        /// <param name="vcs"></param>
        public void RemoveVcs(Vcs vcs)
        {
            vcs.Operate = DBConst.OPT_DELETE;
            vcs.Version += 1;
            _Container.Store(vcs);
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="vcs"></param>
        public void DeleteVcs(Vcs vcs)
        {
            _Container.Delete(vcs);
        }

        #region 类别操作
        public Cat ReadCat(string catId)
        {
            IList<Cat> cats = _Container.Query<Cat>(delegate(Cat cat)
            {
                return cat.Id == catId;
            });

            return cats.Count > 0 ? cats[0] : null;
        }

        public IList<Cat> FindCat(string catName)
        {
            IList<Cat> cats = _Container.Query<Cat>(delegate(Cat cat)
            {
                return cat.Text.Contains(catName);
            });
            return cats;
        }

        public IList<Cat> ListCat(string parentId)
        {
            IList<Cat> cats = _Container.Query<Cat>(delegate(Cat cat)
            {
                return cat.Parent == parentId;
            });
            return cats;
        }
        #endregion

        #region 记录操作
        public Rec ReadRec(string recId)
        {
            IList<Rec> recs = _Container.Query<Rec>(delegate(Rec rec)
            {
                return rec.Id == recId;
            });

            return recs.Count > 0 ? recs[0] : null;
        }

        public IList<Rec> FindRec(string text)
        {
            string[] arr = text.Split(' ');

            IList<Rec> recs = _Container.Query<Rec>(delegate(Rec rec)
            {
                if (rec.Operate == DBConst.OPT_DELETE)
                {
                    return false;
                }

                string title = (rec.Title ?? "").ToLower();
                string meta = (rec.MetaKey ?? "").ToLower();
                foreach (string tmp in arr)
                {
                    if (title.Contains(tmp) || meta.Contains(tmp))
                    {
                        return true;
                    }
                }
                return false;
            });
            return recs;
        }

        public IList<Rec> FindRec(int label)
        {
            IList<Rec> recs = _Container.Query<Rec>(delegate(Rec rec)
            {
                return rec.Label == label;
            });
            return recs;
        }

        public IList<Rec> ListRec(string catId)
        {
            IList<Rec> recs = _Container.Query<Rec>(delegate(Rec rec)
            {
                if (rec.Operate == DBConst.OPT_DELETE)
                {
                    return false;
                }

                return rec.CatId == catId;
            });
            return recs;
        }
        #endregion

        #region 日志操作
        public Log ReadLog(string logId)
        {
            IList<Log> logs = _Container.Query<Log>(delegate(Log log)
            {
                return log.Id == logId;
            });

            return logs.Count > 0 ? logs[0] : null;
        }

        public IList<Log> ListLog(string recId)
        {
            IList<Log> logs = _Container.Query<Log>(delegate(Log log)
            {
                return log.Key.Id == recId;
            });
            return logs;
        }
        #endregion

        #region 属性操作
        public Key ReadKey(string recId)
        {
            IList<Key> keys = _Container.Query<Key>(delegate(Key key)
            {
                return key.RecId == recId;
            });

            return keys.Count > 0 ? keys[0] : null;
        }
        #endregion

        #region 模板操作
        public IList<LibHeader> ListLibHeader()
        {
            return _Container.Query<LibHeader>();
        }

        public LibDetail ReadLibDetail(string headerId)
        {
            IList<LibDetail> details = _Container.Query<LibDetail>(
                delegate(LibDetail detail)
                {
                    return detail.Header == headerId;
                }
            );

            return details.Count > 0 ? details[0] : null;
        }
        #endregion

        #region 字符操作
        public IList<Udc> ListUdc()
        {
            return _Container.Query<Udc>();
        }
        #endregion

        #region 字符操作
        public IList<Dir> ListDir()
        {
            return _Container.Query<Dir>();
        }
        #endregion
    }
}
