using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.Test
{
    [TestClass]
    public class CsvRepositoryTest
    {
        private IPhotoRepository photoRepository;
        private IAlbumRepository albumRepository;

        [TestInitialize]
        public void SetUp()
        {
            //テストに使用する特定のデータファイルをコピー・変更・作成する
            // 各テストごとにデータベースファイルを削除
            // TODO: 実装によってCSVファイル名が違うと思うので適宜修正を
            if (System.IO.File.Exists("PhotoFrameDatabaseForTest_Photo.csv"))
            {
                System.IO.File.Delete("PhotoFrameDatabaseForTest_Photo.csv");
            }
            if (System.IO.File.Exists("PhotoFrameDatabaseForTest_Album.csv"))
            {
                System.IO.File.Delete("PhotoFrameDatabaseForTest_Album.csv");
            }

            // リポジトリ生成
            var repos = new RepositoryFactory(Type.Csv);
            photoRepository = repos.PhotoRepository;
            albumRepository = repos.AlbumRepository;
        }

        [TestMethod]
        public void 写真を追加できること()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"));

            photoRepository.Store(photo);

            var result = photoRepository.FindBy(photo.Id);
            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void 写真を更新できること()
        {
            var photo = Photo.CreateFromFile(new File("dummy.bmp"));
            photoRepository.Store(photo);

            photo.MarkAsFavorite();
            photoRepository.Store(photo);

            var result = photoRepository.FindBy(photo.Id);
            Assert.AreEqual(true, result.IsFavorite);
        }

        [TestMethod]
        public void 既存の写真をアルバムに追加できること()
        {
            var album = Album.Create("Album1");
            albumRepository.Store(album);
            var photo = Photo.CreateFromFile(new File("dummy.bmp"));
            photoRepository.Store(photo);

            photo.IsAssignedTo(album);
            photoRepository.Store(photo);

            var result = photoRepository.FindBy(photo.Id);
            Assert.AreEqual(album.Id, result.Album.Id);
        }

        [TestMethod]
        public void Findメソッドが利用できること()
        {
            for(int i = 0; i < 10; i++)
            {
                var album = Album.Create("Album"+i);
                albumRepository.Store(album);
            }

            Func<IQueryable<Album>, Album> func = arg => {
                foreach (var p in arg)
                {
                    if (p.Name == "Album1")
                    {
                        return new Album(p.Id, p.Name, p.Description);
                    }
                }
                // 見つからない場合
                return null;
            };

            var result = albumRepository.Find(func);

            Assert.AreEqual("Album1", result.Name);
        }

        [TestMethod]
        public void IQueryableで返ってくるFindメソッドを利用できること()
        {
            for (int i = 0; i < 10; i++)
            {
                var album = Album.Create("Album" + i);
                albumRepository.Store(album);
            }

            Func<IQueryable<Album>, IQueryable<Album>> func = FindByAlbumsName;
            var resultList = albumRepository.Find(func).ToList();

            // 検索ワードが含まれているかどうか確認する
            Assert.AreEqual(true, resultList.Exists(p => p.Name.Contains("Album")));
        }

        /// <summary>
        /// アルバム名を検索する（1つのみ返す）
        /// </summary>
        /// <param name="arg">全アルバムのリスト</param>
        /// <returns></returns>
        //private Album FindByAlbumName(IQueryable<Album> arg)
        //{
        //    foreach (var p in arg)
        //    {
        //        if (p.Name == "Album1")
        //        {
        //            return new Album(p.Id, p.Name, p.Description);
        //        }
        //    }
        //    // 見つからない場合
        //    return null;
        //}

        /// <summary>
        /// アルバム名を検索する（複数返す）
        /// </summary>
        /// <param name="arg">全アルバムのリスト</param>
        /// <returns></returns>
        private IQueryable<Album> FindByAlbumsName(IQueryable<Album> arg)
        {
            // 検索ワード
            string search = "Album";

            // 検索結果を格納するリストを格納
            List<Album> albums = new List<Album>();

            // 検索する
            foreach (var p in arg)
            {
                // 部分一致のとき
                if (p.Name.Contains(search))
                {
                    albums.Add(new Album(p.Id, p.Name, p.Description));
                }
            }
            // 検索結果を返す
            return (albums.Count != 0) ? albums.AsQueryable() : null;
            //if (albums.Count != 0)
            //    return albums.AsQueryable();
            //else
            //    return null;
        }

        // 10万件突っ込むなどの意地悪なテストがあっても面白いと思います。
    }
}
