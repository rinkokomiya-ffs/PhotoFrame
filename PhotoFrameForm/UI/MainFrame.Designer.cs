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
            this.label1 = new System.Windows.Forms.Label();
            this.ShowAlbumPhotoFileListButton = new System.Windows.Forms.Button();
            this.ChangeAlbumComboBox = new System.Windows.Forms.ComboBox();
            this.PhotoFileListView = new System.Windows.Forms.ListView();
            this.PhotoFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlbumName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsFavolite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SlideShowButton = new System.Windows.Forms.Button();
            this.ChangeAlbumButton = new System.Windows.Forms.Button();
            this.RegisterFavButton = new System.Windows.Forms.Button();
            this.TargetAlbumNameTextBox = new System.Windows.Forms.TextBox();
            this.CreateAlbumButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ShowDirectoryFileListButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchDirectorytextBox = new System.Windows.Forms.TextBox();
            this.SearchAlbumComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "新規アルバム名";
            // 
            // ShowAlbumPhotoFileListButton
            // 
            this.ShowAlbumPhotoFileListButton.Location = new System.Drawing.Point(333, 36);
            this.ShowAlbumPhotoFileListButton.Name = "ShowAlbumPhotoFileListButton";
            this.ShowAlbumPhotoFileListButton.Size = new System.Drawing.Size(75, 23);
            this.ShowAlbumPhotoFileListButton.TabIndex = 2;
            this.ShowAlbumPhotoFileListButton.Text = "リスト表示";
            this.ShowAlbumPhotoFileListButton.UseVisualStyleBackColor = true;
            this.ShowAlbumPhotoFileListButton.Click += new System.EventHandler(this.ShowPhotoFileListButton_Click);
            // 
            // ChangeAlbumComboBox
            // 
            this.ChangeAlbumComboBox.FormattingEnabled = true;
            this.ChangeAlbumComboBox.Location = new System.Drawing.Point(103, 3);
            this.ChangeAlbumComboBox.Name = "ChangeAlbumComboBox";
            this.ChangeAlbumComboBox.Size = new System.Drawing.Size(219, 20);
            this.ChangeAlbumComboBox.TabIndex = 3;
            // 
            // PhotoFileListView
            // 
            this.PhotoFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PhotoFilePath,
            this.AlbumName,
            this.IsFavolite});
            this.PhotoFileListView.Location = new System.Drawing.Point(25, 249);
            this.PhotoFileListView.Name = "PhotoFileListView";
            this.PhotoFileListView.Size = new System.Drawing.Size(498, 312);
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
            this.SlideShowButton.Location = new System.Drawing.Point(132, 220);
            this.SlideShowButton.Name = "SlideShowButton";
            this.SlideShowButton.Size = new System.Drawing.Size(75, 23);
            this.SlideShowButton.TabIndex = 5;
            this.SlideShowButton.Text = "スライドショー";
            this.SlideShowButton.UseVisualStyleBackColor = true;
            // 
            // ChangeAlbumButton
            // 
            this.ChangeAlbumButton.Location = new System.Drawing.Point(338, 21);
            this.ChangeAlbumButton.Name = "ChangeAlbumButton";
            this.ChangeAlbumButton.Size = new System.Drawing.Size(79, 23);
            this.ChangeAlbumButton.TabIndex = 6;
            this.ChangeAlbumButton.Text = "アルバム変更";
            this.ChangeAlbumButton.UseVisualStyleBackColor = true;
            this.ChangeAlbumButton.Click += new System.EventHandler(this.ChangeAlbumButton_Click);
            // 
            // RegisterFavButton
            // 
            this.RegisterFavButton.Location = new System.Drawing.Point(103, 41);
            this.RegisterFavButton.Name = "RegisterFavButton";
            this.RegisterFavButton.Size = new System.Drawing.Size(88, 23);
            this.RegisterFavButton.TabIndex = 7;
            this.RegisterFavButton.Text = "追加/削除";
            this.RegisterFavButton.UseVisualStyleBackColor = true;
            // 
            // TargetAlbumNameTextBox
            // 
            this.TargetAlbumNameTextBox.Location = new System.Drawing.Point(105, 69);
            this.TargetAlbumNameTextBox.Name = "TargetAlbumNameTextBox";
            this.TargetAlbumNameTextBox.Size = new System.Drawing.Size(222, 19);
            this.TargetAlbumNameTextBox.TabIndex = 8;
            // 
            // CreateAlbumButton
            // 
            this.CreateAlbumButton.Location = new System.Drawing.Point(333, 69);
            this.CreateAlbumButton.Name = "CreateAlbumButton";
            this.CreateAlbumButton.Size = new System.Drawing.Size(79, 23);
            this.CreateAlbumButton.TabIndex = 9;
            this.CreateAlbumButton.Text = "アルバム作成";
            this.CreateAlbumButton.UseVisualStyleBackColor = true;
            this.CreateAlbumButton.Click += new System.EventHandler(this.CreateAlbumButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(30, 220);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(96, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "処理キャンセル";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "アルバム検索";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "変更先アルバム名";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.67485F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.32516F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChangeAlbumComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.RegisterFavButton, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(326, 76);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "お気に入り";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.ChangeAlbumButton);
            this.groupBox1.Location = new System.Drawing.Point(25, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選択した画像に対する処理";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.04478F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.95522F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.Controls.Add(this.SearchAlbumComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShowDirectoryFileListButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CreateAlbumButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ShowAlbumPhotoFileListButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TargetAlbumNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SearchDirectorytextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 100);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // ShowDirectoryFileListButton
            // 
            this.ShowDirectoryFileListButton.Location = new System.Drawing.Point(333, 3);
            this.ShowDirectoryFileListButton.Name = "ShowDirectoryFileListButton";
            this.ShowDirectoryFileListButton.Size = new System.Drawing.Size(75, 23);
            this.ShowDirectoryFileListButton.TabIndex = 15;
            this.ShowDirectoryFileListButton.Text = "リスト表示";
            this.ShowDirectoryFileListButton.UseVisualStyleBackColor = true;
            this.ShowDirectoryFileListButton.Click += new System.EventHandler(this.ShowDirectoryFileListButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "ディレクトリ検索";
            // 
            // SearchDirectorytextBox
            // 
            this.SearchDirectorytextBox.Location = new System.Drawing.Point(105, 3);
            this.SearchDirectorytextBox.Name = "SearchDirectorytextBox";
            this.SearchDirectorytextBox.Size = new System.Drawing.Size(222, 19);
            this.SearchDirectorytextBox.TabIndex = 14;
            this.SearchDirectorytextBox.Text = "だみーだよ";
            // 
            // SearchAlbumComboBox
            // 
            this.SearchAlbumComboBox.FormattingEnabled = true;
            this.SearchAlbumComboBox.Location = new System.Drawing.Point(105, 36);
            this.SearchAlbumComboBox.Name = "SearchAlbumComboBox";
            this.SearchAlbumComboBox.Size = new System.Drawing.Size(219, 20);
            this.SearchAlbumComboBox.TabIndex = 16;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.SlideShowButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PhotoFileListView);
            this.Name = "MainFrame";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowAlbumPhotoFileListButton;
        private System.Windows.Forms.ComboBox ChangeAlbumComboBox;
        private System.Windows.Forms.ListView PhotoFileListView;
        private System.Windows.Forms.Button SlideShowButton;
        private System.Windows.Forms.Button ChangeAlbumButton;
        private System.Windows.Forms.Button RegisterFavButton;
        private System.Windows.Forms.ColumnHeader PhotoFilePath;
        private System.Windows.Forms.ColumnHeader AlbumName;
        private System.Windows.Forms.ColumnHeader IsFavolite;
        private System.Windows.Forms.TextBox TargetAlbumNameTextBox;
        private System.Windows.Forms.Button CreateAlbumButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ShowDirectoryFileListButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SearchDirectorytextBox;
        private System.Windows.Forms.ComboBox SearchAlbumComboBox;
    }
}

