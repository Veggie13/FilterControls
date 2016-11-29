namespace FilterControls
{
    partial class FilterableListView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._dgvList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._btnClearFilter = new System.Windows.Forms.Button();
            this._txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgvList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvList
            // 
            this._dgvList.AllowUserToAddRows = false;
            this._dgvList.AllowUserToDeleteRows = false;
            this._dgvList.AllowUserToOrderColumns = true;
            this._dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this._dgvList, 2);
            this._dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvList.Location = new System.Drawing.Point(3, 3);
            this._dgvList.Name = "_dgvList";
            this._dgvList.RowHeadersVisible = false;
            this._dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvList.Size = new System.Drawing.Size(211, 232);
            this._dgvList.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._dgvList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._btnClearFilter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._txtFilter, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(217, 267);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _btnClearFilter
            // 
            this._btnClearFilter.AutoSize = true;
            this._btnClearFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._btnClearFilter.Location = new System.Drawing.Point(190, 241);
            this._btnClearFilter.Name = "_btnClearFilter";
            this._btnClearFilter.Size = new System.Drawing.Size(24, 23);
            this._btnClearFilter.TabIndex = 1;
            this._btnClearFilter.Text = "X";
            this._btnClearFilter.UseVisualStyleBackColor = true;
            // 
            // _txtFilter
            // 
            this._txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFilter.Location = new System.Drawing.Point(3, 242);
            this._txtFilter.Name = "_txtFilter";
            this._txtFilter.Size = new System.Drawing.Size(181, 20);
            this._txtFilter.TabIndex = 2;
            // 
            // FilterableListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FilterableListView";
            this.Size = new System.Drawing.Size(217, 267);
            ((System.ComponentModel.ISupportInitialize)(this._dgvList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgvList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _btnClearFilter;
        private System.Windows.Forms.TextBox _txtFilter;
    }
}
