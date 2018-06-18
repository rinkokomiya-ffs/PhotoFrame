using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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