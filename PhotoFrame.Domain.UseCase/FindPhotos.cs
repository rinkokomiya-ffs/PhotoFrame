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

        public Photo Execute(Func<IQueryable<Photo>, Photo> query)
        {
            return repository.Find(query);
        }

        public IEnumerable<Photo> Execute(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            return repository.Find(query);
        }
    }
}
