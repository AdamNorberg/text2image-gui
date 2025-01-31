﻿using StableDiffusionGui.Io;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StableDiffusionGui.Main
{
    internal class TtiUtils
    {
        /// <returns> Path to resized image </returns>
        public static string ResizeInitImg (string path, Size targetSize, bool print)
        {
            string outPath = Path.Combine(Paths.GetSessionDataPath(), "init.png");
            Image resized = ResizeImage(IoUtils.GetImage(path), targetSize.Width, targetSize.Height);
            resized.Save(outPath);

            if (print)
                Logger.Log($"Resized init image to {targetSize.Width}x{targetSize.Height}");

            return outPath;
        }

        private static Image ResizeImage (Image image, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, w, h);
                return bmp;
            }
        }
    }
}
