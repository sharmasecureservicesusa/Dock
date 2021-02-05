﻿using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using AvaloniaDemo.ViewModels;
using AvaloniaDemo.Views;
using Dock.Model.Core;

namespace AvaloniaDemo
{
    public class App : Application
    {       
        public static readonly Styles FluentDark = new Styles
        {
            new StyleInclude(new Uri("avares://AvaloniaDemo/Styles"))
            {
                Source = new Uri("avares://AvaloniaDemo/Themes/FluentDark.axaml")
            }
        };

        public static readonly Styles FluentLight = new Styles
        {
            new StyleInclude(new Uri("avares://AvaloniaDemo/Styles"))
            {
                Source = new Uri("avares://AvaloniaDemo/Themes/FluentLight.axaml")
            }
        };

        public static readonly Styles DefaultLight = new Styles
        {
            new StyleInclude(new Uri("avares://AvaloniaDemo/Styles"))
            {
                Source = new Uri("avares://AvaloniaDemo/Themes/DefaultLight.axaml")
            }
        };

        public static readonly Styles DefaultDark = new Styles
        {
            new StyleInclude(new Uri("avares://AvaloniaDemo/Styles"))
            {
                Source = new Uri("avares://AvaloniaDemo/Themes/DefaultDark.axaml")
            },
        };

        public override void Initialize()
        {
            Styles.Insert(0, FluentLight);

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var mainWindowViewModel = new MainWindowViewModel();

            switch (ApplicationLifetime)
            {
                case IClassicDesktopStyleApplicationLifetime desktopLifetime:
                {
                    var mainWindow = new MainWindow
                    {
                        DataContext = mainWindowViewModel
                    };

                    mainWindow.Closing += (_, _) =>
                    {
                        if (mainWindowViewModel.Layout is IDock dock)
                        {
                            if (dock.Close.CanExecute(null))
                            {
                                dock.Close.Execute(null);
                            }
                        }
                    };

                    desktopLifetime.MainWindow = mainWindow;

                    desktopLifetime.Exit += (_, _) =>
                    {
                        if (mainWindowViewModel.Layout is IDock dock)
                        {
                            if (dock.Close.CanExecute(null))
                            {
                                dock.Close.Execute(null);
                            }
                        }
                    };
                    
                    break;
                }
                case ISingleViewApplicationLifetime singleViewLifetime:
                {
                    var mainView = new MainView()
                    {
                        DataContext = mainWindowViewModel
                    };

                    singleViewLifetime.MainView = mainView;

                    break;
                }
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
