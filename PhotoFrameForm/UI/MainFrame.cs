using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Persistence;
using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;

namespace PhotoFrameForm
{
    public partial class MainFrame : Form
    {
        private IPhotoFileService service;
        static RepositoryFactory repo = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);

        CreateAlbum createAlbum = new CreateAlbum(repo.AlbumRepository);
        FindAlbum findAlbum = new FindAlbum(repo.AlbumRepository);
        FindPhoto findPhoto = new FindPhoto(repo.PhotoRepository);

        private List<Album> albumList;
        private List<Photo> viewPhotoList;

        // 選択されたアルバムとかファイル名もフィールドでいいかもしれないよ
        // あるいはクラス生成

        public MainFrame()
        {
            InitializeComponent();

            // セットアップ
            service = new ServiceFactory().PhotoFileService;

            // AlbumのCsvデータ取得（全アルバムリスト）
            // 要修正ここから
            //Func<IQueryable<Album>, IQueryable<Album>> func = arg => (arg != null) ? arg : null;
            Func<IQueryable<Album>, IQueryable<Album>> func = arg => (arg ?? null);
            albumList = repo.AlbumRepository.Find(func).ToList();
            // ここまで

            foreach (var p in albumList)
            {
                ChoiceAlbumComboBox.Items.Add(p.Name);
            }

            ChoiceAlbumComboBox.SelectedIndex = 0;
            //var findPhoto.Execute(FindAlbumName);

        }

        /// <summary>
        /// 全アルバムリストを取得
        /// </summary>
        /// <param name="arg">全アルバムリスト</param>
        /// <returns>全アルバムリスト</returns>
        //private IQueryable<Album> FindAllAlbum(IQueryable<Album> arg)
        //{
        //    if(arg == null)
        //        return null;
        //    else
        //        return arg;
        //}
        

        private void CreateAlbumButton_Click(object sender, EventArgs e)
        {
            // テキストボックスからアルバム名を取得
            string createAlbumName = TargetAlbumName.Text;

            // 新規アルバム生成および保存
            createAlbum.Execute(createAlbumName);
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// アルバム名で画像ファイルを検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPhotoFileListButton_Click(object sender, EventArgs e)
        {
            // もしリストに既にコンテンツがあったら消去する
            if(PhotoFileListView.Items.Count != 0)
            {
                PhotoFileListView.Items.Clear();
                viewPhotoList.Clear();
            }
                
            // 選択されたアルバム名を取得
            //int index = ChoiceAlbumComboBox.SelectedIndex;
            //string targetAlbum = ChoiceAlbumComboBox.Items[index].ToString();

            // テキストボックスからアルバム名を取得
            string targetAlbumName = TargetAlbumName.Text;

            // アルバム名から生成されたアルバム情報をcsvファイルから取得する
            Func<IQueryable<Album>, Album> func = FindAlbumName;
            Album targetAlbum = repo.AlbumRepository.Find(func);

            // 選択されたアルバムがあるかどうか確認
            // 要実装

            // 画像ファイルを取得してcsvファイルを生成する
            // 生成するときにアルバムを登録しておく
            var photoFileList = service.FindAllPhotoFilesFromDirectory(targetAlbumName);
            foreach(var p in photoFileList)
            {
                var photo = Photo.CreateFromFile(p);
                photo.IsAssignedTo(targetAlbum);
                repo.PhotoRepository.Store(photo);
            }

            // csvに書きこまれたPhotoファイルリストを確認する
            // 要修正ここから
            Func<IQueryable<Photo>, IQueryable<Photo>> func2 = FindPhotosAlbumName;
            viewPhotoList = repo.PhotoRepository.Find(func2).ToList();
            // ここまで

            if(viewPhotoList.ToList().Count == 0)
            {
                MessageBox.Show(TargetAlbumName.Text + "に画像ファイルはありません");
            }

            else
            {
                // リストボックスに表示
                foreach (var p in viewPhotoList)
                {
                    string[] row = { p.File.FilePath, p.Album.Name, p.IsFavorite.ToString() };
                    PhotoFileListView.Items.Add(new ListViewItem(row));
                }

                // 一番上のファイルをデフォルトで選択する
                PhotoFileListView.Items[0].Selected = true;
            }
        }

        private Album FindAlbumName(IQueryable<Album> arg)
        {
            string targetAlbumName = TargetAlbumName.Text;
            if (arg == null)
                return null;
            else
            {
                foreach(var p in arg)
                {
                    if(p.Name == targetAlbumName)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        private IQueryable<Photo> FindPhotosAlbumName(IQueryable<Photo> arg)
        {
            if (arg == null)
                return null;

            string targetAlbumName = TargetAlbumName.Text;

            // 検索対象ファイルリスト
            List<Photo> photoFiles = new List<Photo>();

            // 検索する
            foreach (var p in arg)
            {
                if (p.Album.Name == targetAlbumName)
                {
                    photoFiles.Add(new Photo(p.Id, p.File, p.IsFavorite, p.AlbumId, p.Album));
                }
            }
            // 検索結果を返す
            return (photoFiles.Count != 0) ? photoFiles.AsQueryable() : null;


        }

        private void ChangeAlbumButton_Click(object sender, EventArgs e)
        {
            // 選択されたファイルの所属アルバムを変える
            // 選択されたファイル名を取得
            string targetPhotoFile = PhotoFileListView.SelectedItems.ToString();

            // 選択されたアルバム名を取得
            int index = ChoiceAlbumComboBox.SelectedIndex;
            string targetAlbumName = ChoiceAlbumComboBox.Items[index].ToString();

            // ファイル名からPhotoを取得する
            Func<IQueryable<Photo>, Photo> func = FindPhotoName;
            Photo targetPhoto = repo.PhotoRepository.Find(func);

            // アルバム名から変更先のAlbumを取得する
            Func<IQueryable<Album>, Album> func2 = FindAlbumName;
            Album targetAlbum = repo.AlbumRepository.Find(func2);

            // 変更する
            targetPhoto.IsAssignedTo(targetAlbum);
            repo.PhotoRepository.Store(targetPhoto);

            //updatelistrow(selectedphoto)
        }

        private Photo FindPhotoName(IQueryable<Photo> arg)
        {
            string targetPhotoFile = PhotoFileListView.SelectedItems.ToString();
            if (arg == null)
                return null;
            else
            {
                foreach (var p in arg)
                {
                    if (p.File.FilePath == targetPhotoFile)
                    {
                        return p;
                    }
                }
            }
            return null;
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
