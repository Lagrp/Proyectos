using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AppTools
{
    #region C O L O R

    public static class ColorTool
    {
        public static SolidColorBrush ColorHxa(string color)
        {
            //if (color.IndexOf("#") != -1)
            color = color.Replace("#", "");

            string a = color.Length == 8 ? color.Substring(0, 2) : "FF";
            string r = color.Length == 8 ? color.Substring(2, 2) : color.Substring(0, 2);
            string g = color.Length == 8 ? color.Substring(4, 2) : color.Substring(2, 2);
            string b = color.Length == 8 ? color.Substring(6, 2) : color.Substring(4, 2);

            byte A = byte.Parse(a, NumberStyles.HexNumber);
            byte R = byte.Parse(r, NumberStyles.HexNumber);
            byte G = byte.Parse(g, NumberStyles.HexNumber);
            byte B = byte.Parse(b, NumberStyles.HexNumber);

            return new(System.Windows.Media.Color.FromArgb(A, R, G, B));
        }
    }

    #endregion C O L O R

    #region I M A G E N

    public static class ImageTool
    {
        public static ImageSource LoadImageSource(string rutaArch = null, Assembly assembly = null, byte[] imageBytes = null)
            => GetBitmapImage(rutaArch, assembly, imageBytes);

        public static ImageBrush LoadImageBrush(string rutaArch = null, Assembly assembly = null, byte[] imageBytes = null)
        {
            ImageBrush imB = new();
            imB.ImageSource = GetBitmapImage(rutaArch, assembly, imageBytes);
            imB.Freeze();
            //System.Windows.Threading.Dispatcher
            return imB;
        }

        //Convierte Byte a Imagen
        public static BitmapImage ByteToImage(byte[] imageBytes) => GetBitmapImage(bytes: imageBytes);

        //Convierte Imagen a Byte
        public static byte[] ImageToByte(ImageBrush imageBrush)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapImage bm = new();

                bm = (BitmapImage)imageBrush.ImageSource;
                var bitmap = GetBitmap(bm);
                bitmap.Save(stream, ImageFormat.Png);
                bm.Freeze();
                return stream.ToArray();
            }
        }

        public static byte[] ImageFilePathToByte(string imageFilePath)
        {
            using (FileStream fs = new(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] imgBytes = new byte[fs.Length];
                fs.Read(imgBytes, 0, imgBytes.Length);
                return imgBytes;
            }
        }

        private static Bitmap GetBitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        private static BitmapImage GetBitmapImage(string rutaArch = null, Assembly assembly = null, byte[] bytes = null, bool returnMessageError = false)
        {
            try
            {
                string stringUri = "";

                if (assembly == null)
                    assembly = Assembly.GetEntryAssembly();

                if (!string.IsNullOrEmpty(rutaArch))
                {
                    if (rutaArch[1] == ':')
                    {
                        stringUri = rutaArch;
                    }
                    else
                    {
                        if (rutaArch[0] == '/')
                            rutaArch = rutaArch[1..];
                        stringUri = $"pack://application:,,,/{assembly.GetName().Name};component/{rutaArch}";
                    }
                }

                BitmapImage bM = new();

                bM.BeginInit();
                bM.CacheOption = BitmapCacheOption.OnLoad;
                if (bytes != null)
                {
                    MemoryStream stream = new MemoryStream(bytes);
                    bM.StreamSource = stream;
                }
                else
                {
                    bM.UriSource = new Uri(stringUri, UriKind.Absolute);
                }
                bM.EndInit();
                bM.Freeze();

                return bM;
            }
            catch (Exception ex)
            {
                if (returnMessageError)
                    MessageBox.Show(ex.Message, $"AppTools.ImageTool-{assembly.GetName().Name}");
                return null;
            }
        }
    }

    #endregion I M A G E N

    #region T E X T O

    public static class InputMasck
    {
        //input mask
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }

    #endregion T E X T O

    #region C O N V E R T I D O R E S

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bValue = (bool)value;
            return bValue ? Visibility.Visible : (object)Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            return visibility == Visibility.Visible ? true : (object)false;
        }
    }

    public class BoolToValueConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? FalseValue : ((bool)value ? TrueValue : FalseValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Nota: esta implementación excluye el uso de "nulo" como el
            // valor de TrueValue. Probablemente no sea un problema en el 99,94% de todos los casos,
            // pero algo a considerar, si uno está buscando hacer un 100%
            // clase de propósito general aquí.
            return value != null && EqualityComparer<T>.Default.Equals((T)value, TrueValue);
        }
    }

    #endregion C O N V E R T I D O R E S

    internal class UnidadesDecenasYCentenas
    {
        private static void Main(string[] args)
        {
            int centenas, decenas, numero, unidades;
            Console.Write("Ingresa el valor de numero: ");
            numero = int.Parse(Console.ReadLine());
            centenas = (numero % 1000 - numero % 100) / 100;
            decenas = (numero % 100 - numero % 10) / 10;
            unidades = numero % 10;
            Console.WriteLine("Valor de centenas: " + centenas);
            Console.WriteLine("Valor de decenas: " + decenas);
            Console.WriteLine("Valor de unidades: " + unidades);
            Console.WriteLine();
            Console.Write("Presiona una tecla para terminar . . . ");
            Console.ReadKey();
        }
    }
}