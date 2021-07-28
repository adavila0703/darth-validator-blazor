using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DarthValidatorBlazor.Utils;
using System.Threading;
using static System.Net.WebRequestMethods;
using System.Security.Permissions;

namespace DarthValidatorBlazor.Components
{
    public partial class FileUploadComponent
    {
        private IList<IBrowserFile> _files = new List<IBrowserFile>();
        private List<List<string>> validationContent = new List<List<string>>();
        private string[] validationResult = new string[4];
        private bool Warning = false;
        private string WarningMessage;


        public void UploadFiles(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            foreach (var file in inputFileChangeEventArgs.GetMultipleFiles())
            {
                if (AcceptableFile(file))
                    _files.Add(file);
                    FileToList(file);
            }
        }

        public void RemoveFile(IBrowserFile file)
        {
            var itemIndex = _files.IndexOf(file);
            _files.Remove(file);
            validationContent.RemoveAt(itemIndex);
            Console.WriteLine(validationContent.Count);
        }

        public void ClearWarning()
        {
            Warning = false;
        }

        public bool AcceptableFile(IBrowserFile file)
        {
            //TODO: File size can only be 500KB, add this to this method
            //also add a check to make sure you cannot validate unless 2 files have been uploaded
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
        public bool ValidationIsValid()
        {
            if(_files.Count == 2)
            {
                return true;
            }
            else
            {
                Warning = true;
                WarningMessage = "You do not have enought files to validate";
                return false;
            }
        }

        public void ValidateFiles()
        {

            if (ValidationIsValid())
            {
                validationResult = Validator.Validation(validationContent[0], validationContent[1]);
            }
        }

        public async void FileToList(IBrowserFile file)
        {
            var incomingString = (await new StreamReader(file.OpenReadStream()).ReadToEndAsync()).Split('\n');
            validationContent.Add(incomingString.ToList());
        }
    }
}
