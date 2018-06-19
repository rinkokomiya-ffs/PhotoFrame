using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence
{
    /// <summary>
    /// <see cref="IPhotoFileService">の実装クラス
    /// </summary>
    class PhotoFileService : IPhotoFileService
    {
        public IEnumerable<File> FindAllPhotoFilesFromDirectory(string directory)
        {
            // TODO: コレクション講座で実装予定
            //指定されたフォルダの写真ファイルが取得できるようにする

            //もしDirectoryがないなら
            if (!System.IO.Directory.Exists(directory))
            {
                return null;
            }
            else
            {
                //あるならListを作りましょう
                List<File> lists = new List<File>();
                //Directoryからファイルを取得してfilesに入れましょう
                //string[] files = System.IO.Directory.GetFiles(directory);
                //それぞれの要素に対して、以下のことを行いましょう

                IEnumerable<string> files = System.IO.Directory.EnumerateFiles(directory, "*.*", System.IO.SearchOption.AllDirectories);

                foreach (var s in files)
                {
                    //もし拡張子が.jpgなら
                    //if (System.IO.Path.GetExtension(s) == "*.jpg")
                    {
                        //fileにフルパスを追加し、ファイルをリストに追加しましょう
                        File file = new File(System.IO.Path.GetFullPath(s));
                        //File file = new File(System.IO.Path.GetFileName(s));
                        if (file.IsPhoto == true)
                        {
                            lists.Add(file);
                        }
                    }
                }
                return lists;
                //throw new NotImplementedException();
            }
        }
    }
}
