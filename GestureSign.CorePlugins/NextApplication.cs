﻿using System;
using GestureSign.Common.Plugins;
using System.Windows.Controls;
using WindowsInput;
using WindowsInput.Native;
using GestureSign.Common.Localization;

namespace GestureSign.CorePlugins
{
    public class NextApplication : IPlugin
    {
        #region Private Variables

        IHostControl _HostControl = null;

        #endregion

        #region IAction Properties

        public string Name
        {
            get { return LocalizationProvider.Instance.GetTextValue("CorePlugins.NextApplication.Name"); }
        }

        public string Description
        {
            get { return LocalizationProvider.Instance.GetTextValue("CorePlugins.NextApplication.Description"); }
        }

        public UserControl GUI
        {
            get { return null; }
        }

        public string Category
        {
            get { return "Windows"; }
        }

        public bool IsAction
        {
            get { return true; }
        }

        #endregion

        #region IAction Methods

        public void Initialize()
        {

        }

        public bool Gestured(PointInfo ActionPoint)
        {
            InputSimulator simulator = new InputSimulator();
            try
            {
                simulator.Keyboard.KeyDown(VirtualKeyCode.LMENU)
                    .Sleep(20)
                    .KeyDown(VirtualKeyCode.TAB)
                    .Sleep(20)
                    .KeyUp(VirtualKeyCode.TAB)
                    .Sleep(20)
                    .KeyUp(VirtualKeyCode.LMENU)
                    .Sleep(20);
            }
            catch (Exception)
            {
                simulator.Keyboard.KeyUp(VirtualKeyCode.TAB)
                    .Sleep(20)
                    .KeyUp(VirtualKeyCode.LMENU)
                    .Sleep(20);

                return false;
            }

            return true;
        }

        public bool Deserialize(string SerializedData)
        {
            return true;
            // Nothing to deserialize
        }

        public string Serialize()
        {
            // Nothing to serialize, send empty string
            return "";
        }

        public void ShowGUI(bool IsNew)
        {
            // Nothing to do here
        }

        #endregion

        #region Host Control

        public IHostControl HostControl
        {
            get { return _HostControl; }
            set { _HostControl = value; }
        }

        #endregion
    }
}