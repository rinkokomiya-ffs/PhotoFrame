using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class FindPhotos
    {
        private readonly IPhotoRepository repository;

        public FindPhotos(IPhotoRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Photo> Execute(string albumTitle)
        {
            // フォトリスト生成
            List<Photo> photos = new List<Photo>();

            Func<IQueryable<Photo>, IQueryable<Photo>> func = allPhotos =>
            {
                List<Photo> tmpPhotos = new List<Photo>();
                foreach (var p in allPhotos)
                {
                    if (p.Album?.Name == albumTitle)
                    {
                        tmpPhotos.Add(p);
                    }
                };
                return tmpPhotos.AsQueryable();
            };

            //await Task.Run(() =>
            //{
            return repository.Find(func).ToList();
            //});
        }
    }
}
