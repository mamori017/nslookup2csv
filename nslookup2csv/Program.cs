using System;
using System.IO;
using System.Text;

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
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Function objFunction;

            try
            {
                objFunction = new Function();

                String[] strParams = Environment.GetCommandLineArgs();
                objFunction.Start(strParams);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objFunction = null;
            }
        }
    }
}
