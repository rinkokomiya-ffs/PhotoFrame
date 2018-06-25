using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public bool Exists(Album entity)
        => ExistsBy(entity.Id);

        public bool ExistsBy(string id)
        => FindBy(id) != null;


        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            // TODO: DBプログラミング講座で実装
            if (FindAll() != null)
                return query(FindAll());
            else
                return null;
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            // TODO: DBプログラミング講座で実装
            if (FindAll() != null)
                return query(FindAll());
            else
                return null;
        }

        /// <summary>
        /// 全アルバムリストの生成
        /// </summary>
        /// <returns></returns>
        private IQueryable<Album> FindAll()
        {
            List<Album> albums = new List<Album>();

            using (Domain.Model.EF.PhotoRepositoryEntities entities = new Domain.Model.EF.PhotoRepositoryEntities())
            {
                var entries = entities.M_ALBUM.Select(e => e);
                foreach(var p in entries)
                {
                    albums.Add(new Album(p.Id.ToString(), p.Name, p.Description));
                }
            }

            return albums.AsQueryable();
        }

        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            using (Domain.Model.EF.PhotoRepositoryEntities entities = new Domain.Model.EF.PhotoRepositoryEntities())
            {
                // IDで検索
                Guid guid;
                var targetData = entities.M_ALBUM.Find(Guid.TryParse(id, out guid) ? (Guid?)guid : null);

                // 検索結果がある場合はAlbumを生成する
                if (targetData != null)
                {
                    return new Album(targetData.Id.ToString(), targetData.Name, targetData.Description);
                }
                // 検索結果がない場合はnullを返す
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// データベースに保存する
        /// </summary>
        /// <param name="entity">保存するアルバムデータ（Album）</param>
        /// <returns>保存するアルバムデータ（Album）</returns>
        public Album Store(Album entity)
        {
            // TODO: DBプログラミング講座で実装
            using (Domain.Model.EF.PhotoRepositoryEntities entities = new Domain.Model.EF.PhotoRepositoryEntities())
            {
                // IDで検索して存在しない場合は新規保存してからReturnする
                if (FindBy(entity.Id) == null)
                {
                    // データ定義
                    var productData = new Domain.Model.EF.M_ALBUM()
                    {
                        Id = Guid.Parse(entity.Id),
                        Name = entity.Name,
                        Description = entity.Description,
                    };

                    // データ代入
                    entities.M_ALBUM.Add(productData);

                    
                }
                // 存在していた場合は更新してからReturnする
                else
                {
                    // 検索対象のデータを取得
                    var targetData = entities.M_ALBUM.Find(Guid.Parse(entity.Id));

                    // 更新する
                    targetData.Name = entity.Name;
                    targetData.Description = entity.Description ?? null;
                }

                // 変更内容反映
                entities.SaveChanges();
            }

            return entity;
        }
    }
}
