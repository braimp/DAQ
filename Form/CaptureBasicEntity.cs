using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form
{
    public class CaptureBasicEntity
    {
       
        /// <summary>
        /// 站点编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 站点名
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// 站点地址
        /// </summary>
        public string SiteUrl { get; set; }
        /// <summary>
        /// 站点编码
        /// </summary>
        public string SiteEncoding { get; set; }
        /// <summary>
        /// 采集条数
        /// </summary>
        public int SitePageNumbers { get; set; }
        /// <summary>
        /// 分页参数
        /// </summary>
        public string SitePagerparameter { get; set; }
        /// <summary>
        /// 分页总数
        /// </summary>
        public int SitePageCount { get; set; }
        /// <summary>
        /// 起始位置
        /// </summary>
        public string StartRegex { get; set; }
        /// <summary>
        /// 分页url
        /// </summary>
        public string PageUrl { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ParentId;
        public string PageExp { get; set; }

        public string ParentText { get; set; }
    }

    public class ExpEntity
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ChinaName { get; set; }
        public string ExpText { get; set; }
    }
}
