namespace HardkorowyKodsu.Client.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            databaseTreeView = new TreeView();
            columnsDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)columnsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // databaseTreeView
            // 
            databaseTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            databaseTreeView.Location = new Point(12, 12);
            databaseTreeView.Name = "databaseTreeView";
            databaseTreeView.Size = new Size(219, 426);
            databaseTreeView.TabIndex = 0;
            databaseTreeView.AfterSelect += databaseTreeView_AfterSelect;
            // 
            // columnsDataGrid
            // 
            columnsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            columnsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            columnsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            columnsDataGrid.Location = new Point(237, 12);
            columnsDataGrid.Name = "columnsDataGrid";
            columnsDataGrid.ReadOnly = true;
            columnsDataGrid.Size = new Size(551, 426);
            columnsDataGrid.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(columnsDataGrid);
            Controls.Add(databaseTreeView);
            Name = "MainForm";
            Text = "HardkorowyKodsu";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)columnsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView databaseTreeView;
        private DataGridView columnsDataGrid;
    }
}