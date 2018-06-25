using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class FindAlbums
    {
        private readonly IAlbumRepository repository;

        public FindAlbums(IAlbumRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Album> Execute(string albumTitle)
        //public async Task<IEnumerable<Album>> Execute(string AlbumName)
        {
            // アルバムリスト生成
            List<Album> albums = new List<Album>();

            // 対象が全アルバムの場合
            if(albumTitle == "allAlbum")
            {
                Func<IQueryable<Album>, IQueryable<Album>> func = allAlbums => (allAlbums ?? null);
                //await Task.Run(() =>
                //{
                  albums = repository.Find(func).ToList();
                //});
            }

            // それ以外の時
            else
            {
                Func<IQueryable<Album>, IQueryable<Album>> func = allAlbums =>
                {
                    List<Album> tmpAlbums = new List<Album>();
                    foreach (var p in allAlbums)
                    {
                        if(p.Name.Contains(albumTitle))
                        {
                            albums.Add(p);
                        }
                    };
                    return tmpAlbums.AsQueryable();
                };

                //await Task.Run(() =>
                //{
                    albums = repository.Find(func).ToList();
                //});
            }

            // 条件一致しないときの処理は？

            return albums;
        }
    }
}