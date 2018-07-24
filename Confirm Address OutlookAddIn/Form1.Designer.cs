namespace Confirm_Address_OutlookAddIn
{
    partial class FormConfirmAddress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listViewInnerAddress = new System.Windows.Forms.ListView();
            this.listViewOuterAddress = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSend.Location = new System.Drawing.Point(310, 319);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(410, 319);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // listViewInnerAddress
            // 
            this.listViewInnerAddress.CheckBoxes = true;
            this.listViewInnerAddress.Location = new System.Drawing.Point(12, 12);
            this.listViewInnerAddress.Name = "listViewInnerAddress";
            this.listViewInnerAddress.Size = new System.Drawing.Size(121, 97);
            this.listViewInnerAddress.TabIndex = 2;
            this.listViewInnerAddress.UseCompatibleStateImageBehavior = false;
            this.listViewInnerAddress.View = System.Windows.Forms.View.Details;
            this.listViewInnerAddress.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_ColumnClick);
            this.listViewInnerAddress.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ItemChecked);
            this.listViewInnerAddress.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            // 
            // listViewOuterAddress
            // 
            this.listViewOuterAddress.CheckBoxes = true;
            this.listViewOuterAddress.Location = new System.Drawing.Point(12, 133);
            this.listViewOuterAddress.Name = "listViewOuterAddress";
            this.listViewOuterAddress.Size = new System.Drawing.Size(121, 97);
            this.listViewOuterAddress.TabIndex = 3;
            this.listViewOuterAddress.UseCompatibleStateImageBehavior = false;
            this.listViewOuterAddress.View = System.Windows.Forms.View.Details;
            this.listViewOuterAddress.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_ColumnClick);
            this.listViewOuterAddress.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ItemChecked);
            this.listViewOuterAddress.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            // 
            // FormConfirmAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 354);
            this.ControlBox = false;
            this.Controls.Add(this.listViewOuterAddress);
            this.Controls.Add(this.listViewInnerAddress);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSend);
            this.Name = "FormConfirmAddress";
            this.Text = "Confirm Address";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormConfirmAddress_Load);
            this.Resize += new System.EventHandler(this.FormConfirmAddress_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listViewInnerAddress;
        private System.Windows.Forms.ListView listViewOuterAddress;
    }
}