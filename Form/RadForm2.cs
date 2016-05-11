using System;
using System.Linq;
using System.Xml.Linq;
using Telerik.WinControls.UI;

namespace Form
{
    public partial class RadForm2 : RadForm
    {
        private static string FilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "app.xml";

            }
        }
        private readonly string _txtVal;//上一窗体带过来的值
        public RadForm2()
        {
            InitializeComponent();
        }
        public RadForm2(string txt) //重载构造函数
        {
            this._txtVal = txt;//获取传过来的值
            InitializeComponent();
            ShowPara();

        }
        public void ShowPara()
        {
            labelId.Text = _txtVal;
            var root = XElement.Load(FilePath);
            var query = (from xElem in root.Elements("DAQ")
                         where
                             xElem.Element("Id").Value.Trim() == _txtVal.Trim()
                         select xElem).Elements("CaptureData").Elements("expression").Select(
                x => new
                {
                    Id = x.Attribute("Id").Value,
                    Name = x.Attribute("Name").Value,
                    ChinaName = x.Attribute("ChinaName").Value,
                    Exp = x.Value,
                });
            radGridView1.DataSource = query.ToList();
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            var id = labelId.Text.Trim();
            var expid = ExpId.Text.Trim();
            var method = new CaptureMethod();
            if (string.IsNullOrEmpty(expid))
            {
                var entity = new ExpEntity
                {
                    Id = Guid.NewGuid(),
                    ExpText = ExpText.Text,
                    Name = EnName.Text,
                    ChinaName = ChName.Text
                };
                method.CreateExpNode(entity, id);
            }
            else
            {
                var entity = new ExpEntity
                {
                    Id = Guid.Parse(expid),
                    ExpText = ExpText.Text,
                    Name = EnName.Text,
                    ChinaName = ChName.Text
                };
                method.ModifyExpNode(entity, id);
            }


        }

        private void radGridView1_Click(object sender, EventArgs e)
        {
            var selectedRowCount = radGridView1.SelectedRows.Count;
            if (selectedRowCount > 0)
            {
                for (var i = 0; i < selectedRowCount; i++)
                {
                    var selectedRow = radGridView1.Rows.IndexOf(radGridView1.CurrentRow);   //
                    EnName.Text = radGridView1.Rows[selectedRow].Cells[2].Value.ToString();
                    ChName.Text = radGridView1.Rows[selectedRow].Cells[3].Value.ToString();
                    ExpText.Text = radGridView1.Rows[selectedRow].Cells[4].Value.ToString().Trim();
                }
            }
        }
    }
}
