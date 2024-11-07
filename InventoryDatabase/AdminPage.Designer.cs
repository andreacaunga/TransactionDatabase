namespace InventoryDatabase
{
    partial class AdminPage
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
            label3 = new Label();
            dgvTransactions = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 29);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 14;
            label3.Text = "Transaction History";
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToOrderColumns = true;
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(23, 61);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(715, 339);
            dgvTransactions.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(687, 413);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 16;
            label1.Text = "Sign out";
            label1.Click += label1_Click;
            // 
            // AdminPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 442);
            Controls.Add(label1);
            Controls.Add(dgvTransactions);
            Controls.Add(label3);
            Name = "AdminPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminPage";
            Load += AdminPage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private DataGridView dgvTransactions;
        private Label label1;
    }
}