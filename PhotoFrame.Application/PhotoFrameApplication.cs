using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Application
{
    /// <summary>
    /// PhotoFrameのUIの指示にしたがってドメインのユースケースを起動する
    /// </summary>
    // TODO: 仮実装
    public class PhotoFrameApplication
    {
        // 新規アルバム作成
        private readonly CreateAlbum createAlbum;

        // フォルダから画像ファイル検索
        private readonly FindDirectory findDirectory;

        // アルバムの検索
        private readonly FindAlbums findAlbums;


        public PhotoFrameApplication(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            this.createAlbum = new CreateAlbum(albumRepository);
            this.findDirectory = new FindDirectory(albumRepository, photoRepository);
            this.findAlbums = new FindAlbums(albumRepository);
            //FindPhoto findPhoto = new FindPhoto(repo.PhotoRepository);
        }

        public Task CreateAlbum(string albumTitle)
        {
            return createAlbum.Execute(albumTitle); 
        }

        //public IEnumerable<Photo> FindDirectory(string directory)
        public Task<IEnumerable<Photo>> FindDirectory(string directory)
        {
            return findDirectory.Execute(directory);
            ///return findDirectory.Execute(directory);
        }

        public IEnumerable<Album> FindAlbums(string albumTitle)
        //public Task<IEnumerable<Album>> FindAlbum(string albumTitle)
        {
            return findAlbums.Execute(albumTitle);
            ///return findAlbum.Execute(albumTitle); 
        }

        
    }
}
