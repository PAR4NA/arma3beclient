﻿using Arma3BE.Client.Modules.MainModule.Dialogs;
using Arma3BE.Client.Modules.MainModule.Extensions;
using Arma3BE.Client.Modules.MainModule.Models;
using Arma3BE.Client.Modules.MainModule.ViewModel;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Arma3BE.Client.Modules.MainModule.Grids
{
    /// <summary>
    ///     Interaction logic for PlayersControl.xaml
    /// </summary>
    public partial class PlayersControl : UserControl
    {
        public PlayersControl()
        {
            InitializeComponent();

            var menu = dg.Generate<PlayerView>();

            foreach (var menuItem in menu.Items.OfType<MenuItem>().ToList())
            {
                menu.Items.Remove(menuItem);
                dg.ContextMenu.Items.Add(menuItem);
            }

            foreach (var generateColumn in GridHelper.GenerateColumns<PlayerView>())
            {
                dg.Columns.Add(generateColumn);
            }
        }
    }
}