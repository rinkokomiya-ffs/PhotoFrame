﻿using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Domain.UseCase
{
    /// <summary>
    /// アルバムを作成するユースケースを実現する
    /// </summary>
    // TODO: 仮実装
    public class CreateAlbum
    {
        private readonly IAlbumRepository repository;

        public CreateAlbum(IAlbumRepository repository)
        {
            this.repository = repository;
        }

        //public void Execute(string albumTitle)
        public Task Execute(string albumTitle) => Task.Run(() =>
        {
            // 時間かかる処理
            var album = Album.Create(albumTitle);
            repository.Store(album);
        //}
         });
    }
}
