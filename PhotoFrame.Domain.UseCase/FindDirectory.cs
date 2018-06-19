using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;



namespace PhotoFrame.Domain.UseCase
{
    public class FindDirectory
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IPhotoFileService service;

        public FindDirectory(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            this.albumRepository = albumRepository;
            this.photoRepository = photoRepository;
            service = new ServiceFactory().PhotoFileService;
        }

        public async Task<IEnumerable<Photo>> Execute(string directory)
        {
            // 画像ファイルリスト生成
            var photoFileList = service.FindAllPhotoFilesFromDirectory(directory);
            List<Photo> photos = new List<Photo>();

            // ファイルパスからFindをして、既にcsvに存在するかどうかも調べたほうがよい？

            // フォトデータ生成
            foreach (var p in photoFileList)
            {
                var photo = Photo.CreateFromFile(p);
                await Task.Run(() =>
                {
                    photoRepository.Store(photo);
                });
                photos.Add(photo);
            }
            return photos;
        }





        //public Task Execute(string albumTitle) => Task.Run(() =>
        //{
        //    var album = Album.Create(albumTitle);
        //    repository.Store(album);
        //});

        // await Task.Run
    }
}
