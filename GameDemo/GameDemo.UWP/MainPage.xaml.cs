﻿namespace GameDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new GameDemo.App());
        }
    }
}