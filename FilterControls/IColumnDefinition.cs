using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterControls
{
    public interface IColumnDefinition
    {
        string ColumnName { get; }
        Type ColumnObjectType { get; }
        bool Editable { get; }

        object GetColumnObject(object rowObj);
        object FormatObject(object valObj);
        void UpdateRowObject(object rowObj, object updateObj);
    }

    public interface IColumnDefinition<ItemT> : IColumnDefinition
    {
        bool IsEditableForRow(ItemT rowObj);
        object GetColumnObject(ItemT rowObj);
        void UpdateRowObject(ItemT rowObj, object updateObj);
    }

    public interface IColumnDefinition<ItemT, ColumnT, FormatT> : IColumnDefinition<ItemT>
    {
        ColumnT GetColumnObject(ItemT rowObj);
        FormatT FormatObject(ColumnT valObj);
        void UpdateRowObject(ItemT rowObj, ColumnT updateObj);
    }

    public class ColumnDefinition<ItemT, ColumnT, FormatT> : IColumnDefinition<ItemT, ColumnT, FormatT>
    {
        public bool IsEditableForRow(ItemT rowObj)
        {
            return Editable;
        }

        public ColumnT GetColumnObject(ItemT rowObj)
        {
            return Columnizer(rowObj);
        }

        public FormatT FormatObject(ColumnT valObj)
        {
            return Formatter(valObj);
        }

        public void UpdateRowObject(ItemT rowObj, ColumnT updateObj)
        {
            Updater(rowObj, updateObj);
        }

        public string ColumnName
        {
            get;
            set;
        }

        public Type ColumnObjectType
        {
            get { return typeof(ColumnT); }
        }

        public bool Editable
        {
            get;
            set;
        }

        public Func<ColumnT, FormatT> Formatter
        {
            get;
            set;
        }

        public Func<ItemT, ColumnT> Columnizer
        {
            get;
            set;
        }

        public Action<ItemT, ColumnT> Updater
        {
            get;
            set;
        }


        public void UpdateRowObject(object rowObj, object updateObj)
        {
            UpdateRowObject((ItemT)rowObj, (ColumnT)updateObj);
        }

        public object GetColumnObject(object rowObj)
        {
            return GetColumnObject((ItemT)rowObj);
        }

        public object FormatObject(object valObj)
        {
            return FormatObject((ColumnT)valObj);
        }


        object IColumnDefinition<ItemT>.GetColumnObject(ItemT rowObj)
        {
            return GetColumnObject(rowObj);
        }

        public void UpdateRowObject(ItemT rowObj, object updateObj)
        {
            UpdateRowObject(rowObj, (ColumnT)updateObj);
        }
    }
}
