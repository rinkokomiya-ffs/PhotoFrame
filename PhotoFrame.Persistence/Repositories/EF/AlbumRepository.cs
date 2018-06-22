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
        public bool Exists(Album entity)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            using (Domain.Model.EF.PhotoRepositoryEntities entities = new Domain.Model.EF.PhotoRepositoryEntities())
            {
                // IDで検索
                var targetData = entities.M_ALBUM.Find(id);

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
                // 存在していた場合は何もせずにReturnする
                if (FindBy(entity.Id) != null)
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

                    // 変更内容反映
                    entities.SaveChanges();
                }
            }

            return entity;
        }
    }
}
