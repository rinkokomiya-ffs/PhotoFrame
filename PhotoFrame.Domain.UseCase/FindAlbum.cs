using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class FindAlbum
    {
        private readonly IAlbumRepository repository;

        public FindAlbum(IAlbumRepository repository)
        {
            this.repository = repository;
            //RepositoryFactory repos = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
            //repository = repos.AlbumRepository;
        }

        public Album Execute(Func<IQueryable<Album>, Album> query)
        {
            return repository.Find(query);
        }

        public IEnumerable<Album> Execute(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            return repository.Find(query);
        }
    }
}