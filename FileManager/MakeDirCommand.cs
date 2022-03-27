using CmdParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileManager
{
    class MakeDirCommand : ICommand
    {
        private string _path;

        public void Execute(IFileManagerModel fileManagerModel, CommandlineOptions cmdOptions)
        {
            var options = cmdOptions as MakeDirCommandOptions;

            _path = options.Target;
            var fis = fileManagerModel.Content;

            if (Path.IsPathFullyQualified(_path))
            {
                DirectoryInfo newDir = new DirectoryInfo(_path);
                newDir.Create();
            }
            else
            {
                fileManagerModel.CurrentDirectory.CreateSubdirectory(_path);
            }
        }
    }

    class MakeDirCommandOptions : CommandlineOptions
    {
        [Option("-t", "--target", HasValue = true, HelpText = "Name of directory", Required = true)]
        public string Target { get; set; }

        [OptionsDescription]
        public string CommandDescription { get; set; } = "Makes new directory";
    }
}
