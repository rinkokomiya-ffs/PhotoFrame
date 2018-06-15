using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.Test
{
    [TestClass]
    public class PhotoFileServiceTest
    {
        private IPhotoFileService service;

        //テスト実施時の条件をそろえるため
        [TestInitialize]
        public void SetUp()
        {
            service = new ServiceFactory().PhotoFileService;
        }

        [TestMethod]
        public void 無い場合NULLが取得できること()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory("");
            // テストデータに応じたアサーション
            //if(result == null)
            //{
                Assert.AreEqual(null, result);
            //}
            //else
            //{
            //    Assert.AreNotEqual(null, result);
            //}
        }

        // テストの観点としてはエッジケース（0枚時など）やディレクトリのネスト、存在しないディレクトリの指定やパーミッションがないなどの例外処理など

        [TestMethod]
        public void 指定されたフォルダの写真ファイルが取得できること()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory("TestDir");

            //IEnurable用の要素取得
            File F = result.ElementAt(0);
            //
            Assert.AreEqual(@"C:\Users\10510292\Desktop\PhotoFrame.init\PhotoFrame\PhotoFrame.Persistence.Test\bin\Debug\TestDir\test.jpg", F.FilePath);
            // テストデータに応じたアサーション
            //Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void 指定されたフォルダのサブが読めるか()
        {
            // テストデータをどう与えるかなどはお任せします
            var result = service.FindAllPhotoFilesFromDirectory("TestDir");

            //IEnurable用の要素取得
            //File.Filepathの中身はファイルのフルパス
            File F = result.ElementAt(1);
            Assert.AreEqual(@"C:\Users\10510292\Desktop\PhotoFrame.init\PhotoFrame\PhotoFrame.Persistence.Test\bin\Debug\TestDir\Sub\test.jpg", F.FilePath);
            // テストデータに応じたアサーション
            //Assert.AreEqual(null, result);
        }
    }
}
