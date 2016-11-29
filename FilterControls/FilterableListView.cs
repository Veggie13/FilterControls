using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilterControls
{
    public partial class FilterableListView : UserControl
    {
        public FilterableListView()
        {
            InitializeComponent();

            ColumnFactory = new DataGridViewColumnFactory();

            _dgvList.CellEndEdit += new DataGridViewCellEventHandler(_dgvList_CellEndEdit);
            _dgvList.CellFormatting += new DataGridViewCellFormattingEventHandler(_dgvList_CellFormatting);
        }

        #region Properties
        #region Presenter
        private IPresenter _presenter;
        public IPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == value)
                    return;

                if (_presenter != null)
                {
                    reset();
                }

                _presenter = value;

                if (_presenter != null)
                {
                    setup();
                }
            }
        }
        #endregion

        #region ColumnFactory
        public DataGridViewColumnFactory ColumnFactory { get; private set; }
        #endregion
        #endregion

        #region Event Handlers
        private void _dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IColumnDefinition defn = (IColumnDefinition)_dgvList.Columns[e.ColumnIndex].Tag;
            object rowObj = _dgvList.Rows[e.RowIndex].Tag;

            if (_dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                defn.UpdateRowObject(rowObj, _dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                _dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
            }
        }

        private void _dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            IColumnDefinition defn = (IColumnDefinition)_dgvList.Columns[e.ColumnIndex].Tag;
            object rowObj = _dgvList.Rows[e.RowIndex].Tag;
            object colObj = defn.GetColumnObject(rowObj);
            e.Value = defn.FormatObject(colObj);
            e.FormattingApplied = true;
        }

        private void Presenter_ItemUpdate(IEnumerable<object> items)
        {
            _dgvList.Rows.Clear();

            foreach (object item in items)
            {
                _dgvList.Rows.Add(new DataGridViewRow()
                {
                    Tag = item
                });
            }
        }

        private void Presenter_SelectedItemsRequested(ref IEnumerable<object> items)
        {
            items = _dgvList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag);
        }
        #endregion

        #region Private Helpers
        private void reset()
        {
            _dgvList.Rows.Clear();
            _dgvList.Columns.Clear();
            Presenter.ItemUpdate -= Presenter_ItemUpdate;
        }

        private void setup()
        {
            Presenter.ItemUpdate += new PresenterItemUpdate(Presenter_ItemUpdate);
            Presenter.SelectedItemsRequested += new PresenterItemRequest(Presenter_SelectedItemsRequested);

            foreach (var defn in Presenter.ColumnDefinitions)
            {
                var col = ColumnFactory.CreateColumn(defn);
                _dgvList.Columns.Add(col);
            }

            Presenter.RefreshItems();
        }
        #endregion
    }
}
