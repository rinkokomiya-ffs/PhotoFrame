using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;


namespace PhotoFrame.Domain.UseCase
{
    public class ChangeAlbum
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoRepository photoRepository;

        public ChangeAlbum(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            this.albumRepository = albumRepository;
            this.photoRepository = photoRepository;
        }

        public Photo Execute(string photoTitle, string albumTitle)
        {
            // フォトが存在するか検索する
            Func<IQueryable<Photo>, Photo> func = allPhotos =>
            {
                foreach (var p in allPhotos)
                {
                    if (p.File.FilePath == photoTitle)
                    {
                        return p;
                    }
                };
                return null;
            };

            // アルバム名からアルバムを取得する
            Func<IQueryable<Album>, Album> func2 = allAlbums =>
            {
                foreach (var p in allAlbums)
                {
                    if (p.Name == albumTitle)
                    {
                        return p;
                    }
                };
                return null;
            };

            // フォトが存在するか検索する
            var targetPhoto = photoRepository.Find(func) ?? Photo.CreateFromFile(new File(photoTitle));

            // 所属アルバムを変更する
            targetPhoto.IsAssignedTo(albumRepository.Find(func2));

            // 更新済みのフォトを保存する
            photoRepository.Store(targetPhoto);

            return targetPhoto;
        }
    }
}
