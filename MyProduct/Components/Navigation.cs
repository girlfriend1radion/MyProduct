using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyProduct.Components
{
    internal class Navigation
    {

        public static bool isAuth = false;//авторизовался ли пользователь
        public static MainWindow main;//доступ к элементам окна МаинВиндоу
        public static List<Nav> navs = new List<Nav>();//история страниц
        public static int IsRole = 2;
        public static void NextPage(Nav nav)
        {
            navs.Add(nav);
            Update(nav);
        }
        public static void BackPage()
        {
            if (navs.Count > 1)
            {
                navs.Remove(navs[navs.Count - 1]);
                Update(navs[navs.Count - 1]);
            }
        }
        private static void Update(Nav nav)
        {
            main.TitlePage.Text = nav.Title;
            main.BackBTN.Visibility = navs.Count > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            main.MyFrame.Navigate(nav.Page);
        }

    }
    class Nav
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public Nav(string Title, Page Page)
        {
            this.Title = Title;
            this.Page = Page;
        }

    }
}
