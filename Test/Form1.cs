using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FilterControls;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class DataClass
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string Notes { get; set; }
        }

        class Presenter : APresenter<DataClass>
        {
            public override IEnumerable<IColumnDefinition<DataClass>> ColumnDefinitions
            {
                get
                {
                    return new IColumnDefinition<DataClass>[]
                    {
                        new ColumnDefinition<DataClass, string, string>()
                        {
                            ColumnName = "Given Name",
                            Columnizer = (dc) => dc.FirstName,
                            Formatter = (s) => s,
                            Editable = false
                        },
                        new ColumnDefinition<DataClass, string, string>()
                        {
                            ColumnName = "Family Name",
                            Columnizer = (dc) => dc.LastName,
                            Formatter = (s) => "(" + s + ")",
                            Editable = false
                        },
                        new ColumnDefinition<DataClass, string, string>()
                        {
                            ColumnName = "Sex",
                            Columnizer = (dc) => dc.Gender,
                            Formatter = (s) => s.Equals("Male") ? "M" : "F",
                            Editable = false
                        },
                        new ColumnDefinition<DataClass, string, string>()
                        {
                            ColumnName = "Notes",
                            Columnizer = (dc) => dc.Notes,
                            Formatter = (s) => s,
                            Editable = true,
                            Updater = (dc, s) =>
                            {
                                dc.Notes = s;
                                MessageBox.Show(dc.Notes);
                            }
                        }
                    };
                }
            }

            public override void RefreshItems()
            {
                emitItemUpdate(new object[]
                {
                    new DataClass()
                    {
                        FirstName = "George",
                        LastName = "Lucas",
                        Gender = "Male",
                        Notes = "Hmm..."
                    },
                    new DataClass()
                    {
                        FirstName = "Steven",
                        LastName = "Speilberg",
                        Gender = "Male",
                        Notes = "WOW!"
                    },
                    new DataClass()
                    {
                        FirstName = "Kate",
                        LastName = "Winslet",
                        Gender = "Female",
                        Notes = "Yeah"
                    },
                });
            }
        }

        private Presenter _presenter = new Presenter();

        private void Form1_Load(object sender, EventArgs e)
        {
            filterableListView1.Presenter = _presenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in _presenter.SelectedItems)
            {
                MessageBox.Show(item.FirstName);
            }
        }
    }
}
