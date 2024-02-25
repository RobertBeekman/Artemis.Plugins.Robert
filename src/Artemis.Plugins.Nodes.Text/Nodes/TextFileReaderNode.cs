using System;
using System.IO;
using Artemis.Core;

namespace Artemis.Plugins.Nodes.FileReaders.Nodes
{
    [Node("Text File Reader", "Reads the contents of a text file.", "Text", InputType = typeof(string), OutputType = typeof(string))]
    public class TextFileReaderNode : Node, IDisposable
    {
        private FileSystemWatcher _fileWatcher;
        private string? _currentFilePath;
        private bool _fileChanged;

        public TextFileReaderNode()
        {
            Path = CreateInputPin<string>("File path");
            Contents = CreateOutputPin<string>();
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Changed += FileChanged;
        }

        public OutputPin<string> Contents { get; }
        public InputPin<string> Path { get; }

        public override void Evaluate()
        {
            string? filePath = Path.Value;
            if (filePath != _currentFilePath)
            {
                SetupFileWatcher(filePath);

                _currentFilePath = filePath;
                _fileChanged = true;
            }

            if (_fileChanged && filePath != null && File.Exists(filePath))
            {
                _fileChanged = false;
                Contents.Value = File.ReadAllText(filePath);
            }
        }

        private void SetupFileWatcher(string? filePath)
        {
            _fileWatcher.Dispose();

            if (filePath == null || !File.Exists(filePath))
                return;

            string? directory = System.IO.Path.GetDirectoryName(filePath);
            if (directory == null)
                return;

            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Changed += FileChanged;
            _fileWatcher.Path = directory;
            _fileWatcher.Filter = System.IO.Path.GetFileName(filePath);
            _fileWatcher.EnableRaisingEvents = true;
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            _fileChanged = true;
        }

        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}