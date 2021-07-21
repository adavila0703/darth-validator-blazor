using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DarthValidatorBlazor.Utils;
using System.Threading;

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

        public async static IAsyncEnumerable<string> ParseIncomingStream(IBrowserFile file)
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                yield return await stream.ReadToEndAsync();
                stream.Close();
            }
        }

        public static async Task<List<string>> StreamToList(IBrowserFile file)
        {
            List<string> newList = new List<string>();
            await foreach (var line in ParseIncomingStream(file))
            {
                newList.Add(line);
            }
            return newList;
        }

        public async void ValidateFiles()
        {
            //TODO: Fix error
            var listOne = await StreamToList(_files[0]);
            var listTwo = await StreamToList(_files[1]);
            var validation = Validator.Validation(listOne, listTwo);
        }
    }
}
