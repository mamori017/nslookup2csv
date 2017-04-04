using System;
using System.IO;
using System.Text;

/// <summary>
/// nslookup2csv
/// </summary>
namespace nslookup2csv
{
    /// <summary>
    /// Error
    /// </summary>
    public class Common
    {
        /// <summary>
        /// LogOutput
        /// </summary>
        /// <param name="vobjEx"></param>
        /// <param name="strFilepath"></param>
        public static void LogOutput(Exception vobjEx)
        {
            Encoding objEncoding = new UTF8Encoding(false);
            StreamWriter objWriter = new StreamWriter(@".\errorLog.txt", true, objEncoding);

            try
            {
                objWriter.WriteLine(vobjEx);
                objWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objEncoding != null)
                {
                    objEncoding = null;
                }

                if (objWriter != null)
                {
                    objWriter = null;
                }
            }
        }
    }
}
