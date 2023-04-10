using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Serilog;

namespace LDPlayerNTC
{
	public static class ImageScanOpenCV
    {
		public static Bitmap GetImage(string path)
		{
			return new Bitmap(path);
		}
		public static Bitmap Find(string main, string sub, double percent = 0.9)
		{
			Bitmap mainImg = ImageScanOpenCV.GetImage(main);
			Bitmap subImg = ImageScanOpenCV.GetImage(sub);
			return ImageScanOpenCV.Find(main, sub, percent);
		}
		public static Bitmap Find(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Image<Bgr, byte> source = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
			Image<Bgr, byte> imageToShow = source.Copy();
			try
			{
                using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
                {
                    double[] minValues;
                    double[] maxValues;
                    Point[] minLocations;
                    Point[] maxLocations;
                    result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    bool flag = maxValues[0] > percent;
                    if (flag)
                    {
                        Rectangle match = new Rectangle(maxLocations[0], template.Size);
                        imageToShow.Draw(match, new Bgr(System.Drawing.Color.Red), 2, LineType.EightConnected, 0);
                    }
                    else
                    {
                        imageToShow = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Find");
                Log.Error(ex, ex.Message);
            }
            return (imageToShow == null) ? null : imageToShow.ToBitmap();
		}
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);
		public static Point? FindOutPoint(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			bool flag = subBitmap == null || mainBitmap == null;
			Point? result2;
            try
            {
                if (flag)
                {
                    result2 = null;
                }
                else
                {

                    bool flag2 = subBitmap.Width > mainBitmap.Width || subBitmap.Height > mainBitmap.Height;
                    if (flag2)
                    {
                        result2 = null;
                    }

                    else
                    {
                        Image<Bgr, byte> source = new Image<Bgr, byte>(mainBitmap);
                        Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);

                        Point? resPoint = null;
                        using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
                        {
                            double[] minValues;
                            double[] maxValues;
                            Point[] minLocations;
                            Point[] maxLocations;
                            result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                            bool flag3 = maxValues[0] > percent;
                            if (flag3)
                            {
                                resPoint = new Point?(maxLocations[0]);
                            }
                        }
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        result2 = resPoint;
                    }
                }
                return result2;
            }
            catch (Exception ex)
            {
                Log.Error("FindOutPoint");
                Log.Error(ex, ex.Message);
            }
            return null;
        }
		public static List<Point> FindOutPoints(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{		
			Image<Bgr, byte> source = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
			List<Point> resPoint = new List<Point>();
			for (; ; )
			{
				try
				{
                    using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
                    {
                        double[] minValues;
                        double[] maxValues;
                        Point[] minLocations;
                        Point[] maxLocations;
                        result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        bool flag = maxValues[0] > percent;
                        if (!flag)
                        {
                            break;
                        }
                        Rectangle match = new Rectangle(maxLocations[0], template.Size);
                        source.Draw(match, new Bgr(System.Drawing.Color.Blue), -1, LineType.EightConnected, 0);
                        resPoint.Add(maxLocations[0]);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("FindOutPoints");
                    Log.Error(ex, ex.Message);
                }
            }
			return resPoint;
		}
		public static List<Point> FindColor(Bitmap mainBitmap, System.Drawing.Color color)
        {
            List<Point> result = new List<Point>();
            try
			{
                int searchValue = color.ToArgb();              
                try
                {
                    for (int x = 0; x < mainBitmap.Width; x++)
                    {
                        for (int y = 0; y < mainBitmap.Height; y++)
                        {
                            bool flag = searchValue.Equals(mainBitmap.GetPixel(x, y).ToArgb());
                            if (flag)
                            {
                                result.Add(new Point(x, y));
                            }
                        }
                    }
                }
                finally
                {
                    if (mainBitmap != null)
                    {
                        ((IDisposable)mainBitmap).Dispose();
                    }
                }              
            }
			catch (Exception ex)
			{
				Log.Error("FindColor");
                Log.Error(ex, ex.Message);
            }
            return result;
        }
		public static void TestDilate(Bitmap bmp)
		{
			for (; ; )
			{
				Image<Gray, byte> imgOld = new Image<Gray, byte>(bmp);
				imgOld.Save("old.png");
				Image<Gray, byte> img2 = new Image<Gray, byte>(imgOld.Width, imgOld.Height, new Gray(255.0)).Sub(imgOld);
				img2.Save("img23.png");
				Image<Gray, byte> eroded = new Image<Gray, byte>(img2.Size);
				Image<Gray, byte> temp = new Image<Gray, byte>(img2.Size);
				Image<Gray, byte> skel = new Image<Gray, byte>(img2.Size);
                try
                {
                    skel.SetValue(0.0, null);
                    CvInvoke.Threshold(img2, img2, 127.0, 255.0, ThresholdType.Binary);
                    Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(2, 2), new Point(-1, -1));
                    CvInvoke.Dilate(imgOld, eroded, element, new Point(-1, -1), 1, BorderType.Reflect, default(MCvScalar));
                    eroded.CopyTo(img2);
                    skel.Bitmap.Save("ele.png");
                    img2.Save("img2.png");
                    eroded.Save("eroded.png");
                    temp.Save("temp.png");
                }
                catch (Exception ex)
                {
                    Log.Error("TestDilate");
                    Log.Error(ex, ex.Message);
                }
            }
		}
		public static Bitmap ThreshHoldBinary(Bitmap bmp, byte threshold = 190)
		{ 
			Image<Gray, byte> img = new Image<Gray, byte>(bmp);
			Image<Gray, byte> bmp2 = img.ThresholdBinary(new Gray((double)threshold), new Gray(255.0));
			return bmp2.ToBitmap();
		}
		public static Bitmap NotWhiteToTransparentPixelReplacement(Bitmap bmp)
		{
			try
			{
                bmp = ImageScanOpenCV.CreateNonIndexedImage(bmp);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        System.Drawing.Color pixel = bmp.GetPixel(x, y);
                        bool flag = pixel.R > 200 && pixel.G > 200 && pixel.B > 200;
                        if (flag)
                        {
                            bmp.SetPixel(x, y, System.Drawing.Color.Transparent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("NotWhiteToTransparentPixelReplacement");
                Log.Error(ex, ex.Message);
            }
            return bmp;
		}
		public static Bitmap WhiteToBlackPixelReplacement(Bitmap bmp)
		{
			try
			{
                bmp = ImageScanOpenCV.CreateNonIndexedImage(bmp);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        System.Drawing.Color pixel = bmp.GetPixel(x, y);
                        bool flag = pixel.R > 20 && pixel.G > 230 && pixel.B > 230;
                        if (flag)
                        {
                            bmp.SetPixel(x, y, System.Drawing.Color.Black);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("WhiteToBlackPixelReplacement");
                Log.Error(ex, ex.Message);
            }
            return bmp;
		}
		public static Bitmap TransparentToWhitePixelReplacement(Bitmap bmp)
		{
			try
			{
                bmp = ImageScanOpenCV.CreateNonIndexedImage(bmp);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        bool flag = bmp.GetPixel(x, y).A >= 1;
                        if (flag)
                        {
                            bmp.SetPixel(x, y, System.Drawing.Color.White);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("TransparentToWhitePixelReplacement");
                Log.Error(ex, ex.Message);
            }
            return bmp;
		}
		public static Bitmap CreateNonIndexedImage(Image src)
		{
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
			{              
                using (Graphics gfx = Graphics.FromImage(newBmp))
                {
                    gfx.DrawImage(src, 0, 0);
                }             
            }
            catch (Exception ex)
            {
                Log.Error("CreateNonIndexedImage");
                Log.Error(ex, ex.Message);
            }
            return newBmp;
        }
	}
}
