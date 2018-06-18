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

        // アルバムの検索
        private readonly FindAlbums findAlbums;


        public PhotoFrameApplication(IAlbumRepository albumRepository)
        {
            this.createAlbum = new CreateAlbum(albumRepository);
            this.findAlbums = new FindAlbums(albumRepository);
            //FindPhoto findPhoto = new FindPhoto(repo.PhotoRepository);
        }

        public void CreateAlbum(string albumTitle)
        // public Task CreateAlbum(string albumTitle)
        {
            createAlbum.Execute(albumTitle);
            ///return createAlbum.Execute(albumTitle); 
        }

        public void FindAlbums(string albumTitle)
        // public Task FindAlbum(string albumTitle)
        {
            //findAlbum.Execute(albumTitle);
            ///return findAlbum.Execute(albumTitle); 
        }
    }
}
