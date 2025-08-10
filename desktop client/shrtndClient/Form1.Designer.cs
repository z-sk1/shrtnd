namespace shrtndClient
{
    partial class shtrndForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shtrndForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnShorten = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.LinkLabel();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.SlateGray;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Location = new System.Drawing.Point(335, 96);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "shrtnd";
            // 
            // txtInput
            // 
            this.txtInput.ForeColor = System.Drawing.Color.DimGray;
            this.txtInput.Location = new System.Drawing.Point(280, 151);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(250, 43);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Enter your URL here...";
            this.txtInput.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // panelData
            // 
            this.panelData.BackColor = System.Drawing.SystemColors.Window;
            this.panelData.Controls.Add(this.lblData);
            this.panelData.Controls.Add(this.btnCopy);
            this.panelData.Location = new System.Drawing.Point(262, 200);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(309, 179);
            this.panelData.TabIndex = 2;
            // 
            // btnCopy
            // 
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCopy.Location = new System.Drawing.Point(110, 79);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(89, 31);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnShorten
            // 
            this.btnShorten.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShorten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShorten.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnShorten.Location = new System.Drawing.Point(548, 151);
            this.btnShorten.Name = "btnShorten";
            this.btnShorten.Size = new System.Drawing.Size(102, 39);
            this.btnShorten.TabIndex = 3;
            this.btnShorten.Text = "Shorten";
            this.btnShorten.UseVisualStyleBackColor = true;
            this.btnShorten.Click += new System.EventHandler(this.btnShorten_Click);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(9, 30);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 16);
            this.lblData.TabIndex = 1;
            this.lblData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblData_LinkClicked);
            // 
            // shtrndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShorten);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "shtrndForm";
            this.Text = "shtrnd";
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Button btnShorten;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.LinkLabel lblData;
    }
}

