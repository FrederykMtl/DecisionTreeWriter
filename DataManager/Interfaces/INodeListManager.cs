using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace DataManager
{
    public interface INodeListManager
    {
        List<string> GetExistingNodesList();
        void AddNewNode(string nodeName);
        bool DeleteNode(string nodeName);
        void DeleteAllNodes();
    }
}
