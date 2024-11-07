namespace InventoryDatabase
{
    partial class UserPage
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
            btnCheckout = new Button();
            label3 = new Label();
            txtTotal = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCheckout
            // 
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Location = new Point(239, 221);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(94, 29);
            btnCheckout.TabIndex = 0;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(183, 119);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 14;
            label3.Text = "Total Amount: ";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Swis721 Cn BT", 9F);
            txtTotal.Location = new Point(291, 114);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(98, 25);
            txtTotal.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(499, 335);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 17;
            label1.Text = "Sign out";
            label1.Click += label1_Click;
            // 
            // UserPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 364);
            Controls.Add(label1);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(btnCheckout);
            Name = "UserPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCheckout;
        private Label label3;
        private TextBox txtTotal;
        private Label label1;
    }
}