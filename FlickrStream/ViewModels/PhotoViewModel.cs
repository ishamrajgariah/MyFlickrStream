using FlickrStream.Infrastructure;
using FlickrStream.Logger.Interfaces;
using FlickrStream.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Threading;
using Flickr.Models.Models;
using FlickrStream.Infrastructure.Interfaces;


namespace FlickrStream.ViewModels
{
    /// <summary>
    /// The photo view model
    /// </summary>
    public class PhotoViewModel : IPhotoViewModel, INotifyPropertyChanged
    {
        private ILogger logger;
        private string tags;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Item> photos;
        private bool isTagModeAllEnabled;
        private bool includeUserIdInSearchString;
        private string userIDsToSearch;
        private bool includeLanguageInSearchString;
        private Language selectedLanguage;
        private bool isBusy;
        private IPhotoStreamBridge photoStreamAdapter;
        private IDispatcher dispatcher;

        /// <summary>
        /// Creates an instance of <see cref="PhotoViewModel"/>
        /// </summary>
        /// <param name="photoStreamAdapterInstance"></param>
        /// <param name="loggerInstance"></param>
        public PhotoViewModel(IPhotoStreamBridge photoStreamAdapterInstance, IDispatcher dispatcherInstance, ILogger loggerInstance)
        {
            this.photoStreamAdapter = photoStreamAdapterInstance;
            this.logger = loggerInstance;
            this.dispatcher = dispatcherInstance;
            SearchCommand = new RelayCommand(LoadPhotos,true);
            ClearCommand = new RelayCommand(ClearSearch, true);
            Tags = String.Empty;
            IsTagModeAllEnabled = false;
            IncludeUserIdInSearchString = false;
            UserIDsToSearch = string.Empty;
            IncludeLanguageInSearchString = false;
            SelectedLanguage = LanguageList.FirstOrDefault();
        }

       

        /// <summary>
        /// Gets or sets the list of images to be displayed
        /// </summary>
        public ObservableCollection<Item> Photos
        {
            get
            {
                return photos;
            }
            set
            {
                if(photos != value)
                {
                    photos = value;
                    RaisePropertyChanged("Photos");
                }
            }
        }

        /// <summary>
        /// Gets or sets the tags to be searched
        /// </summary>
        public string Tags
        {
            get
            {
                return tags;
            }
            set
            {
                if(tags != value)
                {
                    tags = value;
                    RaisePropertyChanged("Tags");
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the tagmode to be searched with
        /// </summary>
        public bool IsTagModeAllEnabled
        {
            get
            {
                return isTagModeAllEnabled;
            }
            set
            {
                if (isTagModeAllEnabled != value)
                {
                    isTagModeAllEnabled = value;
                    RaisePropertyChanged("IsTagModeAllEnabled");
                }
            }
        }

        /// <summary>
        /// Gets or sets if user ids to be included
        /// </summary>
        public bool IncludeUserIdInSearchString
        {
            get
            {
                return includeUserIdInSearchString;
            }
            set
            {
                if (includeUserIdInSearchString != value)
                {
                    includeUserIdInSearchString = value;
                    RaisePropertyChanged("IncludeUserIdInSearchString");
                }
            }
        }

        /// <summary>
        /// Gets or sets the IDs to be searched
        /// </summary>
        public string UserIDsToSearch
        {
            get
            {
                return userIDsToSearch;
            }
            set
            {
                if (userIDsToSearch != value)
                {
                    userIDsToSearch = value;
                    RaisePropertyChanged("UserIDsToSearch");
                }
            }
        }

        /// <summary>
        /// Gets or sets if language to be included
        /// </summary>
        public bool IncludeLanguageInSearchString
        {
            get
            {
                return includeLanguageInSearchString;
            }
            set
            {
                if (includeLanguageInSearchString != value)
                {
                    includeLanguageInSearchString = value;
                    RaisePropertyChanged("IncludeLanguageInSearchString");
                }
            }
        }

        /// <summary>
        /// Executes the search
        /// </summary>
        public RelayCommand SearchCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Clears the search
        /// </summary>
        public RelayCommand ClearCommand
        {
            get;
            set;
        }

        /// <summary>
        /// List of supported languages
        /// </summary>
        public List<Language> LanguageList =>
            new List<Language>
            {
                new Language(LanguageName.English),
                new Language(LanguageName.German),
                new Language(LanguageName.French),
                new Language(LanguageName.Italian),
                new Language(LanguageName.Korean),
                new Language(LanguageName.Portuguese),
                new Language(LanguageName.Spanish),
                new Language(LanguageName.Chinese)

            };

        /// <summary>
        /// Gets or sets the language to be searched
        /// </summary>
        public Language SelectedLanguage
        {
            get
            {
                return selectedLanguage;
            }
            set
            {
                if (selectedLanguage != value)
                {
                    selectedLanguage = value;
                    RaisePropertyChanged("SelectedLanguage");
                }
            }
        }

        /// <summary>
        /// Gets or sets is search is in progress
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if(isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        /// <summary>
        /// Raises property changed event
        /// </summary>
        /// <param name="property"></param>
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Clears all search
        /// </summary>
        private void ClearSearch()
        {
            this.Tags = String.Empty;
            Photos?.Clear();
        }

        /// <summary>
        /// Loads the photos from the feed asynchronously
        /// </summary>
        private async void LoadPhotos()
        {
            logger.LogInformation("---------Loading Photos----------");

            //Show busy indicator
            IsBusy = true;

            SearchOptions options = new SearchOptions()
            {
                Tags = this.Tags,
                IDs = this.UserIDsToSearch,
                Lang = this.SelectedLanguage.LanguageCode,
                TagMode = this.IsTagModeAllEnabled ? "all" : "any"
            };

            this.photoStreamAdapter.Options = options;

            //Get photo list
            var photoList = await this.photoStreamAdapter.GetPhotoStream();

            //update the ui
            await this.dispatcher.Dispatch(new Action(() => {
                    Photos = new ObservableCollection<Item>(photoList);
                    IsBusy = false;
                }));

            logger.LogInformation("---------Loaded Photos----------");
        }



    }
}
