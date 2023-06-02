using AppAuto.Files;
using InstargramCreator.Repositories;
using Serilog;

namespace InstargramCreator
{
    public partial class frmData : Form
    {
        private readonly IAccountRepository _accountRepository;
        private const int WS_SYSMENU = 0x80000;
        List<Guid> listId = new List<Guid>();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }
        public frmData(IAccountRepository accountRepository)
        {
            InitializeComponent();
            _accountRepository = accountRepository;
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Load_Account();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                Log.Error("dataGridView1_CellContentClick");
                Serilog.Log.Error(ex.ToString());
            }
        }
        private void frmData_Load(object sender, EventArgs e)
        {
            Load_Account();
        }
        private void Load_Account()
        {
            try
            {
                var list = _accountRepository.GetAll();
                dataGridView1.DataSource = list;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                Log.Error("Load_Account");
                Log.Error(ex, ex.Message);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Export export = new Export(_accountRepository);
            export.ExportTxt();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _accountRepository.DeleteRange(listId);
            Load_Account();
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            _accountRepository.DeleteAll();
            Load_Account();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Guid id;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    if (row.Cells[0].Value != null)
                    {
                        var checkValue = row.Cells[1].ToolTipText;
                        if (checkValue == "True")
                        {
                            id = Guid.Parse(row.Cells[0].Value.ToString());
                            listId.Add(id);
                        }
                        else
                        {
                            id = Guid.Parse(row.Cells[0].Value.ToString());
                            var delete = listId.Find(x => x == id);
                            if (delete != null)
                            {
                                listId.Remove(delete);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("dataGridView1_CellValueChanged");
                Log.Error(ex, ex.Message);
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }
    }
}
