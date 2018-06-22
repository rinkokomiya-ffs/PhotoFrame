using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        //private Domain.Model.EF.PhotoRepositoryEntities entities;
        private IAlbumRepository albumRepository;

        public PhotoRepository(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public bool Exists(Photo entity)
        => ExistsBy(entity.Id);


        public bool ExistsBy(string id)
        => FindBy(id) != null;


        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        /// <summary>
        /// IDで検索して保存されているデータを返す
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Photo FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            using (Domain.Model.EF.PhotoRepositoryEntities entities = new Domain.Model.EF.PhotoRepositoryEntities())
            {
                // IDで検索
                var targetData = entities.M_PHOTO.Find(Guid.Parse(id));

                // 検索結果がある場合はPhotoを生成する
                if (targetData != null)
                {
                    // Albumがある場合
                    if (targetData.AlbumId != null)
                    {
                        return new Photo(targetData.Id.ToString(), new File(targetData.FilePath), targetData.IsFavorite, targetData.AlbumId.ToString(), albumRepository.FindBy(targetData.AlbumId.ToString()));

                    }
                    // ない場合
                    else
                    {
                        return new Photo(targetData.Id.ToString(), new File(targetData.FilePath), targetData.IsFavorite);
                    }
                }
                // 検索結果がない場合はnullを返す
                else
                {
                    return null;
                }
            }
        }

        public Photo Store(Photo entity)
        {
            // TODO: DBプログラミング講座で実装
            using (Domain.Model.EF.PhotoRepositoryEntities entities = new Domain.Model.EF.PhotoRepositoryEntities())
            {
                // IDで検索して存在しない場合は新規保存してからReturnする
                if (Exists(entity) == false)
                {
                    Guid guid;
                    // データ定義
                    var productData = new Domain.Model.EF.M_PHOTO()
                    {
                        Id = Guid.Parse(entity.Id),
                        FilePath = entity.File.FilePath,
                        IsFavorite = entity.IsFavorite,
                        AlbumId = Guid.TryParse(entity.AlbumId, out guid) ? (Guid?)guid : null,
                    };

                    // データ代入
                    entities.M_PHOTO.Add(productData);
                }
                // 存在していた場合は更新してからReturnする
                else
                {
                    // 検索対象のデータを取得
                    var targetData = entities.M_PHOTO.Find(Guid.Parse(entity.Id));

                    // 更新する
                    Guid guid;
                    targetData.FilePath = entity.File.FilePath;
                    targetData.IsFavorite = entity.IsFavorite;
                    targetData.AlbumId = Guid.TryParse(entity.AlbumId, out guid) ? (Guid?)guid : null;
                }

                // 変更内容反映
                entities.SaveChanges();
            }
            return entity;
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }
    }
}
