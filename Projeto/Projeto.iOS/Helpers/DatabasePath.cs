using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Projeto.Interface;
using Projeto.iOS.Helpers;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Projeto.iOS.Helpers
{
    class DatabasePath : IDbPath
    {
        public string GetDbPath()
        {
            string filename = "projeto.db3";
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");



            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);



            return Path.Combine(libFolder, filename);
        }
    }
}