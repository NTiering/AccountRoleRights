using System;

public interface IFileStore
{   
    /// <summary>
    /// Tries to get the file
    /// </summary>
    bool TryGet(byte[] id, out byte[] fileAsBytes);

    /// <summary>
    /// Determines whether item COULD BE an ident
    /// </summary>       
    bool IsFileStoreIdentifier(byte[] id);

    /// <summary>
    /// Adds the specified file as bytes.
    /// </summary>
    /// <param name="fileAsBytes">The file as bytes.</param>
    /// <returns></returns>
    bool TryAdd(byte[] fileAsBytes, out byte[] id);

    /// <summary>
    /// Removes the specified file.
    /// </summary>
    /// <param name="id">The identifier.</param>
    bool TryRemove(byte[] id);
}
