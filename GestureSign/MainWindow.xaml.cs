﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using GestureSign.Common.Plugins;
using GestureSign.Common.Gestures;
using GestureSign.Common.Applications;
using GestureSign.Common.Drawing;
using GestureSign.Common;
using GestureSign.Common.Input;
using GestureSign.Input;
using GestureSign.Applications;

namespace GestureSign
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.StudyModeButton.Content = GestureSign.Configuration.AppConfig.Teaching ? "学习模式 开启" : "学习模式 关闭";
            if (Input.TouchCapture.Instance.State == CaptureState.UserDisabled)
            {
                this.DisableGesturesButton.Content = "手势识别 关闭";
                this.StudyModeButton.IsEnabled = false;
            }
            else
            {
                this.DisableGesturesButton.Content = "手势识别 就绪";
                this.StudyModeButton.IsEnabled = true;
            }
            SetAboutInfo();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            this.availableAction.Dispose();
            this.availableGestures.Dispose();
            runingAppFlyout.Dispose();
            CustomAppFlyout.Dispose();
            ignoredApplications.Dispose();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }

        private void StudyModeButton_Click(object sender, RoutedEventArgs e)
        {
            UI.TrayManager.Instance.ToggleTeaching();
            this.StudyModeButton.Content = GestureSign.Configuration.AppConfig.Teaching ? "学习模式 开启" : "学习模式 关闭";
        }

        private void DisableGesturesButton_Click(object sender, RoutedEventArgs e)
        {
            Input.TouchCapture.Instance.ToggleUserDisableTouchCapture();
            if (Input.TouchCapture.Instance.State == CaptureState.UserDisabled)
            {
                this.DisableGesturesButton.Content = "手势识别 关闭";
                this.StudyModeButton.IsEnabled = false;
            }
            else
            {
                this.DisableGesturesButton.Content = "手势识别 就绪";
                this.StudyModeButton.IsEnabled = true;
            }
        }

        private void SetAboutInfo()
        {
            string version = "Version:" + Application.ResourceAssembly.GetName().Version.ToString() + "  " + (Environment.Is64BitProcess ? "64-bit" : "32-bit");
            string releaseDate = "\r\nReleaseDate:" +
                new DateTime(2000, 1, 1).AddDays(Application.ResourceAssembly.GetName().Version.Build).AddSeconds(Application.ResourceAssembly.GetName().Version.Revision * 2).ToString();
            this.AboutTextBox.Text = this.AboutTextBox.Text.Insert(0, version + releaseDate + "\r\n");
        }
    }
}