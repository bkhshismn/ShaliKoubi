namespace ShaliKoubi
{
    partial class frmPrsnl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvMember = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grpMmbr = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.txtPrsnlFee = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.cmbPrsnlNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtWorker = new DevComponents.Editors.ComboItem();
            this.txtMmbr = new DevComponents.Editors.ComboItem();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPrsnlTel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnBack = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtPrsnlFam = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPrsnlName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblNo = new DevComponents.DotNetBar.LabelX();
            this.lblFam = new DevComponents.DotNetBar.LabelX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lblMain = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.grpMmbr.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvMember);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(847, 527);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 2;
            // 
            // dgvMember
            // 
            this.dgvMember.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMember.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMember.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMember.Location = new System.Drawing.Point(8, 326);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.Size = new System.Drawing.Size(816, 186);
            this.dgvMember.TabIndex = 0;
            this.dgvMember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellClick);
            this.dgvMember.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMember_CellFormatting);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.grpMmbr);
            this.groupPanel2.Controls.Add(this.cmbPrsnlNo);
            this.groupPanel2.Controls.Add(this.txtAddress);
            this.groupPanel2.Controls.Add(this.txtPrsnlTel);
            this.groupPanel2.Controls.Add(this.groupPanel3);
            this.groupPanel2.Controls.Add(this.txtPrsnlFam);
            this.groupPanel2.Controls.Add(this.txtPrsnlName);
            this.groupPanel2.Controls.Add(this.lblNo);
            this.groupPanel2.Controls.Add(this.lblFam);
            this.groupPanel2.Controls.Add(this.lblName);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.lblMain);
            this.groupPanel2.Controls.Add(this.labelX12);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(9, 9);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(815, 311);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 0;
            // 
            // grpMmbr
            // 
            this.grpMmbr.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpMmbr.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpMmbr.Controls.Add(this.txtDate);
            this.grpMmbr.Controls.Add(this.labelX14);
            this.grpMmbr.Controls.Add(this.txtPrsnlFee);
            this.grpMmbr.Controls.Add(this.labelX13);
            this.grpMmbr.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpMmbr.Location = new System.Drawing.Point(3, 6);
            this.grpMmbr.Name = "grpMmbr";
            this.grpMmbr.Size = new System.Drawing.Size(222, 102);
            // 
            // 
            // 
            this.grpMmbr.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpMmbr.Style.BackColorGradientAngle = 90;
            this.grpMmbr.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpMmbr.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpMmbr.Style.BorderBottomWidth = 1;
            this.grpMmbr.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpMmbr.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpMmbr.Style.BorderLeftWidth = 1;
            this.grpMmbr.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpMmbr.Style.BorderRightWidth = 1;
            this.grpMmbr.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpMmbr.Style.BorderTopWidth = 1;
            this.grpMmbr.Style.CornerDiameter = 4;
            this.grpMmbr.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpMmbr.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpMmbr.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpMmbr.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpMmbr.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpMmbr.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpMmbr.TabIndex = 6;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDate.Location = new System.Drawing.Point(3, 58);
            this.txtDate.Mask = "####/##/##";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(91, 22);
            this.txtDate.TabIndex = 1;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.Location = new System.Drawing.Point(100, 58);
            this.labelX14.Name = "labelX14";
            this.labelX14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX14.Size = new System.Drawing.Size(119, 23);
            this.labelX14.TabIndex = 0;
            this.labelX14.Text = ":تاریخ شروع قرارداد";
            // 
            // txtPrsnlFee
            // 
            // 
            // 
            // 
            this.txtPrsnlFee.Border.Class = "TextBoxBorder";
            this.txtPrsnlFee.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrsnlFee.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrsnlFee.Location = new System.Drawing.Point(3, 18);
            this.txtPrsnlFee.Name = "txtPrsnlFee";
            this.txtPrsnlFee.PreventEnterBeep = true;
            this.txtPrsnlFee.Size = new System.Drawing.Size(115, 22);
            this.txtPrsnlFee.TabIndex = 0;
            this.txtPrsnlFee.Text = "0";
            this.txtPrsnlFee.TextChanged += new System.EventHandler(this.txtPrsnlFee_TextChanged);
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.Location = new System.Drawing.Point(124, 17);
            this.labelX13.Name = "labelX13";
            this.labelX13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX13.Size = new System.Drawing.Size(95, 23);
            this.labelX13.TabIndex = 0;
            this.labelX13.Text = ":حقوق دریافتی";
            // 
            // cmbPrsnlNo
            // 
            this.cmbPrsnlNo.DisplayMember = "Text";
            this.cmbPrsnlNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPrsnlNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPrsnlNo.FormattingEnabled = true;
            this.cmbPrsnlNo.ItemHeight = 17;
            this.cmbPrsnlNo.Items.AddRange(new object[] {
            this.txtWorker,
            this.txtMmbr});
            this.cmbPrsnlNo.Location = new System.Drawing.Point(244, 57);
            this.cmbPrsnlNo.Name = "cmbPrsnlNo";
            this.cmbPrsnlNo.Size = new System.Drawing.Size(172, 23);
            this.cmbPrsnlNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPrsnlNo.TabIndex = 3;
            this.cmbPrsnlNo.SelectedIndexChanged += new System.EventHandler(this.cmbPrsnlNo_SelectedIndexChanged);
            // 
            // txtWorker
            // 
            this.txtWorker.FontName = "Tahoma";
            this.txtWorker.FontSize = 9F;
            this.txtWorker.Text = "کارگر";
            // 
            // txtMmbr
            // 
            this.txtMmbr.FontName = "Tahoma";
            this.txtMmbr.FontSize = 9F;
            this.txtMmbr.Text = "کارمند";
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleName = "";
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(3, 127);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PreventEnterBeep = true;
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(800, 110);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.WatermarkText = "آدرس محل سکونت...";
            // 
            // txtPrsnlTel
            // 
            // 
            // 
            // 
            this.txtPrsnlTel.Border.Class = "TextBoxBorder";
            this.txtPrsnlTel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrsnlTel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrsnlTel.Location = new System.Drawing.Point(537, 57);
            this.txtPrsnlTel.Name = "txtPrsnlTel";
            this.txtPrsnlTel.PreventEnterBeep = true;
            this.txtPrsnlTel.Size = new System.Drawing.Size(172, 23);
            this.txtPrsnlTel.TabIndex = 2;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnDelete);
            this.groupPanel3.Controls.Add(this.btnBack);
            this.groupPanel3.Controls.Add(this.btnEdit);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(3, 243);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(803, 50);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Image = global::ShaliKoubi.Properties.Resources.iconfinder_file_delete_48762;
            this.btnDelete.Location = new System.Drawing.Point(531, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(80, 37);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Image = global::ShaliKoubi.Properties.Resources.iconfinder__30ui_2303135;
            this.btnBack.Location = new System.Drawing.Point(10, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBack.Size = new System.Drawing.Size(88, 37);
            this.btnBack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "بازگشت";
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Image = global::ShaliKoubi.Properties.Resources.iconfinder_icon_136_document_edit_314251;
            this.btnEdit.Location = new System.Drawing.Point(617, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEdit.Size = new System.Drawing.Size(88, 37);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::ShaliKoubi.Properties.Resources.iconfinder_simpline_53_2305609;
            this.btnSave.Location = new System.Drawing.Point(709, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(88, 37);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPrsnlFam
            // 
            // 
            // 
            // 
            this.txtPrsnlFam.Border.Class = "TextBoxBorder";
            this.txtPrsnlFam.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrsnlFam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrsnlFam.Location = new System.Drawing.Point(244, 29);
            this.txtPrsnlFam.Name = "txtPrsnlFam";
            this.txtPrsnlFam.PreventEnterBeep = true;
            this.txtPrsnlFam.Size = new System.Drawing.Size(172, 23);
            this.txtPrsnlFam.TabIndex = 1;
            // 
            // txtPrsnlName
            // 
            // 
            // 
            // 
            this.txtPrsnlName.Border.Class = "TextBoxBorder";
            this.txtPrsnlName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrsnlName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrsnlName.Location = new System.Drawing.Point(537, 28);
            this.txtPrsnlName.Name = "txtPrsnlName";
            this.txtPrsnlName.PreventEnterBeep = true;
            this.txtPrsnlName.Size = new System.Drawing.Size(172, 23);
            this.txtPrsnlName.TabIndex = 0;
            // 
            // lblNo
            // 
            // 
            // 
            // 
            this.lblNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNo.ForeColor = System.Drawing.Color.Red;
            this.lblNo.Location = new System.Drawing.Point(222, 57);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(21, 23);
            this.lblNo.TabIndex = 0;
            // 
            // lblFam
            // 
            // 
            // 
            // 
            this.lblFam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFam.ForeColor = System.Drawing.Color.Red;
            this.lblFam.Location = new System.Drawing.Point(222, 27);
            this.lblFam.Name = "lblFam";
            this.lblFam.Size = new System.Drawing.Size(21, 23);
            this.lblFam.TabIndex = 0;
            // 
            // lblName
            // 
            // 
            // 
            // 
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(512, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(21, 23);
            this.lblName.TabIndex = 0;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Red;
            this.labelX6.Location = new System.Drawing.Point(510, 28);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(21, 23);
            this.labelX6.TabIndex = 0;
            // 
            // lblMain
            // 
            // 
            // 
            // 
            this.lblMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMain.ForeColor = System.Drawing.Color.Red;
            this.lblMain.Location = new System.Drawing.Point(293, 6);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(401, 23);
            this.lblMain.TabIndex = 0;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.Location = new System.Drawing.Point(422, 57);
            this.labelX12.Name = "labelX12";
            this.labelX12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX12.Size = new System.Drawing.Size(80, 23);
            this.labelX12.TabIndex = 0;
            this.labelX12.Text = ":نوع همکاری";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(715, 57);
            this.labelX3.Name = "labelX3";
            this.labelX3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX3.Size = new System.Drawing.Size(97, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = ":شماره همراه";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(422, 57);
            this.labelX7.Name = "labelX7";
            this.labelX7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX7.Size = new System.Drawing.Size(80, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = ":نوع مشتری";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(422, 27);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX2.Size = new System.Drawing.Size(80, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = ":نام خانوادگی";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(715, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX1.Size = new System.Drawing.Size(47, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = ":نام";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Red;
            this.labelX5.Location = new System.Drawing.Point(3, 29);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(19, 23);
            this.labelX5.TabIndex = 0;
            // 
            // frmPrsnl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 527);
            this.Controls.Add(this.groupPanel1);
            this.Name = "frmPrsnl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ثبت پرسنل";
            this.Load += new System.EventHandler(this.frmPrsnl_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.grpMmbr.ResumeLayout(false);
            this.grpMmbr.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMember;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrsnlFee;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPrsnlNo;
        private DevComponents.Editors.ComboItem txtWorker;
        private DevComponents.Editors.ComboItem txtMmbr;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrsnlTel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnBack;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrsnlFam;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrsnlName;
        private DevComponents.DotNetBar.LabelX lblNo;
        private DevComponents.DotNetBar.LabelX lblFam;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblMain;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.GroupPanel grpMmbr;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.MaskedTextBox txtDate;
    }
}