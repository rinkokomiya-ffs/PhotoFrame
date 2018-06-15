using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PhotoFrame.Persistence.Csv
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }
        private IAlbumRepository albumRepository;

        public PhotoRepository(string databaseName, IAlbumRepository albumRepository)
        {
            this.CsvFilePath = $"{databaseName}_Photo.csv"; // $"{...}" : 文字列展開
            this.albumRepository = albumRepository;
            //if (!System.IO.File.Exists(this.CsvFilePath))
            //{
            //    FileStream fs = System.IO.File.Create(CsvFilePath);
            //}
        }

        public bool Exists(Photo entity)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            // TODO: イベント・デリゲート講座で実装予定
            // 全アルバムリストにqueryを入れる
            if (FindAll() != null)
                return query(FindAll());
            else
                return null;
        }

        //Func<string, string> capitalizeFunc = baseStr => baseStr?.ToUpper();
        //static int Add2(int a, int b) => a + b;

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        {
            // TODO: イベント・デリゲート講座で実装予定
            // 全アルバムリストにqueryを入れる
            if (FindAll() != null)
                return query(FindAll());
            else
                return null;
        }

        /// <summary>
        /// 全フォトリストを格納
        /// </summary>
        /// <returns></returns>
        private IQueryable<Photo> FindAll()
        {
            // CSVファイルを読み込む
            List<Photo> photos = new List<Photo>();
            if (System.IO.File.Exists(this.CsvFilePath))
            {
                using (StreamReader sr = new StreamReader(CsvFilePath))
                {
                    // 行末まで読み込む
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] photoData = line.Split(',');
                        Domain.Model.File file = new Domain.Model.File(photoData[1]);
                        Album album = albumRepository.FindBy(photoData[3]);
                        photos.Add(new Photo(photoData[0], file, Convert.ToBoolean(photoData[2]), photoData[3], album));
                    }
                }
                // IQueryable型に変換してReturn   
                return photos.AsQueryable();
            }
            else
                return null;
        }

        public Photo FindBy(string id)
        {
            // TODO: ファイルIO講座で実装
            // 保存したcsvからidを検索
            using (StreamReader sr = new StreamReader(CsvFilePath, Encoding.UTF8))
            {
                while (sr.Peek() > -1)
                {
                    string line = sr.ReadLine();
                    string[] photoData = line.Split(',');
                    if (photoData[0] == id)
                    {
                        // あったよ
                        Domain.Model.File file = new Domain.Model.File(photoData[1]);
                        //Domain.Model.Album album = new Domain.Model.Album(photoData[3]);

                        Domain.Model.Album album = albumRepository.FindBy(photoData[3]);

                        return new Photo(photoData[0], file, Convert.ToBoolean(photoData[2]), photoData[3], album);
                    }


                }

                // なかったよ
                return null;
                //throw new NotImplementedException();
            }
        }

        public Photo Store(Photo entity)
        {
            // TODO: ファイルIO講座で実装
            // entityをcsvファイルに1行出力して保存する
            List<string> temp_list = new List<string>();

            // ファイルあった場合
            if (System.IO.File.Exists(this.CsvFilePath))
            {
                // 新規フォトとIDが合致しないフォトデータだけtemp_listに避難
                using (StreamReader sr = new StreamReader(this.CsvFilePath))
                {
                    while (sr.EndOfStream == false)
                    {
                        string line = sr.ReadLine();
                        string[] value = line.Split(',');

                        if (value[1] != entity.File.FilePath)
                        {
                            temp_list.Add(line);
                        }
                    }
                }

                // csvファイルを空っぽにする
                System.IO.File.Delete(this.CsvFilePath);
                //System.IO.File.Create(this.CsvFilePath);


                using (StreamWriter sw = new StreamWriter(this.CsvFilePath))
                {
                    // temp_list内のフォトデータを書き込み
                    foreach (string data in temp_list)
                    {
                        sw.WriteLine(data);
                    }

                }


            }
            // ファイルなかった場合
            else
            {
                //System.IO.File.Create(this.CsvFilePath);
            }

            // 新規フォトデータを書き込み
            using (StreamWriter sw = new StreamWriter(this.CsvFilePath, true))
            {
                List<string> photoData = new List<string>();
                photoData.Add(entity.Id);
                photoData.Add(entity.File.FilePath);
                photoData.Add(entity.IsFavorite.ToString());
                photoData.Add(entity.AlbumId);

                for (int i = 0; i < photoData.Count - 1; i++)
                {
                    sw.Write(photoData[i]);
                    sw.Write(",");
                }
                sw.WriteLine(photoData[photoData.Count - 1]);

            }

            return entity;
            //throw new NotImplementedException();
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public List<Photo> FindFav(Photo entity)
        {
            // TODO: ファイルIO講座で実装
            // 保存したcsvからidを検索
            using (StreamReader sr = new StreamReader(CsvFilePath))
            {
                List<Photo> favlist = new List<Photo>();
                while (sr.Peek() > -1)
                {
                    string line = sr.ReadLine();
                    string[] photoData = line.Split(',');
                    if (photoData[2] == "true")
                    {
                        // あったよ
                        Domain.Model.File file = new Domain.Model.File(photoData[1]);
                        Domain.Model.Album album = albumRepository.FindBy(photoData[3]);

                        //favlistに該当する写真の情報を出力する
                        favlist.Add(entity);

                        return favlist;
                    }


                }
                return null;
            }
        }

        public Photo FindFT(string filePath)
        {
            // TODO: ファイルIO講座で実装
            // 保存したcsvからidを検索
            //string ext = Path.GetExtension(filePath).ToLower();
            //return photoFileExtensions.Any(x => x == ext);
            using (StreamReader sr = new StreamReader(CsvFilePath, Encoding.UTF8))
            {
                while (sr.Peek() > -1)
                {
                    string line = sr.ReadLine();
                    string[] photoData = line.Split(',');
                    if (photoData[1] == filePath)
                    {
                        // あったよ
                        Domain.Model.File file = new Domain.Model.File(photoData[1]);
                        //Domain.Model.Album album = new Domain.Model.Album(photoData[3]);
                        Domain.Model.Album album = albumRepository.FindBy(photoData[3]);

                        return new Photo(photoData[0], file, Convert.ToBoolean(photoData[2]), photoData[3], album);
                    }


                }
                return null;
            }
        }
    }
}
