﻿using System;
using System.IO;
using System.Text;

namespace Common
{
    public static class Log
    {
        /// <summary>
        /// ExceptionOutput
        /// </summary>
        public static void ExceptionOutput(Exception ex, String path)
        {
            Encoding objEncoding = new UTF8Encoding(false);
            StreamWriter objWriter = new StreamWriter(path, true, objEncoding);

            try
            {
                objWriter.WriteLine(ex);
                objWriter.Close();
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
