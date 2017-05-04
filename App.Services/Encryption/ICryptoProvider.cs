namespace App.Services.Encryption
{
    public interface ICryptoProvider
    {
        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="iterations">The iterations.</param>
        /// <returns></returns>
        string CreateHash(string input, int iterations = 12);

        /// <summary>
        /// Decrypts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns></returns>
        string Decrypt(string input, string passPhrase);

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns></returns>
        string Encrypt(string plainText, string passPhrase);
    }
}