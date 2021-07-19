using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DarthValidatorBlazor.Components
{
    public partial class FileUploadComponent
    {
        private IList<IBrowserFile> _files = new List<IBrowserFile>();
        private bool Warning = false;
        private string WarningMessage;
        private void UploadFiles(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            foreach (var file in inputFileChangeEventArgs.GetMultipleFiles())
            {
                if (AcceptableFile(file))
                    _files.Add(file);
            }
            //TODO upload the files to the server
        }

        public void RemoveFile(IBrowserFile file)
        {
            _files.Remove(file);
        }

        public void ClearWarning()
        {
            Warning = false;
        }

        public async void ValidateFiles()
        {
            //TODO: Add validation method
        }

        public bool AcceptableFile(IBrowserFile file)
        {
            //TODO: File size can only be 500KB, add this to this method
            if (_files.Count > 1)
            {
                Warning = true;
                WarningMessage = "You can only upload 2 files at a time.";
                return false;
            }
            else if (!file.Name.EndsWith(".csv"))
            {
                Warning = true;
                WarningMessage = "Only csv files can be uploaded.";
                return false;
            }
            return true;
        }
    }
}
