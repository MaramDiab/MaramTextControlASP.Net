namespace MaramTX.Models
{
    //store file information like Name and Path
    public class FileModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
    //list of file
    public class FilesModels
    {
        public List<FileModel> files { get; set; } = new List<FileModel>();
    }
}
