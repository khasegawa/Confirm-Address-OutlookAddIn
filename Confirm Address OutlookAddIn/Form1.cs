using Outlook = Microsoft.Office.Interop.Outlook;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Confirm_Address_OutlookAddIn {
    public partial class FormConfirmAddress : Form {
        private readonly int MARGIN = 10;
        private Outlook.MailItem mail;

        public FormConfirmAddress(Outlook.MailItem mail) {
            this.mail = mail;
            InitializeComponent();
        }

        private void FormConfirmAddress_Load(object sender, EventArgs e) {
            listViewInnerAddress.Columns.Add("Inner", listViewInnerAddress.Width, HorizontalAlignment.Left);
            listViewOuterAddress.Columns.Add("Outer", listViewInnerAddress.Width, HorizontalAlignment.Left);

            RecipType[] recipTypes = new RecipType[] {
                new RecipType(Outlook.OlMailRecipientType.olTo, "To:"),
                new RecipType(Outlook.OlMailRecipientType.olCC, "CC:"),
                new RecipType(Outlook.OlMailRecipientType.olBCC, "BCC:"),
            };

            string myDomain;
            try {
                myDomain = mail.Session.CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress.Split('@')[1];
            } catch (Exception) {
                myDomain = ".";
            }
            foreach (RecipType recipType in recipTypes) {
                foreach (Outlook.Recipient recip in mail.Recipients) {
                    if ((Outlook.OlMailRecipientType)recip.Type == recipType.type) {
                        var item = new ListViewItem();
                        item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
                        string smtpAddress;
                        try {
                            smtpAddress = recip.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x39FE001E").ToString().Trim();
                        } catch (Exception) {
                            smtpAddress = "?";
                        }
                        item.Text = recipType.text + "  " +
                            (recip.Name.Trim().Equals(smtpAddress) ? smtpAddress : recip.Name.Trim() + " <" + smtpAddress + ">");
                        if (smtpAddress.EndsWith("@" + myDomain) || smtpAddress.EndsWith("." + myDomain)) {
                            listViewInnerAddress.Items.Add(item);
                        } else {
                            listViewOuterAddress.Items.Add(item);
                        }
                    }
                }
            }
            listViewInnerAddress.Left = listViewOuterAddress.Left = MARGIN;
            listViewInnerAddress.Top = MARGIN;
            buttonSend.Enabled = false;
            AlignParts();
        }

        private void FormConfirmAddress_Resize(object sender, EventArgs e) {
            AlignParts();
        }

        private void AlignParts() {
            listViewInnerAddress.Width = listViewOuterAddress.Width = ClientRectangle.Width - MARGIN * 2;
            listViewInnerAddress.Columns[0].Width = listViewInnerAddress.ClientRectangle.Width;
            listViewOuterAddress.Columns[0].Width = listViewOuterAddress.ClientRectangle.Width;

            listViewInnerAddress.Height = listViewOuterAddress.Height = (ClientRectangle.Height - buttonSend.Height - MARGIN * 2) / 2 - MARGIN;
            listViewOuterAddress.Top = listViewInnerAddress.Bottom + MARGIN;

            buttonCancel.Left = ClientRectangle.Width - buttonCancel.Width - MARGIN;
            buttonSend.Left = buttonCancel.Left - buttonSend.Width - MARGIN;

            buttonCancel.Top = buttonSend.Top = ClientRectangle.Height - buttonCancel.Height - MARGIN;
        }

        private void ListView_ItemChecked(object sender, ItemCheckedEventArgs e) {
            e.Item.Font = new Font(e.Item.Font,
                e.Item.Checked ? e.Item.Font.Style & ~FontStyle.Bold : e.Item.Font.Style | FontStyle.Bold);
            buttonSend.Enabled = IsFullChecked(listViewInnerAddress) & IsFullChecked(listViewOuterAddress);
        }
        
        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                e.Item.Checked = !e.Item.Checked;
                e.Item.Selected = false;
            }
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            ListView listView = (ListView)sender;
            bool stat = IsFullChecked(listView);
            foreach (ListViewItem item in listView.Items) {
                item.Checked = !stat;
            }
        }

        private bool IsFullChecked(ListView listView) {
            return listView.CheckedItems.Count == listView.Items.Count;
        }

        internal struct RecipType {
            internal Outlook.OlMailRecipientType type;
            internal string text;
            internal RecipType(Outlook.OlMailRecipientType type, string text) {
                this.type = type;
                this.text = text;
            }
        }
    }
}