﻿using Arma3BE.Client.Infrastructure.Helpers;
using Arma3BE.Client.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace Arma3BE.Client.Modules.BanModule.Boxes
{
    /// <summary>
    ///     Interaction logic for KickPlayerWindow.xaml
    /// </summary>
    public partial class KickPlayerWindow : Window
    {
        private readonly IBanHelper _playerHelper;
        private readonly Guid _serverId;
        private readonly int _playerNum;
        private readonly string _playerGuid;
        private readonly KickPlayerViewModel Model;

        public KickPlayerWindow(IBanHelper playerHelper, Guid serverId, int playerNum, string playerGuid, string playerName)
        {
            _playerHelper = playerHelper;
            _serverId = serverId;
            _playerNum = playerNum;
            _playerGuid = playerGuid;
            InitializeComponent();

            Model = new KickPlayerViewModel(playerName);

            DataContext = Model;
        }

        private void KickClick(object sender, RoutedEventArgs e)
        {
            _playerHelper.Kick(_serverId, _playerNum, _playerGuid, tbReason.Text);
            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }


    public class KickPlayerViewModel : ViewModelBase
    {
        private string _reason;

        public KickPlayerViewModel(string playerName)
        {
            PlayerName = playerName;
        }

        public string PlayerName { get; }

        public string Reason
        {
            get { return _reason; }
            set
            {
                _reason = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> Reasons
        {
            get
            {
                try
                {
                    var str =
                        ConfigurationManager.AppSettings["Kick_reasons"].Split('|')
                            .Where(x => !string.IsNullOrEmpty(x))
                            .Select(x => x.Trim())
                            .ToArray();

                    return str;
                }
                catch (Exception)
                {
                    return new[] { string.Empty };
                }
            }
        }
    }
}