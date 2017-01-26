﻿using System.ComponentModel;
using Shoko.Desktop.ViewModel.Helpers;
using Shoko.Models.Client;
using Shoko.Models.Enums;

// ReSharper disable InconsistentNaming

namespace Shoko.Desktop.ViewModel.Server
{
    public class VM_MissingFile : CL_MissingFile, INotifyPropertyChangedExt
    {
        public new VM_AnimeSeries_User AnimeSeries
        {
            get { return (VM_AnimeSeries_User) base.AnimeSeries; }
            set { base.AnimeSeries = this.SetField(base.AnimeSeries, value, ()=>HasSeriesData); }
        }

        public string AniDB_SiteURL => string.Format(Models.Constants.URLS.AniDB_Series, AnimeID);

        public string Episode_SiteURL => string.Format(Models.Constants.URLS.AniDB_Episode, EpisodeID);

        public string File_SiteURL => string.Format(Models.Constants.URLS.AniDB_File, FileID);

        public string AnimeTitleAndID => $"{AnimeTitle} ({AnimeID})";

        public string EpisodeNumberAndID => $"Episode {EpisodeTypeAndNumber} ({EpisodeID})";

        public string FileDescAndID => $"File {FileID}";

        public enEpisodeType EpisodeTypeEnum => (enEpisodeType)EpisodeType;

        public new int EpisodeType
        {
            get { return base.EpisodeType; }
            set { base.EpisodeType = this.SetField(base.EpisodeType, value, ()=> EpisodeType, ()=>EpisodeTypeAndNumber); }
        }

        public new int EpisodeNumber
        {
            get { return base.EpisodeNumber; }
            set { base.EpisodeNumber = this.SetField(base.EpisodeNumber, value, () => EpisodeNumber, ()=>EpisodeTypeAndNumber); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public bool HasSeriesData => AnimeSeries!=null;

        public string EpisodeTypeAndNumber
        {
            get
            {
                string shortType = "";
                switch (EpisodeTypeEnum)
                {
                    case enEpisodeType.Credits: shortType = "C"; break;
                    case enEpisodeType.Episode: shortType = ""; break;
                    case enEpisodeType.Other: shortType = "O"; break;
                    case enEpisodeType.Parody: shortType = "P"; break;
                    case enEpisodeType.Special: shortType = "S"; break;
                    case enEpisodeType.Trailer: shortType = "T"; break;
                }
                return $"{shortType}{EpisodeNumber}";
            }

        }
    }
}
