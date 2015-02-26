﻿using System;
using System.Collections.Generic;

namespace GestureSign.Common.Gestures
{
	public interface IGestureManager
	{
		void DeleteGesture(string GestureName);
		event GestureEventHandler GestureDeleted;
		bool GestureExists(string GestureName);
		string GestureName { get; set; }
		event RecognitionEventHandler GestureNotRecognized;
		event RecognitionEventHandler GestureRecognized;
		IGesture[] Gestures { get; }
		string[] GetAvailableGestures();
        string GetGestureName(List<List<System.Drawing.Point>> Points);
		string GetGestureSetNameMatch(List<List<System.Drawing.Point>> Points);
		IGesture GetNewestGestureSample(string GestureName);
		void AddGesture(IGesture Gesture);
		bool LoadGestures();
		bool SaveGestures();
	}
}