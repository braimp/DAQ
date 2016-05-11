using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;

namespace Form
{
    public partial class RadForm4 : RadForm
    {
        private readonly string _txtVal;//上一窗体带过来的值
        private static string FilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "Category.xml";
            }
        }
        public RadForm4()
        {
            InitializeComponent();
        }
        public RadForm4(string txt) //重载构造函数
        {
            this._txtVal = txt;//获取传过来的值
            InitializeComponent();
            ShowPara();

        }

        private void ShowPara()
        {
            radLabel2.Text = _txtVal;
            var root = XElement.Load(FilePath);

            var queryForDetail = (from xElem in root.Elements("category")
                                  where xElem.Element("id").Value == _txtVal
                                  select new
                                  {
                                      id = (string)xElem.Element("id"),
                                      name = (string)xElem.Element("name"),
                                  });

            var firstOrDefault = queryForDetail.FirstOrDefault();
            if (firstOrDefault != null)
            {
                radTextBox1.Text = firstOrDefault.name;
            }
            DataBind();
        }

        private void DataBind()
        {
            var root = XElement.Load(FilePath);
            var query = (from xElem in root.Elements("category")
                         select new
                         {
                             id = (string)xElem.Element("id"),
                             name = (string)xElem.Element("name"),
                         }).ToList();
            radGridView1.DataSource = query.ToList();
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {
            var selectedRowCount = radGridView1.SelectedRows.Count;
            if (selectedRowCount > 0)
            {
                for (var i = 0; i < selectedRowCount; i++)
                {
                    var selectedRow = radGridView1.Rows.IndexOf(radGridView1.CurrentRow);   //
                    radLabel2.Text = radGridView1.Rows[selectedRow].Cells[0].Value.ToString();
                    radTextBox1.Text = radGridView1.Rows[selectedRow].Cells[1].Value.ToString();
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var method = new CaptureMethod();
            method.CreateCategoryXElement(radTextBox1.Text.Trim());
            DataBind();
            MessageBox.Show(@"添加成功", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var id = radLabel2.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show(@"出现错误", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var method = new CaptureMethod();
                method.ModifyCategoryXmlNode(id, radTextBox1.Text.Trim());
                DataBind();
                MessageBox.Show(@"添加成功", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
