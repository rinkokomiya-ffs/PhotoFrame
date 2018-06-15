namespace PhotoFrameForm
{
    partial class MainFrame
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csvファイル選択ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowPhotoFileListButton = new System.Windows.Forms.Button();
            this.ChoiceAlbumComboBox = new System.Windows.Forms.ComboBox();
            this.PhotoFileListView = new System.Windows.Forms.ListView();
            this.PhotoFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlbumName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsFavolite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SlideShowButton = new System.Windows.Forms.Button();
            this.ChangeAlbumButton = new System.Windows.Forms.Button();
            this.RegisterFavButton = new System.Windows.Forms.Button();
            this.TargetAlbumName = new System.Windows.Forms.TextBox();
            this.CreateAlbumButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csvファイル選択ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // csvファイル選択ToolStripMenuItem
            // 
            this.csvファイル選択ToolStripMenuItem.Name = "csvファイル選択ToolStripMenuItem";
            this.csvファイル選択ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.csvファイル選択ToolStripMenuItem.Text = "csvファイル選択";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "アルバム名";
            // 
            // ShowPhotoFileListButton
            // 
            this.ShowPhotoFileListButton.Location = new System.Drawing.Point(426, 45);
            this.ShowPhotoFileListButton.Name = "ShowPhotoFileListButton";
            this.ShowPhotoFileListButton.Size = new System.Drawing.Size(75, 23);
            this.ShowPhotoFileListButton.TabIndex = 2;
            this.ShowPhotoFileListButton.Text = "リスト表示";
            this.ShowPhotoFileListButton.UseVisualStyleBackColor = true;
            this.ShowPhotoFileListButton.Click += new System.EventHandler(this.ShowPhotoFileListButton_Click);
            // 
            // ChoiceAlbumComboBox
            // 
            this.ChoiceAlbumComboBox.FormattingEnabled = true;
            this.ChoiceAlbumComboBox.Location = new System.Drawing.Point(123, 343);
            this.ChoiceAlbumComboBox.Name = "ChoiceAlbumComboBox";
            this.ChoiceAlbumComboBox.Size = new System.Drawing.Size(214, 20);
            this.ChoiceAlbumComboBox.TabIndex = 3;
            // 
            // PhotoFileListView
            // 
            this.PhotoFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PhotoFilePath,
            this.AlbumName,
            this.IsFavolite});
            this.PhotoFileListView.Location = new System.Drawing.Point(27, 74);
            this.PhotoFileListView.Name = "PhotoFileListView";
            this.PhotoFileListView.Size = new System.Drawing.Size(498, 256);
            this.PhotoFileListView.TabIndex = 4;
            this.PhotoFileListView.UseCompatibleStateImageBehavior = false;
            this.PhotoFileListView.View = System.Windows.Forms.View.Details;
            // 
            // PhotoFilePath
            // 
            this.PhotoFilePath.Text = "画像ファイルパス";
            this.PhotoFilePath.Width = 344;
            // 
            // AlbumName
            // 
            this.AlbumName.Text = "アルバム名";
            this.AlbumName.Width = 67;
            // 
            // IsFavolite
            // 
            this.IsFavolite.Text = "お気に入り";
            this.IsFavolite.Width = 63;
            // 
            // SlideShowButton
            // 
            this.SlideShowButton.Location = new System.Drawing.Point(27, 343);
            this.SlideShowButton.Name = "SlideShowButton";
            this.SlideShowButton.Size = new System.Drawing.Size(75, 23);
            this.SlideShowButton.TabIndex = 5;
            this.SlideShowButton.Text = "スライドショー";
            this.SlideShowButton.UseVisualStyleBackColor = true;
            // 
            // ChangeAlbumButton
            // 
            this.ChangeAlbumButton.Location = new System.Drawing.Point(343, 343);
            this.ChangeAlbumButton.Name = "ChangeAlbumButton";
            this.ChangeAlbumButton.Size = new System.Drawing.Size(88, 23);
            this.ChangeAlbumButton.TabIndex = 6;
            this.ChangeAlbumButton.Text = "アルバム変更";
            this.ChangeAlbumButton.UseVisualStyleBackColor = true;
            this.ChangeAlbumButton.Click += new System.EventHandler(this.ChangeAlbumButton_Click);
            // 
            // RegisterFavButton
            // 
            this.RegisterFavButton.Location = new System.Drawing.Point(437, 343);
            this.RegisterFavButton.Name = "RegisterFavButton";
            this.RegisterFavButton.Size = new System.Drawing.Size(88, 23);
            this.RegisterFavButton.TabIndex = 7;
            this.RegisterFavButton.Text = "お気に入り追加";
            this.RegisterFavButton.UseVisualStyleBackColor = true;
            // 
            // TargetAlbumName
            // 
            this.TargetAlbumName.Location = new System.Drawing.Point(104, 47);
            this.TargetAlbumName.Name = "TargetAlbumName";
            this.TargetAlbumName.Size = new System.Drawing.Size(231, 19);
            this.TargetAlbumName.TabIndex = 8;
            // 
            // CreateAlbumButton
            // 
            this.CreateAlbumButton.Location = new System.Drawing.Point(341, 45);
            this.CreateAlbumButton.Name = "CreateAlbumButton";
            this.CreateAlbumButton.Size = new System.Drawing.Size(79, 23);
            this.CreateAlbumButton.TabIndex = 9;
            this.CreateAlbumButton.Text = "アルバム作成";
            this.CreateAlbumButton.UseVisualStyleBackColor = true;
            this.CreateAlbumButton.Click += new System.EventHandler(this.CreateAlbumButton_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 379);
            this.Controls.Add(this.CreateAlbumButton);
            this.Controls.Add(this.TargetAlbumName);
            this.Controls.Add(this.RegisterFavButton);
            this.Controls.Add(this.ChangeAlbumButton);
            this.Controls.Add(this.SlideShowButton);
            this.Controls.Add(this.PhotoFileListView);
            this.Controls.Add(this.ChoiceAlbumComboBox);
            this.Controls.Add(this.ShowPhotoFileListButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowPhotoFileListButton;
        private System.Windows.Forms.ComboBox ChoiceAlbumComboBox;
        private System.Windows.Forms.ToolStripMenuItem csvファイル選択ToolStripMenuItem;
        private System.Windows.Forms.ListView PhotoFileListView;
        private System.Windows.Forms.Button SlideShowButton;
        private System.Windows.Forms.Button ChangeAlbumButton;
        private System.Windows.Forms.Button RegisterFavButton;
        private System.Windows.Forms.ColumnHeader PhotoFilePath;
        private System.Windows.Forms.ColumnHeader AlbumName;
        private System.Windows.Forms.ColumnHeader IsFavolite;
        private System.Windows.Forms.TextBox TargetAlbumName;
        private System.Windows.Forms.Button CreateAlbumButton;
    }
}

