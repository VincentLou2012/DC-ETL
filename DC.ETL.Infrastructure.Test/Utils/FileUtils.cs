using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DC.ETL.Infrastructure.Test.Utils
{
    /// <summary>
    /// file的操作公共类 测试用
    /// </summary>
    public class FileUtils
    {
        #region Read
        public static string ReadLast(string Path,Encoding en)
        {
            StreamReader sr = new StreamReader(Path);
            string st = string.Empty;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(line)) st = line;
            }
            sr.Close();
            return st;
        }
        /// <summary>
        /// read line of nLine
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="nLine"></param>
        /// <returns></returns>
        public string ReadLine(string Path, Encoding en, int nLine)
        {
            if (nLine < 0) return "";
            int nRowNumber = 1;
            string str = null;
            FileStream fs = null;
            StreamReader m_streamReader = null;
            bool bIsFileEnd = false;
            do
            {
                str = ReadLine(Path, en, fs, m_streamReader, ref bIsFileEnd);
                if (nLine <= nRowNumber) break;
                nRowNumber++;
            } while (str != null);
            if (str == null) str = "";
            return str;
        }
        /// <summary>
        /// read text file one line.
        /// </summary>
        /// <param name="Path">file path</param>
        /// <returns></returns>
        private string ReadLine(string Path, Encoding en, FileStream fs, StreamReader m_streamReader, ref bool bIsFileEnd)
        {
            string strLine = null;
            try
            {
                if (fs == null)
                {
                    if (string.IsNullOrEmpty(Path)) return null;
                    fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
                    bIsFileEnd = false;
                    if (fs.CanRead)
                    {
                        m_streamReader = new StreamReader(fs, en);
                        m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    }
                }
                if (fs.CanRead)
                {
                    strLine = m_streamReader.ReadLine();
                    if (strLine == null)
                        bIsFileEnd = true;
                }
                if (bIsFileEnd && m_streamReader != null)
                {
                    m_streamReader.Close();
                    m_streamReader.Dispose();
                    m_streamReader = null;
                }
                if (bIsFileEnd && fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return strLine;
        }

        /// <summary>
        /// use to read short txt file.
        /// function will check is file can be read attribute.
        /// </summary>
        /// <param name="Path">txt file absolute path</param>
        /// <returns></returns>
        public static string Read(string Path, Encoding en)
        {
            if (!File.Exists(Path))
                return "";
            //if (CheckFileExist(Path, false))//can not check relative path.
            //{
            //    Logs.WriteWarning("Read File Not Exist",Path);
            //    return "";
            //}
            //Encoding fileEncoding = FileEncoding.GetEncoding(Path, System.Text.Encoding.Unicode);//取得这txt文件的编码
            StringBuilder sb = new StringBuilder(1024);
            FileStream fs = null;
            StreamReader m_streamReader = null;
            string strLine = null;
            try
            {

                fs = new FileStream(Path, FileMode.Open);
                if (fs.CanRead)
                {
                    m_streamReader = new StreamReader(fs, en);

                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    //string arry = "";
                    strLine = m_streamReader.ReadLine();

                    if (strLine != null)
                    {
                        sb.Append(strLine);
                        sb.AppendLine();

                        do
                        {
                            strLine = m_streamReader.ReadLine();
                            sb.Append(strLine);
                            sb.AppendLine();
                        } while (strLine != null);

                    }
                }
            }
            catch(DirectoryNotFoundException dnfex)
            {
                Console.WriteLine(dnfex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (m_streamReader != null)
            {
                m_streamReader.Close();
                m_streamReader.Dispose();
            }
            if (fs != null)
            {
                fs.Close();
                fs.Dispose();
            }
            return sb.ToString();
        }
        #endregion Read
    }
}
