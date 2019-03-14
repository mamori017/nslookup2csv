using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace nslookup2csv
{
    public class Function
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strParams"></param>
        public void Start(String[] strParams) {
            String[] strLines;
            Encoding objEncode = Encoding.GetEncoding(Properties.Settings.Default.EncodeType);
            String strOutputFileName = "";

            try
            {
                Message.ShowTitle();

                if (ParamCheck(strParams) == false)
                {
                    Console.WriteLine(Properties.StringFormat.Default.ParameterError);
                    return;
                }
                else
                {
                    Console.WriteLine(string.Format(Properties.StringFormat.Default.Target, Path.GetFullPath(strParams[1])));

                    strLines = File.ReadAllLines(strParams[1], objEncode);

                    strOutputFileName = String.Format(Properties.StringFormat.Default.FileName, Path.GetFileNameWithoutExtension(strParams[1]));

                    if (strLines.Length != 0)
                    {
                        File.WriteAllLines(strOutputFileName, SetOutputLines(strLines), objEncode);
                    }
                }

                Console.WriteLine(String.Format(Properties.StringFormat.Default.Output, Path.GetFullPath(strOutputFileName)));
                Console.WriteLine(Properties.StringFormat.Default.Finish);
            }
            catch (Exception ex)
            {
                Common.Log.ExceptionOutput(ex, Properties.Settings.Default.ExFilePath, Properties.Settings.Default.ExFileName);
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
                    strOutputLines[j] = Properties.StringFormat.Default.OutputHeader;
                }

                // Detail
                for (int i = 0; i <= vstrLines.Length - 1; i++)
                {
                    strLine = vstrLines[i].ToLower();

                    if (strLine.ToLower().Contains(">nslookup") == true)
                    {
                        j += 1;
                    }

                    strOutputLines[j] = CreateOutputLine(strLine, ">nslookup", 9);
                    strOutputLines[j] = CreateOutputLine(strLine, "サーバー:", 6);
                    strOutputLines[j] = CreateOutputLine(strLine, "address:", 9);

                    if (strLine.Contains("addresses:") == true)
                    {
                        strOutputLines[j] += strLine.Substring(strLine.IndexOf("addresses:") + 10).Trim();
                        strOutputLines[j] += "\t";

                        while (true)
                        {
                            i += 1;
                            strOutputLines[j] += vstrLines[i].Trim() + "\t";

                            if (vstrLines[i + 1].Trim() == "" || vstrLines[i].ToLower().Contains(">nslookup"))
                            {
                                break;
                            }
                        }
                    }

                    strOutputLines[j] = CreateOutputLine(strLine, "名前:", 4);
                }

                Array.Resize(ref strOutputLines, j + 1);

                return strOutputLines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// CreateOutputLine
        /// </summary>
        /// <param name="line"></param>
        /// <param name="contain"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static string CreateOutputLine(string line, string contain, int count)
        {
            if (line.Contains(contain) == true)
            {
                return line.Substring(line.IndexOf(contain) + count).Trim() + "\t";
            }
            else
            {
                return "";
            }
        }
    }
}