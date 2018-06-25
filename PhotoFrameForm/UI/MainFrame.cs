using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Application;
using PhotoFrame.Domain.Model;

// 以下は必ず消す
using PhotoFrame.Persistence;


namespace PhotoFrameForm
{
    public partial class MainFrame : Form
    {
        //static RepositoryFactory repos = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
        static RepositoryFactory repos = new RepositoryFactory(PhotoFrame.Persistence.Type.EF);


        // アプリケーションのインスタンス化
        PhotoFrameApplication application = new PhotoFrameApplication(repos.AlbumRepository, repos.PhotoRepository);

        //private List<Album> allAlbumList;
        //private List<Photo> viewPhotoList;

        // 選択されたアルバムとかファイル名もフィールドでいいかもしれないよ
        // あるいはクラス生成

        private readonly IPhotoFileService service;

        // キャンセル用
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


        public MainFrame()
        {
            InitializeComponent();
            // 後で消す
            service = new ServiceFactory().PhotoFileService;
        }

        private void MainFrame_Load(object sender, EventArgs e)

        //private async void MainFrame_Load(object sender, EventArgs e)
        // ★async void はイベントのみで利用する
        {
            //await AlbumListLoad();
            AlbumListLoad();

        }

        /// <summary>
        /// AlbumのCsvデータ取得（全アルバムリスト）
        /// 非同期にする必要性はあるのか？（DBにはアクセスするので必要かも）
        /// </summary>
        //private async Task AlbumListLoad()
        private void AlbumListLoad()
        {
            // リストを全部空にする
            SearchAlbumComboBox.Items.Clear();
            ChangeAlbumComboBox.Items.Clear();

            //var allAlbumList = await application.FindAlbum("allAlbum");
            var allAlbumList = application.FindAlbums("allAlbum");


            foreach (var p in allAlbumList)
            {
                SearchAlbumComboBox.Items.Add(p.Name);
                ChangeAlbumComboBox.Items.Add(p.Name);
            }

            // 一つでもアルバムが存在したら初期状態で選択する
            if(allAlbumList.Count() != 0)
            {
                SearchAlbumComboBox.SelectedIndex = 0;
                ChangeAlbumComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 新規アルバム作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateAlbumButton_Click(object sender, EventArgs e)
        {
            // テキストボックスからアルバム名を取得
            string createAlbumName = TargetAlbumNameTextBox.Text;

            // 新規アルバム生成および保存
            // 非同期処理
            await application.CreateAlbum(createAlbumName);

            // awaitの結果を待って再読み込みする（はず）
            AlbumListLoad();
        }

        /// <summary>
        /// ディレクトリ名で画像ファイルを検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ShowDirectoryFileListButton_Click(object sender, EventArgs e)
        {
            // ダイアログを開く
            // FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                //上部に表示する説明テキストを指定する
                Description = "フォルダを指定してください。",

                //最初に選択するフォルダを指定する
                SelectedPath = @"C:\",
            };

            //ダイアログで決定ボタンを選択される
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                // フォルダパスから画像ファイルを取得
                var list = await application.FindDirectory(fbd.SelectedPath);

                // 何も含まれていない場合
                if (list.ToList().Count == 0)
                {
                    MessageBox.Show("指定したフォルダに画像ファイルはありません");
                }
                else
                {
                    // リストボックスに表示
                    ShowPhotoFileList(list);
                }
            }
        }

        /// <summary>
        /// 表示するPhotoリストを、リストボックスに追加
        /// </summary>
        /// <param name="photos"></param>
        private void ShowPhotoFileList(IEnumerable<Photo> photos)
        {
            foreach (var p in photos)
            {
                string albumName = p.Album?.Name ?? "";
                string favorite;

                if (p.IsFavorite == true)
                {
                    favorite = "★";
                }
                else
                {
                    favorite = "";
                }

                string[] row = { p.File.FilePath, albumName, favorite };
                PhotoFileListView.Items.Add(new ListViewItem(row));
            }

            // 一番上のファイルをデフォルトで選択する
            // うまく動かない
            //PhotoFileListView.Items[1].Selected = true;
            //PhotoFileListView.Items[1].Focused = true;
        }


        /// <summary>
        /// アルバム名で画像ファイルを検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPhotoFileListButton_Click(object sender, EventArgs e)
        {
            // もしリストに既にコンテンツがあったら消去する
            if (PhotoFileListView.Items.Count != 0)
            {
                PhotoFileListView.Items.Clear();
            }

            // 選択されたアルバム名を取得
            string targetAlbumName = ChangeAlbumComboBox.Items[ChangeAlbumComboBox.SelectedIndex].ToString();

            // テキストボックスからアルバム名を取得
            //string targetAlbumName = TargetAlbumNameTextBox.Text;

            // アルバム名から生成されたアルバム情報をcsvファイルから取得する
            //var targetAlbum = application.FindAlbums(targetAlbumName);
            //Func<IQueryable<Album>, Album> func = FindAlbumName;
            //Album targetAlbum = repos.AlbumRepository.Find(func);

            // 登録されているフォトからアルバムに所属するものを取得
            var targetPhotos = application.FindPhotos(targetAlbumName);
            //var photoFileList = service.FindAllPhotoFilesFromDirectory(targetAlbumName);
            //foreach (var p in photoFileList)
            //{
            //    var photo = Photo.CreateFromFile(p);
            //    photo.IsAssignedTo(targetAlbum);
            //    repos.PhotoRepository.Store(photo);
            //}

            // csvに書きこまれたPhotoファイルリストを確認する
            // 要修正ここから
            //Func<IQueryable<Photo>, IQueryable<Photo>> func2 = FindPhotosAlbumName;
            //viewPhotoList = repos.PhotoRepository.Find(func2).ToList();
            // ここまで

            // 所属フォトがない場合
            if (targetPhotos.ToList().Count == 0)
            {
                MessageBox.Show(targetAlbumName + "にフォトは登録されていません");
            }

            else
            {
                // リストボックスに表示
                ShowPhotoFileList(targetPhotos);
            }
        }


        //private Album FindAlbumName(IQueryable<Album> arg)
        //{
        //    string targetAlbumName = TargetAlbumNameTextBox.Text;
        //    if (arg == null)
        //        return null;
        //    else
        //    {
        //        foreach(var p in arg)
        //        {
        //            if(p.Name == targetAlbumName)
        //            {
        //                return p;
        //            }
        //        }
        //    }
        //    return null;
        //}

        //private IQueryable<Photo> FindPhotosAlbumName(IQueryable<Photo> arg)
        //{
        //    if (arg == null)
        //        return null;

        //    string targetAlbumName = TargetAlbumNameTextBox.Text;

        //    // 検索対象ファイルリスト
        //    List<Photo> photoFiles = new List<Photo>();

        //    // 検索する
        //    foreach (var p in arg)
        //    {
        //        if (p.Album.Name == targetAlbumName)
        //        {
        //            photoFiles.Add(new Photo(p.Id, p.File, p.IsFavorite, p.AlbumId, p.Album));
        //        }
        //    }
        //    // 検索結果を返す
        //    return (photoFiles.Count != 0) ? photoFiles.AsQueryable() : null;


        //}

        /// <summary>
        /// 選択されたファイルの所属アルバムを変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeAlbumButton_Click(object sender, EventArgs e)
        {
            // 選択されたファイル名を取得
            string targetPhotoFile = PhotoFileListView.SelectedItems[0].SubItems[0].Text;

            // 選択されたアルバム名を取得
            string targetAlbumName = ChangeAlbumComboBox.Items[ChangeAlbumComboBox.SelectedIndex].ToString();

            // 変更後のフォトを取得する
            var photo = application.ChangeAlbum(targetPhotoFile, targetAlbumName);

            // リストをアップデートする
            //int index = int.Parse(PhotoFileListView.SelectedItems[0].Index.ToString());
            PhotoFileListView.SelectedItems[0].SubItems[1].Text = targetAlbumName;
            //UpdatePhotoFileList(PhotoFileListView.SelectedItems);
            //Func<IQueryable<Photo>, Photo> func = FindPhotoName;
            //Photo targetPhoto = repos.PhotoRepository.Find(func);

            //// アルバム名から変更先のAlbumを取得する
            //Func<IQueryable<Album>, Album> func2 = FindAlbumName;
            //Album targetAlbum = repos.AlbumRepository.Find(func2);

            //// 変更する
            //targetPhoto.IsAssignedTo(targetAlbum);
            //repos.PhotoRepository.Store(targetPhoto);

            //updatelistrow(selectedphoto)
        }

        /// <summary>
        /// 情報を修正した際のリストのアップデート
        /// </summary>
        /// <param name="photo"></param>
        //private void UpdatePhotoFileList(ListView.SelectedListViewItemCollection selectedItems)
        //{
            
        //}
       
        //private Photo FindPhotoName(IQueryable<Photo> arg)
        //{
        //    string targetPhotoFile = PhotoFileListView.SelectedItems.ToString();
        //    if (arg == null)
        //        return null;
        //    else
        //    {
        //        foreach (var p in arg)
        //        {
        //            if (p.File.FilePath == targetPhotoFile)
        //            {
        //                return p;
        //            }
        //        }
        //    }
        //    return null;
        //}

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        

        // csvから現状のアルバムを取得
        // アルバム生成でフォルダを作るのは手動でもOK
        // アルバム移動でフォルダへの移動は手動でもOK
        // searchで中のファイルを取得（アルバムフォルダの中身を取得）
        // change album で 所属アルバムを書きかえる
        // リストボックスはあくまでもcsvファイルの中身
        // サムネイルは無視する
        // スライドショー：所属アルバムとパスを表示
    }
}
