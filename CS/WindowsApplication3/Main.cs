using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e) {
           gridControl1.DataSource = GetData();
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name");
            dt.Columns.Add("Date", typeof(DateTime));

            for (int i = 0; i < 30; i++)
                dt.Rows.Add(i, string.Format("Name {0}", i), DateTime.Now.AddDays(i));

            return dt;
        }

        private void OnShowFilterPopupDate(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupDateEventArgs e)
        {
            FunctionOperator op = new FunctionOperator("IsDayOff", new OperandProperty(e.Column.FieldName));
            e.List.Add(new DevExpress.XtraEditors.FilterDateElement("IsDayOff", "", op));
        }
    }
}
