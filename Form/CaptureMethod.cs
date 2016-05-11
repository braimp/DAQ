using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Form
{
    public class CaptureMethod
    {
        /// <summary>
        /// 权重设置xml文件地址
        /// </summary>
        private static string FilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "app.xml";

            }
        }
        private static string FileCategory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "Category.xml";
            }
        }
        public void CreateDefualExpNode(string id)
        {
            var roots = XElement.Load(FilePath);
            var targetNodes = (from target in roots.Elements("DAQ")
                               where target.Element("Id").Value.Trim() == id.Trim()
                               select target);
            var p = targetNodes.Elements("CaptureData");
            if (p.Count() == 0)
            {
                foreach (var node in targetNodes)
                {
                    node.Add(new XElement("CaptureData",
                        new XElement("expression",
                            new XAttribute("ChinaName", "品名"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Breed"), new XCData("//span[1]")
                            ),
                            new XElement("expression",
                            new XAttribute("ChinaName", "批发市场"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Place"), new XCData("//span[@class='region']")
                            ),
                            new XElement("expression",
                            new XAttribute("ChinaName", "价格"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Price"), new XCData("//span[@class='price']")
                            ),
                            new XElement("expression",
                            new XAttribute("ChinaName", "报价时间"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Date"), new XCData("//span[@class='time']")
                            )
                            ));
                }
            }
            else
            {
                foreach (var node in p)
                {
                    node.Add(
                        new XElement("expression",
                            new XAttribute("ChinaName", "品名"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Breed"), new XCData("//span[1]")
                            ),
                            new XElement("expression",
                            new XAttribute("ChinaName", "批发市场"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Place"), new XCData("//span[@class='region']")
                            ),
                            new XElement("expression",
                            new XAttribute("ChinaName", "价格"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Price"), new XCData("//span[@class='price']")
                            ),
                            new XElement("expression",
                            new XAttribute("ChinaName", "报价时间"),
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("Name", "Date"), new XCData("//span[@class='time']")
                            )
                            );
                }
            }
            //保存对xml的更改操作
            roots.Save(FilePath);
        }


        public void CreateXElement(CaptureBasicEntity entity)
        {
            var doc = XDocument.Load(FilePath);
            if (doc.Root != null)
                doc.Root.Add(new XElement("DAQ",
                    new XElement("Id", entity.Id),
                    new XElement("SiteName", entity.SiteName),
                    new XElement("SiteUrl", entity.SiteUrl),
                    new XElement("SiteEncoding", entity.SiteEncoding),
                    new XElement("SitePageNumbers", entity.SitePageNumbers),
                    new XElement("SitePagerparameter", entity.SitePagerparameter),
                    new XElement("SitePageCount", entity.SitePageCount),
                    new XElement("Start", entity.StartRegex),
                    new XElement("PageExp", entity.PageExp),
                    new XElement("ParentId", entity.ParentId),
                    new XElement("ParentText", entity.ParentText),
                    new XElement("CreatedDateTime", entity.CreatedDateTime)
                    ));
            doc.Save(FilePath);
            //  CreateDefualExpNode(entity.Id.ToString());
        }

        public void DeleteXmlNode(string id)
        {
            var roots = XElement.Load(FilePath);

            var targetNodes = from target in roots.Elements("DAQ")
                              where target.Element("Id").Value.Trim() == id.Trim()
                              select target;
            foreach (var node in targetNodes)
            {
                node.Remove();
            }
            //保存对xml的更改操作
            roots.Save(FilePath);
        }
        public void DeleteXmlCategoryNode(string id)
        {
            var doc = XDocument.Load(FileCategory);
            var q = from node in doc.Descendants("category")
                    let attr = node.Element("id")
                    where attr != null && attr.Value.Trim() == id.Trim()
                    select node;

            q.ToList().ForEach(x => x.Remove());

            //保存对xml的更改操作
            doc.Save(FileCategory);
            DeleteXmlCategoryChildNode(id);
        }

        public void DeleteXmlCategoryChildNode(string id)
        {
            var doc = XDocument.Load(FilePath);
            var q = from node in doc.Descendants("DAQ")
                    let attr = node.Element("ParentId")
                    where attr != null && attr.Value.Trim() == id.Trim()
                    select node;
            q.ToList().ForEach(x => x.Remove());
            doc.Save(FilePath);
        }

        public void ModifyXmlNode(CaptureBasicEntity entity)
        {
            //定义并从xml文件中加载节点（根节点）
            var roots = XElement.Load(FilePath);

            var targetNodes = from target in roots.Elements("DAQ")
                              where target.Element("Id").Value == entity.Id.ToString()
                              select target;


            foreach (var node in targetNodes)
            {
                node.SetElementValue("SiteName", entity.SiteName);
                node.SetElementValue("SiteUrl", entity.SiteUrl);
                node.SetElementValue("SiteEncoding", entity.SiteEncoding);
                node.SetElementValue("SitePageNumbers", entity.SitePageNumbers);
                node.SetElementValue("SitePagerparameter", entity.SitePagerparameter);
                node.SetElementValue("SitePageCount", entity.SitePageCount);
                node.SetElementValue("Start", entity.StartRegex);
                node.SetElementValue("PageExp", entity.PageExp);
                node.SetElementValue("ParentId", entity.ParentId);
                node.SetElementValue("ParentText", entity.ParentText);
                node.SetElementValue("CreatedDateTime", entity.CreatedDateTime);
            }
            //保存对xml的更改操作
            roots.Save(FilePath);
        }
        public static IEnumerable DataChildSource()
        {
            var root = XElement.Load(FilePath);

            var query = (from xElem in root.Elements("DAQ")
                         select new
                         {
                             Id = (string)xElem.Element("Id"),
                             SiteName = (string)xElem.Element("SiteName"),
                             SiteUrl = (string)xElem.Element("SiteUrl"),
                             SiteEncoding = (string)xElem.Element("SiteEncoding"),
                             SitePageNumbers = (string)xElem.Element("SitePageNumbers"),
                             SitePagerparameter = (string)xElem.Element("SitePagerparameter"),
                             SitePageCount = (string)xElem.Element("SitePageCount"),
                             Start = (string)xElem.Element("Start"),
                             ParentId = (string)xElem.Element("ParentId"),
                             ParentText = (string)xElem.Element("ParentText"),
                             PageExp = (string)xElem.Element("PageExp")
                         }).ToList();
            return query;
        }
        public static IEnumerable DataSource()
        {
            var root = XElement.Load(FileCategory);
            var query = (from xElem in root.Elements("category")
                         select new
                         {
                             id = (string)xElem.Element("id"),
                             name = (string)xElem.Element("name"),
                         }).ToList();
            return query;
        }

        public void ModifyCategoryXmlNode(string id, string name)
        {
            //定义并从xml文件中加载节点（根节点）
            var roots = XElement.Load(FileCategory);

            var targetNodes = from xElem in roots.Descendants("category")
                              where xElem.Element("id").Value.Trim() == id.Trim()
                              select xElem;

            foreach (var node in targetNodes)
            {
                node.SetElementValue("name", name);
            }
            //保存对xml的更改操作
            roots.Save(FileCategory);
        }

        public void CreateCategoryXElement(string cname)
        {
            var doc = XDocument.Load(FileCategory);

            var max = (from xElem in doc.Descendants("category")
                       select new
                       {
                           id = (int)xElem.Element("id"),
                           name = (string)xElem.Element("name")
                       }).Max(x => x.id);


            if (doc.Root != null)
                doc.Root.Add(new XElement("category",
                    new XElement("id", max + 1),
                    new XElement("name", cname)
                    ));
            doc.Save(FileCategory);
        }
        public void CreateExpNode(ExpEntity entity, string Id)
        {
            var roots = XElement.Load(FilePath);
            var targetNodes = (from target in roots.Elements("DAQ")
                               where target.Element("Id").Value == Id
                               select target);
            var p = targetNodes.Elements("CaptureData");
            if (p.Count() == 0)
            {
                foreach (var node in targetNodes)
                {
                    node.Add(new XElement("CaptureData",
                        new XElement("expression",
                            new XAttribute("ChinaName", entity.ChinaName),
                            new XAttribute("Id", entity.Id),
                            new XAttribute("Name", entity.Name), new XCData(entity.ExpText)
                            )));
                }
            }
            else
            {
                foreach (var node in p)
                {
                    node.Add(
                        new XElement("expression",
                            new XAttribute("ChinaName", entity.ChinaName),
                            new XAttribute("Id", entity.Id),
                            new XAttribute("Name", entity.Name), new XCData(entity.ExpText)
                            ));
                }
            }
            //保存对xml的更改操作
            roots.Save(FilePath);
        }

        public XElement ModifyExpNode(ExpEntity entity, string Id)
        {
            var roots = XElement.Load(FilePath);
            var targetNodes = (from target in roots.Elements("DAQ")
                               where target.Element("Id").Value == Id
                               select target).Elements("CaptureData").Elements("expression").Single(x =>
                                   x.Attribute("Id").ToString().Trim() == entity.Id.ToString().Trim());
            if (targetNodes != null)
            {
                targetNodes.SetValue(new XCData(entity.ExpText));
                targetNodes.SetAttributeValue("ChinaName", entity.ChinaName);
                targetNodes.SetAttributeValue("Name", entity.Name);
                targetNodes.SetAttributeValue("Id", entity.Id);

            }
            //保存对xml的更改操作
            roots.Save(FilePath);
            return roots;
        }
    }
}
