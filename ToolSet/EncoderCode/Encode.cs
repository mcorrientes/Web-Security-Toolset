using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace usertools.Encoder
{
    public enum EncodeType
    {
        UrlEncode = 1,
        HtmlEncode = 2,
        AmpHex = 3,
        UrlEncodeUTF8 = 4,
        AmpHash = 5
    }

    class Encode
    {
        public static string CharEncode(string origString, string EncChars, EncodeType Type)
        {
            string newString = "";
            Char[] origArray = origString.ToCharArray();
            foreach (Char strArray in origArray)
            {
                if (EncChars.Contains(strArray.ToString()))
                {
                    if (Type == EncodeType.UrlEncode)
                        newString += "%" + charToHexString(strArray);
                    if (Type == EncodeType.UrlEncodeUTF8)
                        newString += "%u00" + charToHexString(strArray);
                    if (Type == EncodeType.AmpHex)
                        newString += "&#x00" + charToHexString(strArray) + ";";
                    if (Type == EncodeType.AmpHash)
                        newString += "&#x00" + AmpHash(strArray.ToString()) + ";";
                    if (Type == EncodeType.HtmlEncode)
                        newString += HttpUtility.HtmlEncode(strArray.ToString());
                }
                else
                {
                    newString += strArray;
                }
            }
            return newString;
        }
        public static string FullEncode(string origString, EncodeType Type)
        {
            string newString = "";
            char[] chars = origString.ToCharArray();
            foreach (Char strChars in chars)
            {
                if (Type == EncodeType.UrlEncode)
                    newString += "%" + charToHexString(strChars);
                if (Type == EncodeType.UrlEncodeUTF8)
                    newString += "%u00" + charToHexString(strChars);
                if (Type == EncodeType.AmpHex)
                    newString += "&#x00" + charToHexString(strChars) + ";";
                if (Type == EncodeType.AmpHash)
                    newString += "&#" + AmpHash(strChars.ToString()) + ";";
            }
            return newString;
        }
        private static string AmpHash(string Value)
        {
            return ((int)Encoding.ASCII.GetBytes(Value)[0]).ToString();
        }
        public static string EncodeEscape(string Value)
        {
            return HttpUtility.UrlEncode(Value);
        }
        private static string charToHexString(char hex)
        {
            return Convert.ToInt32(hex).ToString("X");
        }
        private static string HexToString(byte[] bytes)
        {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }
        /*        public static string PercentageEncode(string origString)
                {

                }*/

        /*function basic_amp_decode(sString) {
  sResult = '';
  for (i=0; i<sString.length; i++) {
    switch (true) {
      case (sString.substr(i, 4) == '&lt;') :   i+=3; sResult += '<'; break;
      case (sString.substr(i, 4) == '&gt;') :   i+=3; sResult += '>'; break;
      case (sString.substr(i, 5) == '&amp;') :  i+=4; sResult += '&'; break;
      case (sString.substr(i, 6) == '&quot;') : i+=5; sResult += '"'; break;
      case (sString.substr(i, 2) == '&#') :
        sNum = '';
        for (j=i+2; j<i+7 && isNum(sString.substr(j, 1)); j++) {
          sNum+=sString.substr(j, 1);
        }
        if (sString.substr(j, 1) == ';') {
          i=j;
          sResult += String.fromCharCode(sNum);
        } else {
          sResult += sString.substr(i, 1);
        }
        break;
      default : sResult += sString.substr(i, 1);
    }
  }
  return sResult;*/

        /*function encode() {
            form.percent.value = '';
            form.percent_u.value = '';
            form.amp_hash.value = '';
            form.amp_hash_x.value = '';

            form.escape.value = escape(form.input.value);
            form.unescape.value = unescape(form.input.value);
            form.basic_amp.value = '';
            form.basic_amp_decoded.value = basic_amp_decode(form.input.value);
            form.fully_decoded.value = basic_amp_decode(form.unescape.value);

            for (var i = 0; i < form.input.value.length; i++) {
              sChar = form.input.value.charAt(i);
              iCharCode = sChar.charCodeAt(0);
              bEncode = !form.partial.checked || form.input_partial.value.indexOf(sChar) > -1;

              form.basic_amp.value      += isAlphaNum(sChar) ? sChar : ampEncodeChar(sChar);
              form.percent.value        += bEncode ? percentageEncodeChar(iCharCode) : sChar;
              form.percent_u.value      += bEncode ? percentage_uEncodeChar(iCharCode) : sChar;
              form.amp_hash.value       += bEncode ? amp_hashEncodeChar(iCharCode) : sChar;
              form.amp_hash_x.value     += bEncode ? amp_hash_xEncodeChar(iCharCode) : sChar;
            }
          }

          function percentageEncodeChar(iCharCode) { return '%' + toByteHex(iCharCode); }
          function percentage_uEncodeChar(iCharCode) { return '%u' + toWordHex(iCharCode); }
          function amp_hashEncodeChar(iCharCode) { return '&#' + iCharCode + ';'; }
          function amp_hash_xEncodeChar(iCharCode) { return '&#x' + toWordHex(iCharCode) + ';'; }
          function ampEncodeChar(sChar) {
            switch (sChar) {
              case '<' : return '&lt;';
              case '>' : return '&gt;';
              case '&' : return '&amp;';
              case '"' : return '&quot;';
            }
            return sChar;
          }

          alphaChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';
          numChars = '0123456789';
          function isAlphaNum(sChar) { return alphaChars.indexOf(sChar) > -1 || numChars.indexOf(sChar) > -1}
          function isNum(sChar) { return numChars.indexOf(sChar) > -1 }

          hex_encoding = '0123456789ABCDEF';
          function toByteHex(iDec) {
            sHex = toHex(iDec);
            while (sHex.length < 2) sHex = '0' + sHex;
            return sHex;
          }
          function toWordHex(iDec) {
            sHex = toHex(iDec);
            while (sHex.length < 4) sHex = '0' + sHex;
            return sHex;
          }
          function toHex(iDec) {
            sHex = '';
            do {
              sHex = hex_encoding.charAt(iDec % 16) + sHex;
              iDec >>= 4; // (shr 4 = div 16)
            } while (iDec>0)
            return sHex;
          }

          function basic_amp_decode(sString) {
            sResult = '';
            for (i=0; i<sString.length; i++) {
              switch (true) {
                case (sString.substr(i, 4) == '&lt;') :   i+=3; sResult += '<'; break;
                case (sString.substr(i, 4) == '&gt;') :   i+=3; sResult += '>'; break;
                case (sString.substr(i, 5) == '&amp;') :  i+=4; sResult += '&'; break;
                case (sString.substr(i, 6) == '&quot;') : i+=5; sResult += '"'; break;
                case (sString.substr(i, 2) == '&#') :
                  sNum = '';
                  for (j=i+2; j<i+7 && isNum(sString.substr(j, 1)); j++) {
                    sNum+=sString.substr(j, 1);
                  }
                  if (sString.substr(j, 1) == ';') {
                    i=j;
                    sResult += String.fromCharCode(sNum);
                  } else {
                    sResult += sString.substr(i, 1);
                  }
                  break;
                default : sResult += sString.substr(i, 1);
              }
            }
            return sResult;
          }*/
        public static string GenerateMD5(string value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(value);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
    }
    class Decode
    {
        public static string Full(string Value)
        {
            return HttpUtility.UrlDecode(HttpUtility.HtmlDecode(Value));
        }
        public static string Amp(string Value)
        {
            return HttpUtility.HtmlDecode(Value);
        }
        public static string Escape(string Value)
        {
            string newString = HttpUtility.HtmlDecode(Value);
            //newString = HexToString(HttpUtility.UrlEncodeToBytes(newString));
            return newString;
        }
        //string hex = getTheHexNumberYouWantToConvert();(char)ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
    }
}