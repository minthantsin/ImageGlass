﻿/*
ImageGlass Project - Image viewer for Windows
Copyright (C) 2017 DUONG DIEU PHAP
Project homepage: http://imageglass.org

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageGlass.Services.Configuration
{
    public class ImageEditingAssociation
    {
        /// <summary>
        /// Gets, sets extension. Ex: .png
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets, sets friendly app name.
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Gets, sets full path and arguments of app. Ex: C:\app\app.exe --help
        /// </summary>
        public string AppPath { get; set; }

        /// <summary>
        /// Initial Image Editing Association
        /// </summary>
        public ImageEditingAssociation()
        {
            Extension = string.Empty;
            AppName = string.Empty;
            AppPath = string.Empty;
        }

        /// <summary>
        /// Initial Image Editing Association
        /// </summary>
        /// <param name="extension">Extension. Ex: .png</param>
        /// <param name="appName">Friendly app name.</param>
        /// <param name="appPath">Full path and arguments of app. Ex: C:\app\app.exe --help</param>
        public ImageEditingAssociation(string extension, string appName, string appPath)
        {
            Extension = extension.ToLower();
            AppName = appName;
            AppPath = appPath;
        }

        /// <summary>
        /// Initial Image Editing Association.
        /// Throw InvalidCastException if @mixString is invalid
        /// </summary>
        /// <param name="mixString">ImageEditingAssociation string. Ex: .jpg|MS Paint|C:\app\mspaint.exe</param>
        public ImageEditingAssociation(string mixString)
        {
            var itemArray = mixString.Split("|".ToCharArray());

            if (itemArray.Length != 3)
            {
                throw new InvalidCastException("Invalid ImageEditingAssociation string format.");
            }

            Extension = itemArray[0].ToLower();
            AppName = itemArray[1];
            AppPath = itemArray[2];
        }

        /// <summary>
        /// Convert ImageEditingAssociation object to string.
        /// </summary>
        /// <returns>ImageEditingAssociation string</returns>
        public override string ToString()
        {
            return $"{Extension}|{AppName}|{AppPath}";
        }
    }
}
