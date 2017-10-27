using System;
using System.IO;
using System.Text;
using Common;

/// <summary>
/// nslookup2csv
/// </summary>
namespace nslookup2csv
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        #region "Process"
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            String[] strParams = Environment.GetCommandLineArgs();
            String[] strLines;
            Encoding objEncode = Encoding.GetEncoding(Define.EncodingType);
            String strOutputFileName = "";

            try
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("nslookup2csv");
                Console.WriteLine("--------------------");

                if (ParamCheck(strParams) == false)
                {
                    Console.WriteLine("Parameter error");
                    return;
                }
                else
                {
                    Console.WriteLine("Target:" + Path.GetFullPath(strParams[1]));

                    strLines = File.ReadAllLines(strParams[1], objEncode);

                    strOutputFileName = @".\" + Path.GetFileNameWithoutExtension(strParams[1]) + ".csv";

                    if (strLines.Length != 0)
                    {
                        File.WriteAllLines(strOutputFileName, SetOutputLines(strLines), objEncode);
                    }
                }

                Console.WriteLine("Output:" + Path.GetFullPath(strOutputFileName));
                Console.WriteLine("Finish");
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        /// <summary>
        /// ParamCheck
        /// </summary>
        /// <param name="vstrParams"></param>
        /// <returns></returns>
        static Boolean ParamCheck(String[] vstrParams)
        {
            try
            {
                if (vstrParams.Length != 2 || File.Exists(vstrParams[1]) == false)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SetOutputLines
        /// </summary>
        /// <param name="vstrLines"></param>
        /// <returns></returns>
        static string[] SetOutputLines(String[] vstrLines)
        {

            String[] strOutputLines = null;
            string strLine = "";
            int j = 0;

            try
            {
                Array.Resize(ref strOutputLines, vstrLines.Length);

                // Header
                if (vstrLines.Length > 0)
                {
                    strOutputLines[j] = "Target" + "\t" + "Server" + "\t" + "Address" + "\t" + "Name" + "\t" + "Address";
                }

                // Detail
                for (int i = 0; i <= vstrLines.Length - 1; i++)
                {
                    strLine = vstrLines[i].ToLower();

                    if (strLine.ToLower().Contains(">nslookup") == true)
                    {
                        j += 1;
                        strOutputLines[j] += strLine.Substring(strLine.IndexOf(">nslookup") + 9).Trim();
                        strOutputLines[j] += "\t";
                    }


                    if (strLine.Contains("サーバー:") == true)
                    {
                        strOutputLines[j] += strLine.Substring(strLine.IndexOf("サーバー:") + 6).Trim();
                        strOutputLines[j] += "\t";
                    }


                    if (strLine.Contains("address:") == true)
                    {
                        strOutputLines[j] += strLine.Substring(strLine.IndexOf("address:") + 9).Trim();
                        strOutputLines[j] += "\t";
                    }

                    if (strLine.Contains("addresses:") == true)
                    {
                        strOutputLines[j] += strLine.Substring(strLine.IndexOf("addresses:") + 10).Trim();
                        strOutputLines[j] += "\t";

                        while (true)
                        {
                            i += 1;
                            strOutputLines[j] += vstrLines[i].Trim();
                            strOutputLines[j] += "\t";

                            if (vstrLines[i + 1].Trim() == "" || vstrLines[i].ToLower().Contains(">nslookup"))
                            {
                                break;
                            }
                        }
                    }

                    if (strLine.Contains("名前:") == true)
                    {
                        strOutputLines[j] += strLine.Substring(strLine.IndexOf("名前:") + 4).Trim();
                        strOutputLines[j] += "\t";
                    }
                }

                Array.Resize(ref strOutputLines, j + 1);

                return strOutputLines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Common process"
        /// <summary>
        /// Exception process
        /// </summary>
        /// <param name="ex"></param>
        private static void ExceptionProcess(Exception ex)
        {
            Log.ExceptionOutput(ex, Define.ErrLogPath);
        }
        #endregion

    }
}
