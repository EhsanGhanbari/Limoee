using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Limoee.Application
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            const int maxContentLength = 1024 * 512; //500 KB
            var allowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".jpeg" };

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!allowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", allowedFileExtensions);
                return false;
            }
            else if (file.ContentLength > maxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}