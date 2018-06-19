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
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }

        public AlbumRepository(string databaseName)
        {
            this.CsvFilePath = $"{databaseName}_Album.csv"; // $"{...}" : 文字列展開
        }

        public bool Exists(Album entity)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            // TODO: イベント・デリゲート講座で実装予定
            // 全アルバムリストにqueryを入れる
            if (FindAll() != null)
                return query(FindAll());
            else
                return null;
        }

        /// <summary>
        /// 検索条件（クエリ）を受け取って、オブジェクトを検索する
        /// 条件に従って取得したAlbumを返す
        /// 引数、戻り値はIRepositoryインターフェースを参照
        /// IQueryableはIEnumerableを継承
        /// </summary>
        /// <param name="query">検索クエリ（デリゲート）</param>
        /// <returns>検索結果</returns>
        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            // TODO: イベント・デリゲート講座で実装予定
            // Func<IQueryable<Album>, Album> は、
            // 引数：IQueryable<Album>、アルバム型のリストみたいなもの
            // 戻り値：Album
            // のメソッドであるquery（メソッドqueryそのものがFindメソッドの引数）

            // 引数としてもってくるメソッドが何か？は分からなくても処理できるようにする
            // 戻り値がAlbumだから

            // 全アルバムリストにqueryを入れる
            if (FindAll() != null)
                return query(FindAll());
            else
                return null;
        }

        /// <summary>
        /// 全アルバムリストを格納
        /// </summary>
        /// <returns></returns>
        public IQueryable<Album> FindAll()
        {
            // CSVファイルを読み込む
            List<Album> albums = new List<Album>();
            if (System.IO.File.Exists(this.CsvFilePath))
            {
                using (StreamReader sr = new StreamReader(CsvFilePath))
                {
                    // 行末まで読み込む
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] albumData = line.Split(',');
                        albums.Add(new Album(albumData[0], albumData[1], albumData[2]));
                    }
                }
                // IQueryable型に変換してReturn   
                return albums.AsQueryable();
            }
            else
                return null;
        }

        public Album FindBy(string id)
        {
            // TODO: ファイルIO講座で実装
            // 保存したcsvからidを検索

            // csvファイルがあった場合
            if(System.IO.File.Exists(this.CsvFilePath))
            {
                using (StreamReader sr = new StreamReader(CsvFilePath))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] albumData = line.Split(',');
                        if (albumData[0] == id)
                        {
                            // あったよ
                            return new Album(albumData[0], albumData[1], albumData[2]);
                        }
                    }
                }
            

                // なかったよ
                return null;
            }
            // csvファイルがなかった場合
            else
            {
                return null;
            }

            // throw new NotImplementedException();
        }

        public Album Store(Album entity)
        {
            // TODO: ファイルIO講座で実装
            // entityをcsvファイルに1行出力して保存する
            

            // writeする前に、csvをreadして、if文を書く
            // 同じIDのアルバムのデータがあった場合は、更新をする
            // 更新の際は、もう一度csvデータを作り直す（リストとかで）（更新対象データ抜き）
            // 最後尾に更新データを追加する
            // もし更新が無かった場合は、以下のように最後尾に新しく追加する

            List<string> temp_list = new List<string>();

            // ファイルあった場合
            if (System.IO.File.Exists(this.CsvFilePath))
            {
                // 新規アルバムとIDが合致しないアルバムデータだけtemp_listに避難
                using (StreamReader sr = new StreamReader(this.CsvFilePath))
                {
                    while(sr.EndOfStream == false)
                    {
                        string line = sr.ReadLine();
                        string[] value = line.Split(',');

                        if(value[0] != entity.Id)
                        {
                            temp_list.Add(line);
                        }
                    }
                }

                // csvファイルを空っぽにする
                System.IO.File.Delete(this.CsvFilePath);
                
                using (StreamWriter sw = new StreamWriter(this.CsvFilePath))
                {
                    // temp_list内のアルバムデータを書き込み
                    foreach (string data in temp_list)
                    {
                        sw.WriteLine(data);
                    }

                }


            }
            

            using (StreamWriter sw = new StreamWriter(this.CsvFilePath, true))
            {
                List<string> albumData = new List<string>();
                albumData.Add(entity.Id);
                albumData.Add(entity.Name);
                albumData.Add(entity.Description);

                // 新規アルバムデータ書き込み
                for (int i = 0; i < albumData.Count - 1; i++)
                {
                    sw.Write(albumData[i]);
                    sw.Write(",");
                }
                sw.WriteLine(albumData[albumData.Count - 1]);
            }

            // ディレクトリ生成
            if (!Directory.Exists(Path.GetFullPath(entity.Name)))
            {
                Directory.CreateDirectory(Path.GetFullPath(entity.Name));
            }

            return entity;
        }
    }
}
