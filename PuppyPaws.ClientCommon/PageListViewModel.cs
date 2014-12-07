using GalaSoft.MvvmLight.Command;
using PuppyPaws.DataContracts;
using System.Collections.ObjectModel;

namespace PuppyPaws.ClientCommon
{
    public class PageListViewModel : BaseViewModel
    {
        public InstagramContext InstagramContext { get; set; }

        public string Tag { get; set; }

        public int ImageCount { get; set; }

        public RelayCommand RefreshCmd { get; private set; }

        private ObservableCollection<Media> _imageList;
        public ObservableCollection<Media> ImageList
        {
            get { return _imageList; }
            private set
            {
                _imageList = value;
                RaisePropertyChanged("ImageList");
            }
        }

        public PageListViewModel() : base()
        {
            this.ImageCount = 15;
            this.ImageList = new ObservableCollection<Media>();
            this.RefreshCmd = new RelayCommand(PopulateImages);            
        }

        private async void PopulateImages()
        {
            var service = Factory.BuildInstagramPhotoService();

            var media = await service.FindRecentMediaByTag(this.Tag, this.ImageCount, this.InstagramContext);

            this.ImageList = new ObservableCollection<Media>(media);
        }


    }
}
