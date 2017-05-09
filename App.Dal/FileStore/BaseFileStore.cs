namespace App.Dal.Store
{
    using Contracts.Dals;
    using System;

    abstract class FileStore : IFileStore
    {
        private static int GUIDLength = 32;

        /// <summary>
        /// Tries to get the file
        /// </summary>
        public bool TryGet(byte[] id, out byte[] fileAsBytes)
        {
            if (id == null || IsFileStoreIdentifier(id))
            {
                fileAsBytes = null;
                return false;
            }

            fileAsBytes = GetFile(id);
            return true;
        }

        /// <summary>
        /// Adds the specified file as bytes.
        /// </summary>
        public bool TryAdd(byte[] fileAsBytes, out byte[] id)
        {
            if (fileAsBytes == null || IsFileStoreIdentifier(fileAsBytes))
            {
                id = null;
                return false;
            }

            var guidId = Guid.NewGuid();
            SaveFile(guidId, fileAsBytes);
            id = guidId.ToByteArray();
            return true;
        }


        /// <summary>
        /// Determines whether item COULD BE an ident
        /// </summary>
        public bool IsFileStoreIdentifier(byte[] id)
        {
            if (id == null) return false;
            if (id.Length != GUIDLength) return false;
            var potential = BitConverter.ToString(id);
            Guid g;
            return Guid.TryParse(potential, out g);
        }

        /// <summary>
        /// Removes the specified file.
        /// </summary>
        public bool TryRemove(byte[] id)
        {
            if (IsFileStoreIdentifier(id) == false) return false;
            return RemoveFile(id);
        }

        /// <summary>
        /// Makes the identifier.
        /// </summary>
        /// <returns></returns>
        private static byte[] MakeId()
        {
            var rtn = Guid.NewGuid().ToByteArray();
            return rtn;
        }

        protected abstract void SaveFile(Guid guidId, byte[] fileAsBytes);

        protected abstract bool RemoveFile(byte[] id);

        protected abstract byte[] GetFile(byte[] id);

    }
}
