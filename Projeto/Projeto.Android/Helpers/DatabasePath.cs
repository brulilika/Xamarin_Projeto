using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Projeto.Droid.Helpers;
using Projeto.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Projeto.Droid.Helpers
{
    public class DatabasePath : IDbPath
    {
        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "projeto.db3");
        }
    }
}