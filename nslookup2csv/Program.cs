using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nslookup2csv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String[] strParams = Environment.GetCommandLineArgs();
                String[] strLines;
                Encoding objEncode = Encoding.GetEncoding("shift_jis");
                String strOutputFileName = "";

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

                    strOutputFileName = @".\" + Path.GetFileNameWithoutExtension(strParams[1]) + "_edited.csv";

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
                throw ex;
            }
            finally
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vstrParams"></param>
        /// <returns></returns>
        static Boolean ParamCheck(String[] vstrParams)
        {
            try
            {
                if (vstrParams.Length != 2)
                {
                    if (File.Exists(vstrParams[1]) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        static string[] SetOutputLines(String[] vstrLines)
        {
            String[] strOutputLines = null;

            try
            {
                Array.Resize(ref strOutputLines, vstrLines.Length);

                int j = 0;

                if (vstrLines.Length > 0)
                {
                    strOutputLines[j] = "TARGET IP ADDRESS" + "\t" + "SERVER" + "\t" + "ADDRESS" + "\t" + "NAME" + "\t" + "ADDRESS";
                }

                for (int i = 0; i <= vstrLines.Length - 1; i++)
                {
                if (vstrLines[i].Contains("NSLOOKUP") == true)
                    {
                        j += 1;
                        strOutputLines[j] += vstrLines[i].Substring(vstrLines[i].IndexOf("NSLOOKUP") + 9);
                        strOutputLines[j].Trim();
                        strOutputLines[j] += "\t";
                    }


                    if(vstrLines[i].Contains("サーバー:") == true)
                    {
                        strOutputLines[j] += vstrLines[i].Substring(vstrLines[i].IndexOf("サーバー:") + 6);
                        strOutputLines[j].Trim();
                        strOutputLines[j] += "\t";
                    }

                    if (vstrLines[i].Contains("Address:") == true)
                    {
                        strOutputLines[j] += vstrLines[i].Substring(vstrLines[i].IndexOf("Address:") + 9);
                        strOutputLines[j].Trim();
                        strOutputLines[j] += "\t";
                    }

                    if (vstrLines[i].Contains("名前:") == true)
                    {
                        strOutputLines[j] += vstrLines[i].Substring(vstrLines[i].IndexOf("名前:") + 4);
                        strOutputLines[j].Trim();
                        strOutputLines[j] += "\t";
                    }
                }
                return strOutputLines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
