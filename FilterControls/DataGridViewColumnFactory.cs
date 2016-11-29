using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilterControls
{
    public class DataGridViewColumnFactory
    {
        private Dictionary<Type, ColumnProvider> _providers = new Dictionary<Type, ColumnProvider>();

        public delegate DataGridViewColumn ColumnProvider();

        public DataGridViewColumn CreateColumn(IColumnDefinition defn)
        {
            DataGridViewColumn col;
            if (_providers.ContainsKey(defn.ColumnObjectType))
            {
                col = _providers[defn.ColumnObjectType]();
            }
            else
            {
                col = new DataGridViewTextBoxColumn();
            }

            col.HeaderText = defn.ColumnName;
            col.ReadOnly = !defn.Editable;
            col.Tag = defn;
            return col;
        }

        public void RegisterColumnType(Type columnType, ColumnProvider provider)
        {
            _providers[columnType] = provider;
        }
    }
}
