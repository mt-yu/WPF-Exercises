using CommunityToolkit.Mvvm.ComponentModel;
using Sample._4.Models;
using System.Collections.ObjectModel;

namespace Sample._4.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            CreateMenu();
        }

        private void CreateMenu()
        {
            Menus = new ObservableCollection<MenuModel>()
            {
                new MenuModel(){  Name = "发现音乐" },
                new MenuModel(){  Name = "博客" },
                new MenuModel(){  Name = "视频" },
                new MenuModel(){  Name = "关注" },
                new MenuModel(){  Name = "直播" },
                new MenuModel(){  Name = "私人漫游" },
            };

            // 我的音乐
            Menus2 = new ObservableCollection<Menu2Model>()
            {
                 new Menu2Model(){ Icon="\xe707",  Name = "我喜欢的音乐" , HasMessage = false },
                new Menu2Model(){ Icon="\xe651", Name = "本地下载", HasMessage = false },
                new Menu2Model(){ Icon="\xe6d7", Name = "最近播放", HasMessage = true },
                new Menu2Model(){ Icon="\xe7de", Name = "我的音乐云盘", HasMessage = false },
                new Menu2Model(){ Icon="\xe600", Name = "我的播客", HasMessage = true },
                new Menu2Model(){ Icon="\xe625", Name = "我的收藏", HasMessage = false  },
            };

            // 创建歌单
            Menus3 = new ObservableCollection<MenuModel>()
            {
                new MenuModel(){  Name = "创建的歌单1" },
                new MenuModel(){  Name = "创建的歌单2" },
                new MenuModel(){  Name = "创建的歌单3" },
                new MenuModel(){  Name = "创建的歌单4" },
                new MenuModel(){  Name = "创建的歌单5" },
                new MenuModel(){  Name = "创建的歌单6" },
            };

            // 收藏歌单
            Menus4 = new ObservableCollection<MenuModel>()
            {
                new MenuModel(){  Name = "收藏的歌单1" },
                new MenuModel(){  Name = "收藏的歌单2" },
                new MenuModel(){  Name = "收藏的歌单3" },
                new MenuModel(){  Name = "收藏的歌单4" },
                new MenuModel(){  Name = "收藏的歌单5" },
                new MenuModel(){  Name = "收藏的歌单6" },
            };
        }

        public string Title { get; set; } = "Sample 4";
        private ObservableCollection<MenuModel> menus;

        public ObservableCollection<MenuModel> Menus
        {
            get { return menus; }
            set { menus = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Menu2Model> menus2;

        public ObservableCollection<Menu2Model> Menus2
        {
            get { return menus2; }
            set { menus2 = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MenuModel> menus3;

        public ObservableCollection<MenuModel> Menus3
        {
            get { return menus3; }
            set { menus3 = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MenuModel> menus4;

        public ObservableCollection<MenuModel> Menus4
        {
            get { return menus4; }
            set { menus4 = value; OnPropertyChanged();}
        }
    }
}