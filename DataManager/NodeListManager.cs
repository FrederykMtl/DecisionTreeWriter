using System;
using System.Collections.Generic;
using System.Linq;
using FileManager;

namespace DataManager
{
    /// <summary>
    /// Manages the in-memory list of existing nodes
    /// </summary>
    public class NodeListManager : INodeListManager
    {
        private const string FileArea = "UI";

        private readonly IFileController _fileController;
        private readonly List<string> _existingNodeList;

        public NodeListManager(IFileController fileController)
        {
            if(fileController == null)
                throw new ArgumentNullException(nameof(fileController), @"A valid instance of FileControler is required");

            _fileController = fileController;

            var nodes = _fileController.GetTextFileContent(nameof(NodeListManager), FileArea);

            _existingNodeList = string.IsNullOrWhiteSpace(nodes) ? 
                                                new List<string>() : 
                                                nodes.Split(',').ToList();
            _existingNodeList.Insert(0, "");
        }

        public List<string> GetExistingNodesList()
        {
            return _existingNodeList;
        }

        public void AddNewNode(string nodeName)
        {
            if (_existingNodeList.Contains(nodeName))
                return;

            _existingNodeList.Add(nodeName);
            _fileController.SaveTextFileContent(nameof(NodeListManager), _existingNodeList.ToCsvString(), FileArea);
        }

        public bool DeleteNode(string nodeName)
        {
            if (!_existingNodeList.Contains(nodeName))
                return false;

            _existingNodeList.Remove(nodeName);
            _fileController.SaveTextFileContent(nameof(NodeListManager), _existingNodeList.ToCsvString(), FileArea);

            return true;
        }

        public void DeleteAllNodes()
        {
            _existingNodeList.Clear();
        }
    }
}
