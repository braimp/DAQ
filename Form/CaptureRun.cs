using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using HtmlAgilityPack;
using ScrapySharp.Network;

namespace Form
{
    public class CaptureRun
    {
        private static string FilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "app.xml";

            }
        }

        public string EvalExpress(string exp, Int32 page)
        {
            var ex = exp.Replace("#page#", "" + page);
            var dt = new DataTable();
            var result = dt.Compute(ex, "").ToString();
            return result;
        }

        public DataTable CaptureData(CaptureBasicEntity regex, Int32 num = 1)
        {
            var dt = new DataTable();
            var root = XElement.Load(FilePath);
            var query = (from xElem in root.Elements("DAQ")
                         where
                             xElem.Element("Id").Value.Trim() == regex.Id.ToString().Trim()
                         select xElem).Elements("CaptureData").Elements("expression").Select(
                x => new
                {
                    Id = x.Attribute("Id").Value,
                    Name = x.Attribute("Name").Value,
                    ChinaName = x.Attribute("ChinaName").Value,
                    Exp = x.Value,
                }).ToList();
            var length = query.Count();
            var dtArry = new DataColumn[length];
            var count = 0;
            foreach (var p in query)
            {
                dtArry[count] = new DataColumn()
                {
                    ColumnName = p.ChinaName
                };
                count++;
            }
            dt.Columns.AddRange(dtArry);
            var pagenum = EvalExpress(regex.PageExp, num);
            var url = new Uri(regex.SiteUrl + "/" + pagenum);
            var browser = new ScrapingBrowser()
            {
                Encoding = Encoding.GetEncoding(regex.SiteEncoding),
                AutoDetectCharsetEncoding = false
            };
            var html = browser.DownloadString(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var list = doc.DocumentNode.SelectNodes(regex.StartRegex);
            if (list != null)
            {
                foreach (var item in list)
                {
                    var adoc = new HtmlDocument();
                    adoc.LoadHtml(item.InnerHtml);
                    var navigator = (HtmlNodeNavigator)adoc.CreateNavigator();
                    var dr = dt.NewRow();
                    foreach (var p in query)
                    {
                        var text = navigator.SelectSingleNode(p.Exp).ToString();
                        dr[p.ChinaName] = Regex.Replace(text, @"<[^>]+>|&nbsp;", "").Trim();

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
