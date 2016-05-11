using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Form
{
    public partial class RadForm1 : RadForm
    {
        private static DataTable data = null;

        RadGridLocalizationProvider _oldProvider;
        private static string FilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "app.xml";
            }
        }

        private static string FileLoading
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "Resource/loading.gif";
            }
        }
        public RadForm1()
        {
            InitializeComponent();
            _oldProvider = RadGridLocalizationProvider.CurrentProvider;
           // RadGridLocalizationProvider.CurrentProvider = new ChineseRadGridLocalizationProvider();
            ComboBoxBind();

            Category.DataSource = CaptureMethod.DataSource();
            Category.DisplayMember = "name";
            Category.ValueMember = "id";
            DataBind();
        }
        private void DataBind()
        {
            var acCode = new GridViewCheckBoxColumn
            {
                Name = "tId",
                HeaderText = @"选择",
                AllowGroup = false
            };
            var acCodeb = new GridViewCheckBoxColumn
            {
                Name = "bId",
                HeaderText = @"选择",
                AllowGroup=false
            };
            if (radGridView1.Columns.Count > 2)
            {
                radGridView1.Columns.Remove("bId");
            }
            radGridView1.Columns.Add(acCodeb);
            radGridView1.DataSource = CaptureMethod.DataSource();
            radGridView1.Refresh();
            var template = new GridViewTemplate
            {
                AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill,
                DataSource = CaptureMethod.DataChildSource(),
                AllowAddNewRow = false
            };


            template.Columns.Add(acCode);
            template.Columns["Id"].HeaderText = @"编号";
            template.Columns["Id"].IsVisible = false;
            template.Columns["SiteName"].HeaderText = @"站点名称";
            template.Columns["SiteUrl"].HeaderText = @"站点地址";
            template.Columns["SiteEncoding"].HeaderText = @"站点编码";
            template.Columns["SitePageNumbers"].HeaderText = @"条数";
            template.Columns["SitePagerparameter"].HeaderText = @"分页参数";
            template.Columns["SitePageCount"].HeaderText = @"页数";
            template.Columns["Start"].HeaderText = @"起始位置";
            template.Columns["PageExp"].HeaderText = @"分页表达式";
            template.Columns["ParentText"].HeaderText = @"类别";
            template.Columns["ParentId"].IsVisible = false;
            radGridView1.MasterTemplate.Templates.Clear();
            radGridView1.MasterTemplate.Templates.Remove(template);
            radGridView1.MasterTemplate.Templates.Add(template);

            var relation = new GridViewRelation(radGridView1.MasterTemplate)
            {
                ChildTemplate = template,
                RelationName = "ParentDetail"
            };

            relation.ParentColumnNames.Add("Id");
            relation.ChildColumnNames.Add("ParentId");

            radGridView1.Relations.Add(relation);

        }



        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            _pagenum = 1;
            var thread = new Thread(() => CaptureRun(_pagenum));
            thread.Start();
        }
        private void Loading()
        {
            radGridView2.BeginInvoke((MethodInvoker)delegate
            {
                radGridView2.DataSource = null;

            });


            pictureBox1.BeginInvoke((MethodInvoker)delegate
            {
                pictureBox1.Load(FileLoading);
                pictureBox1.BackColor = Color.White;
                pictureBox1.Visible = true;
            });
        }
        private void CaptureRun(Int32 num)
        {
            // Thread.Sleep(5000); 
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
                             PageExp = (string)xElem.Element("PageExp")
                         }).AsQueryable();
            var ids = new List<string>();
            foreach (var row in radGridView1.MasterGridViewTemplate.ChildGridViewTemplates[0].Rows)
            {
                if (Convert.ToBoolean(row.Cells[11].Value))
                {
                    var id = row.Cells[0].Value.ToString();
                    ids.Add(id);
                }
            }
            if (ids.Any())
            {
                Loading();
                var queryable = from c in query join id in ids on c.Id equals id select c;
                var dt = new DataTable();
                foreach (var p in queryable.ToList())
                {
                    var entity = new CaptureBasicEntity
                    {
                        Id = Guid.Parse(p.Id),
                        SiteUrl = p.SiteUrl,
                        SiteEncoding = p.SiteEncoding,
                        SitePageNumbers = int.Parse(p.SitePageNumbers),
                        SitePagerparameter = p.SitePagerparameter,
                        SitePageCount = int.Parse(p.SitePageCount),
                        StartRegex = p.Start,
                        PageExp = p.PageExp
                    };
                    var c = new CaptureRun();
                    var table = RemoveAllNullRowsFromDataTable(c.CaptureData(entity, num));
                    dt.Merge(table);
                }

                if (radGridView2.Columns.Count > 0)
                {

                    if (radGridView2.Columns[0].Name != "Id")
                    {
                        var acCode = new GridViewCheckBoxColumn
                        {
                            Name = "Id",
                            HeaderText = @"选择",
                            MaxWidth = 40,
                            MinWidth = 40,
                            AllowGroup = false
                        };
                        // radGridView2.Columns.Add(acCode);
                        radGridView2.MasterTemplate.Columns.Add(acCode);
                    }
                }
                else
                {
                    var acCode = new GridViewCheckBoxColumn
                    {
                        Name = "Id",
                        HeaderText = @"选择",
                        MaxWidth = 40,
                        MinWidth = 40
                    };
                    // radGridView2.Columns.Add(acCode);
                    radGridView2.MasterTemplate.Columns.Add(acCode);
                }

                radGridView2.BeginInvoke((MethodInvoker)delegate
                {
                    radGridView1.UseWaitCursor = false;
                    radGridView2.DataSource = dt;
                    radGridView2.Refresh();
                });

                data = dt;
                AppClosing();
            }
            else
            {
                MessageBox.Show(@"请选择你需要抓取的网站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AppClosing()
        {

            pictureBox1.BeginInvoke((MethodInvoker)delegate
            {
                pictureBox1.Load(FileLoading);
                pictureBox1.BackColor = Color.White;
                pictureBox1.Visible = false;
            });
        }
        public static DataTable RemoveAllNullRowsFromDataTable(DataTable dt)
        {
            int columnCount = dt.Columns.Count;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                bool allNull = true;
                for (int j = 0; j < columnCount; j++)
                {
                    if (dt.Rows[i][j] != DBNull.Value)
                    {
                        allNull = false;
                    }
                }
                if (allNull)
                {
                    dt.Rows[i].Delete();
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        public int _pagenum { get; set; }

        private void PreBtn_Click(object sender, EventArgs e)
        {
            _pagenum = _pagenum - 1;
            if (_pagenum > 0)
            {
                var thread = new Thread(() => CaptureRun(_pagenum));
                thread.Start();
            }
            else
            {
                _pagenum = 1;
            }

        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            _pagenum = _pagenum + 1;
            if (_pagenum > 0)
            {
                var thread = new Thread(() => CaptureRun(_pagenum));
                thread.Start();
            }
            else
            {
                _pagenum = 1;
            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var entity = new CaptureBasicEntity
            {
                SiteName = SiteName.Text,
                SiteUrl = SiteUrl.Text,
                SiteEncoding = SiteEncoding.Text,
                SitePageNumbers = Int32.Parse(SitePageNumbers.Text),
                SitePagerparameter = SitePagerparameter.Text,
                SitePageCount = Int32.Parse(SitePageCount.Text),
                StartRegex = StartRegex.Text,
                PageExp = PageExp.Text,
                ParentId = Category.SelectedValue.ToString(),
                ParentText = Category.Text
            };
            var method = new CaptureMethod();
            entity.Id = Guid.NewGuid();
            method.CreateXElement(entity);
            method.CreateDefualExpNode(entity.Id.ToString());
            DataBind();
            MessageBox.Show(@"保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ComboBoxBind()
        {
            SiteEncoding.Items.Add(new ComboboxItem("UTF-8", "UTF-8"));
            SiteEncoding.Items.Add(new ComboboxItem("gb2312", "gb2312"));
            SiteEncoding.Items.Add(new ComboboxItem("gbk", "gbk"));
            SiteEncoding.SelectedIndex = 0;
        }
        private void radButton2_Click(object sender, EventArgs e)
        {
            var entity = new CaptureBasicEntity
            {
                SiteName = SiteName.Text,
                SiteUrl = SiteUrl.Text,
                SiteEncoding = SiteEncoding.Text,
                SitePageNumbers = Int32.Parse(SitePageNumbers.Text),
                SitePagerparameter = SitePagerparameter.Text,
                SitePageCount = Int32.Parse(SitePageCount.Text),
                StartRegex = StartRegex.Text,
                PageExp = PageExp.Text,
                ParentId = Category.SelectedValue.ToString(),
                ParentText = Category.Text
            };
            var id = labelId.Text.Trim();
            var method = new CaptureMethod();
            if (!string.IsNullOrWhiteSpace(id))
            {
                entity.Id = Guid.Parse(id);
                method.ModifyXmlNode(entity);
                MessageBox.Show(@"保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(@"修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataBind();
        }

        private void SiteName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(SiteName, "");
        }

        private void SiteName_Validating(object sender, CancelEventArgs e)
        {

            string errorMsg;
            if (!IsNullOrWhiteSpace(SiteName.Text, out errorMsg))
            {
                e.Cancel = true;
                SitePageCount.Select(0, SiteName.Text.Length);
                errorProvider1.SetError(SiteName, errorMsg);
            }
        }
        static bool IsNullOrWhiteSpace(string str, out string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                errorMessage = "";
                return true;
            }
            errorMessage = "输入不可为空";
            return false;
        }

        private void SiteUrl_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!IsNullOrWhiteSpace(SiteUrl.Text, out errorMsg))
            {
                e.Cancel = true;
                SitePageCount.Select(0, SiteUrl.Text.Length);
                errorProvider1.SetError(SiteUrl, errorMsg);
            }
        }

        private void SiteUrl_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(SiteUrl, "");
        }
        private void SitePageNumbers_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(SitePageNumbers, "");
        }

        private void SitePageNumbers_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!IsNumberR(SitePageNumbers.Text, out errorMsg))
            {
                e.Cancel = true;
                SitePageNumbers.Select(0, SitePageNumbers.Text.Length);
                errorProvider1.SetError(SitePageNumbers, errorMsg);
            }
        }
        static bool IsNumberR(string str, out string errorMessage)
        {
            var regex = new Regex(@"^[0-9]\d*$");
            if (regex.IsMatch(str))
            {
                errorMessage = "";
                return true;
            }
            errorMessage = "请输入正确数字格式";
            return false;
        }

        private void SitePageCount_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!IsNumberR(SitePageCount.Text, out errorMsg))
            {
                e.Cancel = true;
                SitePageCount.Select(0, SitePageNumbers.Text.Length);
                errorProvider1.SetError(SitePageCount, errorMsg);
            }
        }

        private void SitePageCount_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(SitePageCount, "");
        }

        private void StartRegex_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!IsNullOrWhiteSpace(StartRegex.Text, out errorMsg))
            {
                e.Cancel = true;
                SitePageCount.Select(0, StartRegex.Text.Length);
                errorProvider1.SetError(StartRegex, errorMsg);
            }
        }

        private void StartRegex_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(StartRegex, "");
        }



        private void radButton4_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(exportexcel);
            Thread thread = new Thread(threadStart);
            //thread.SetApartmentState(ApartmentState.MTA);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        public  void exportexcel()
        {
            if (radGridView2.Rows.Count > 0)
            {
                var excel = new ExportExcel();
                excel.DataExportExcel(radGridView2);
            }
            else
            {
                MessageBox.Show(@"无数据可保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            for (var i = radGridView2.Rows.Count - 1; i >= 0; i--)
            {
                var dgvr = radGridView2.Rows[i].Cells["Id"];

                if (dgvr.Value == null && !Convert.ToBoolean(dgvr.Value))
                {
                    radGridView2.Rows.RemoveAt(i);
                }
            }
            radGridView2.Refresh();
        }

        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.ViewTemplate == this.radGridView1.MasterGridViewTemplate.ChildGridViewTemplates[0])
            {
                var currenrow = e.Row.ViewInfo.CurrentRow.Index;
                if (currenrow >= 0)
                {
                    var id = e.Row.ViewInfo.Rows[currenrow].Cells[0].Value.ToString();
                    labelId.Text = id.Trim();
                    SiteName.Text = e.Row.ViewInfo.Rows[currenrow].Cells[1].Value.ToString();
                    SiteUrl.Text = e.Row.ViewInfo.Rows[currenrow].Cells[2].Value.ToString();
                    SiteEncoding.Text = e.Row.ViewInfo.Rows[currenrow].Cells[3].Value.ToString();
                    SitePageNumbers.Text = e.Row.ViewInfo.Rows[currenrow].Cells[4].Value.ToString();
                    SitePagerparameter.Text = e.Row.ViewInfo.Rows[currenrow].Cells[5].Value.ToString();
                    SitePageCount.Text = e.Row.ViewInfo.Rows[currenrow].Cells[6].Value.ToString();
                    StartRegex.Text = e.Row.ViewInfo.Rows[currenrow].Cells[7].Value.ToString();
                    PageExp.Text = e.Row.ViewInfo.Rows[currenrow].Cells[10].Value.ToString();
                    Category.SelectedValue = e.Row.ViewInfo.Rows[currenrow].Cells[8].Value.ToString();
                }
            }
        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row.ViewTemplate == this.radGridView1.MasterGridViewTemplate.ChildGridViewTemplates[0])
            {
                var currenrow = e.Row.ViewInfo.CurrentRow.Index;
                if (currenrow >= 0)
                {
                    var id = e.Row.ViewInfo.Rows[currenrow].Cells[0].Value.ToString();
                    var frm = new RadForm2(id);
                    frm.Show();
                }
            }
            else
            {
                var currenrow = e.Row.ViewInfo.CurrentRow.Index;
                if (currenrow >= 0)
                {
                    var id = e.Row.ViewInfo.Rows[currenrow].Cells[0].Value.ToString();
                    var frm = new RadForm4(id);
                    frm.Show();
                }
            }
        }
        private void radButton6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("您确定要删除吗？", "提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {

                var method = new CaptureMethod();


                var pids = new List<string>();

                var ids = new List<string>();


                foreach (var row in radGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[2].Value))
                    {
                        var id = row.Cells[0].Value.ToString();
                        pids.Add(id);
                    }
                }
                foreach (var row in radGridView1.MasterGridViewTemplate.ChildGridViewTemplates[0].Rows)
                {
                    if (Convert.ToBoolean(row.Cells[11].Value))
                    {
                        var id = row.Cells[0].Value.ToString();
                        ids.Add(id);
                    }
                }
                if (pids.Any())
                {
                    foreach (var id in pids)
                    {
                        method.DeleteXmlCategoryNode(id);

                    }
                    DataBind();
                    MessageBox.Show("成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (ids.Any())
                    {
                        foreach (var id in ids)
                        {
                            method.DeleteXmlNode(id);
                        }
                        DataBind();
                        MessageBox.Show("成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(@"请选择要删除的项", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

    }
}
