using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShop.Data
{
    public partial class Employee
    {
        public BitmapImage Photo
        {
            get
            {
                if (EmployeePhoto is null || EmployeePhoto.Length == 0)
                {
                    return new BitmapImage(new Uri("/Images/null_image.png", UriKind.Relative));
                }
                var image = new BitmapImage();
                using (var mem = new MemoryStream(EmployeePhoto))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
        }

        public string Background
        {
            get
            {
                if (EmployeeStatus.Title == "Уволен")
                {
                    return "Red";
                }
                if (IdEmployee % 2 == 0)
                {
                    return "#32a8a2";
                }
                else
                {
                    return "White";
                }
            }
        }
    }
}
