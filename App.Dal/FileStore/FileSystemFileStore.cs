namespace App.Dal.Store
{
    using System;
    using System.IO;

    class FileSystemFileStore : FileStore
    {
        private string baseDir;

        public FileSystemFileStore(string baseDir)
        {
            this.baseDir = baseDir;
        }

        protected override byte[] GetFile(byte[] id)
        {
            string filename = GetFilename(id);
            if (File.Exists(filename) == false) return null;
            var bytes = File.ReadAllBytes(filename);
            return bytes;
        }

        protected override bool RemoveFile(byte[] id)
        {
            string filename = GetFilename(id);
            if (File.Exists(filename) == false) return false;
            File.Delete(filename);
            return true;
        }

        protected override void SaveFile(Guid guidId, byte[] fileAsBytes)
        {
            string filename = GetFilename(guidId);
            if (File.Exists(filename) == false) return;
            File.WriteAllBytes(filename, fileAsBytes);
        }

        private string GetFilename(byte[] id)
        {
            return GetFilename(BitConverter.ToString(id));
        }

        private string GetFilename(Guid id)
        {
            return GetFilename(id.ToString());
        }

        private string GetFilename(string id)
        {
            return Path.Combine(baseDir, id);
        }
    }
}
