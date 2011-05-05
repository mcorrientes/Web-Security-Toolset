using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.MD5Cracker
{
    class MD5Cracker
    {
        private bool crackedHash;
        public bool CrackedHash
        {
            get { return crackedHash; }
            set { crackedHash = value; }
        }

        private string hashValue;
        public string HashValue
        {
            get { return hashValue; }
            set { hashValue = value; }
        }

        public MD5Cracker()
        {
            crackedHash = false;
            hashValue = string.Empty;
        }

        public void Crack(string MD5Hash)
        {
            string Result = SearchMD5(MD5Hash);
            if (Result != null && Result.Length > 0)
            {
                crackedHash = true;
                hashValue = Result;
            }
            else
                crackedHash = false;
        }

        private string SearchMD5(string MD5)
        {
            string MD5Value = string.Empty;
            string HTML = SendWebrequest("http://gdataonline.com/seekhash.php", "hash=" + MD5 + "&code=7af9a4521cc8c8fc2144e574c63db7ff");

            if (HTML.Contains("Pass") && HTML.Contains("RESULTS:") && !HTML.Contains("?????"))
            {
                HTML = StripHTML(">", "</b></td></tr>\n</table>\n<br /><center>Total number of cracked", HTML);
                MD5Value = HTML;
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.hashchecker.com/index.php", "search_field=" + MD5);
                if (HTML.Contains(" used "))
                    MD5Value = StripHTML("<li>" + MD5 + " is <b>", "</b> used ", HTML);
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.md5decrypter.com/", "hash=" + MD5);
                if (HTML.Contains("Normal Text:"))
                    MD5Value = StripHTML("Normal Text: </b>", "\n<br/><br/>\n\n<", HTML);
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://md5.rednoize.com/?p&_=&s=md5&q=" + MD5, string.Empty);
                if (HTML.Length > 0 && HTML.Length < 255)
                    MD5Value = HTML;
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.securitystats.com/tools/hashcrack.php", "type=MD5&Submit=Submit&inputhash=" + MD5);
                if (HTML.Contains("MD5 Hash Found!!"))
                    MD5Value = StripHTML("= ", "</td>\n      </tr>\n    </table>\n    </td>\n  </tr>\n</table>\n\n", HTML);
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.hashkiller.com/api/api.php?md5=" + MD5, string.Empty);
                if (HTML.Contains("<found>true</found>"))
                    MD5Value = StripHTML(">", "</plain>", HTML);
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.md5this.com/callme.php?hash=" + MD5, string.Empty);
                if (HTML.Contains("Current result is") && !HTML.Contains("cracking..."))
                    MD5Value = StripHTML(">", "</font></font></tr></table>", HTML);
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.md5crack.com/crackmd5.php", "term=" + MD5 + "&crackbtn=Crack+that+hash+baby%21");
                if (HTML.Contains("Found: md5"))
                    MD5Value = StripHTML("Found: md5(\"", "\") = ", HTML);
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://plain-text.info/search", "searchhash=" + MD5 + "&searchstatus=&searchaction=&searchaction2=&searchsubmitter=", "http://plain-text.info/search");
                if (HTML.Contains("<td>cracked</td>"))
                {
                    HTML = StripHTML("<td>" + MD5 + "</td>", "<td>cracked</td>", HTML);
                    MD5Value = StripHTML(">", "</td>\r\n<td>", HTML);
                }
            }
            if (MD5Value.Length == 0)
            {
                HTML = SendWebrequest("http://www.milw0rm.com/cracker/search.php", "hash=" + MD5);
                if (HTML.Contains("width=90>cracked"))
                    MD5Value = StripHTML(">", "</TD><TD align=\"middle\" nowrap=\"nowrap\" width=90>cracked", HTML);
            }

            return MD5Value;
        }

        private string StripHTML(string SearchBegin, string SearchEnd, string HTML)
        {
            string NewHTML = string.Empty;

            int RemoveEnd = HTML.IndexOf(SearchEnd);
            if (RemoveEnd > 0)
                NewHTML = HTML.Remove(RemoveEnd);

            int RemoveBegin = NewHTML.LastIndexOf(SearchBegin) + SearchBegin.Length;
            if (RemoveBegin > 0)
                NewHTML = NewHTML.Remove(0, RemoveBegin);

            return NewHTML;
        }

        private string SendWebrequest(string URL, string POST)
        {
            return SendWebrequest(URL, POST, string.Empty);
        }

        private string SendWebrequest(string URL, string POST, string Referer)
        {
            CreateWebrequest request = new CreateWebrequest();
            return request.StringGetWebPage(URL, POST, Referer);
        }
    }
}
