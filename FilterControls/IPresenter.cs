using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterControls
{
    public delegate void PresenterItemUpdate(IEnumerable<object> items);
    public delegate void PresenterItemRequest(ref IEnumerable<object> items);

    public interface IPresenter
    {
        event PresenterItemUpdate ItemUpdate;
        event PresenterItemRequest SelectedItemsRequested;

        IEnumerable<IColumnDefinition> ColumnDefinitions { get; }

        void RefreshItems();
    }

    public interface IPresenter<ItemT> : IPresenter
    {
        IEnumerable<ItemT> SelectedItems { get; }

        IEnumerable<IColumnDefinition<ItemT>> ColumnDefinitions { get; }
    }

    public abstract class APresenter<ItemT> : IPresenter<ItemT>
    {
        public event PresenterItemUpdate ItemUpdate = (l) => { };
        public event PresenterItemRequest SelectedItemsRequested = (ref IEnumerable<object> l) => { };

        public IEnumerable<ItemT> SelectedItems
        {
            get
            {
                IEnumerable<object> items = new object[0];
                SelectedItemsRequested(ref items);
                return items.Cast<ItemT>();
            }
        }

        public abstract IEnumerable<IColumnDefinition<ItemT>> ColumnDefinitions
        {
            get;
        }

        IEnumerable<IColumnDefinition> IPresenter.ColumnDefinitions
        {
            get { return ColumnDefinitions; }
        }

        public abstract void RefreshItems();

        protected void emitItemUpdate(IEnumerable<object> items)
        {
            ItemUpdate(items);
        }
    }

    public interface IPresenterItem
    {
        bool Visible { get; }
        object Item { get; }
    }

    public sealed class PresenterItem<ItemT> : IPresenterItem
    {
        public bool Visible
        {
            get;
            set;
        }

        public ItemT Item
        {
            get;
            set;
        }

        object IPresenterItem.Item
        {
            get { return Item; }
        }
    }
}
