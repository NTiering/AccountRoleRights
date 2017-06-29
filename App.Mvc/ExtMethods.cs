namespace App.Mvc
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public static class ExtMethods
    {
        private static string[] ImageContentTypes = new string[]{ "images/png" , "images/jpg", "images/gif" , "images/bmp" };

        private static string[] DocumentContentTypes = new string[] { "application/octet-stream", "application/pdf", "application/doc", "application/docx" , "text/plain"};

        /// <summary>
        /// Determines whether [is image file].
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        ///   <c>true</c> if [is image file] [the specified file]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsImageFile(this HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0) return false;
            return ImageContentTypes.Contains(file.ContentType.ToLower());
        }

        /// <summary>
        /// Determines whether [is document file].
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        ///   <c>true</c> if [is document file] [the specified file]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDocumentFile(this HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0) return false;
            return DocumentContentTypes.Contains(file.ContentType.ToLower());
        }

        /// <summary>
        /// Tries the get document file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="onTypeFound">The on type found.</param>
        /// <param name="onContentFound">The on content found.</param>
        /// <returns></returns>
        public static bool TryGetDocumentFile(this HttpPostedFileBase file, Action<string> onTypeFound, Action<byte[]> onContentFound)
        {
            return file.IsDocumentFile() && file.TryGetFileUpload(onTypeFound, onContentFound);
        }

        /// <summary>
        /// Tries the get image file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="onTypeFound">The on type found.</param>
        /// <param name="onContentFound">The on content found.</param>
        /// <returns></returns>
        public static bool TryGetImageFile(this HttpPostedFileBase file, Action<string> onTypeFound, Action<byte[]> onContentFound)
        {
            return file.IsImageFile() && file.TryGetFileUpload(onTypeFound, onContentFound);
        }

        /// <summary>
        /// Gets the file upload.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="onTypeFound">The on type found.</param>
        /// <param name="onContentFound">The on content found.</param>
        /// <returns></returns>
        private static bool TryGetFileUpload(this HttpPostedFileBase file, Action<string> onTypeFound, Action<byte[]> onContentFound)
        {
            if (file == null || file.ContentLength == 0) return false;
            onTypeFound(file.ContentType);
            byte[] buffer = new byte[file.ContentLength];
            file.InputStream.Read(buffer, 0, file.ContentLength);
            onContentFound(buffer);
            return true;
        }

        /// <summary>
        /// Returns empty enumeration if null.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DefaultIfNull<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        /// <summary>
        /// Adds the model error to the controller context.
        /// </summary>
        /// <param name="ctr">The CTR.</param>
        /// <param name="errors">The errors.</param>
        public static void AddModelErrors(this Controller ctr, List<IModelError> errors)
        {
            if (errors == null || errors.Any() == false) return;
            errors.ForEach(x => ctr.ModelState.AddModelError(x.Property, x.ErrorMessage.ToSiteText()));
        }

        /// <summary>
        /// Translates the specified string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string ToSiteText(this string s)
        {
            return Resources.SiteText.Instance.GetString(s);
        }

        /// <summary>
        /// Determines whether this instance is debug.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>
        ///   <c>true</c> if the specified HTML helper is debug; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDebug(this HtmlHelper htmlHelper)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// Logs the action executing.
        /// </summary>
        public static void LogActionExecuting(this Contracts.ILogProvider log, string name, ActionExecutingContext ctx)
        {
            if (log == null || ctx == null) return;
            log.Info(name, string.Format("[{0}] {1} ", ctx.HttpContext.Request.HttpMethod, ctx.HttpContext.Request.RawUrl));
        }
    }
}