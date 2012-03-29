﻿using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Bean
{
    public class Lib : Vcs
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }

        public IList<LibDetail> Details { get; set; }

        public Lib()
        {
        }

        #region 方法重写
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region XML
        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Lib")
            {
                return false;
            }

            if (reader.Name == "Order" || reader.ReadToDescendant("Order"))
            {
                Order = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Id" || reader.ReadToNextSibling("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Name" || reader.ReadToNextSibling("Name"))
            {
                Name = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }

            Details = new List<LibDetail>();
            if (reader.Name == "Items" || reader.ReadToNextSibling("Items"))
            {
                reader.ReadStartElement();

                LibDetail detail;
                while (reader.Name == "Item" || reader.ReadToNextSibling("Item"))
                {
                    detail = new LibDetail();
                    detail.FromXml(reader);
                    detail.Header = Id;
                    detail.UserCode = UserCode;
                    detail.Order = Details.Count;
                    Details.Add(detail);
                }

                reader.ReadEndElement();
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Lib");

            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Memo", Memo);

            writer.WriteStartElement("Items");
            foreach (LibDetail detail in Details)
            {
                detail.ToXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
        #endregion

        public void Add(LibDetail detail)
        {
            if (Details == null)
            {
                Details = new List<LibDetail>();
            }
            Details.Add(detail);
            Details.Remove(detail);
        }

        public void Remove(LibDetail detail)
        {
            if (Details == null)
            {
                return;
            }
            Details.Remove(detail);
        }
    }
}