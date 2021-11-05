namespace DiskUsageUtility.Interfaces
{
    public interface IDataTreeHandler
    {
        void ResetDataTree();
        void AddEntry(string path, string folderName, int sizeInBytes);
    }
}