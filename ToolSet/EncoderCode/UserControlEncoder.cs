using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using usertools.Encoder;

namespace ToolSet.EncoderCode
{
    public partial class UserControlEncoder : UserControl
    {
        public UserControlEncoder()
        {
            InitializeComponent();
        }

        private void textEncOrig_TextChanged(object sender, EventArgs e)
        {
            EncodeGuiUpdate();
        }

        private void textEncChars_TextChanged(object sender, EventArgs e)
        {
            EncodeGuiUpdate();
        }

        void EncodeGuiUpdate()
        {
            string origString = textEncOrig.Text;
            string EncodeChars = textEncChars.Text;

            Color coloring = Color.Red;

            if (origString.Length > 0)
            {
                if (origString.Length > 8)
                    coloring = Color.Green;

                textEncMD5.Text = Encode.GenerateMD5(origString);
                textEncMD5.ForeColor = coloring;

                textDecEscape.Text = Decode.Escape(origString);
                textDecAmp.Text = Decode.Amp(origString);
                textDecFull.Text = Decode.Full(origString);

                textEncEscape.Text = System.Web.HttpUtility.UrlEncode(origString);

                if (EncodeChars.Length > 0)
                {
                    textEncAmpHash.Text = Encode.CharEncode(origString, EncodeChars, EncodeType.AmpHash);
                    textEncURLUTF8.Text = Encode.CharEncode(origString, EncodeChars, EncodeType.UrlEncodeUTF8);
                    textEncAmpHex.Text = Encode.CharEncode(origString, EncodeChars, EncodeType.AmpHex);
                    textEncURL.Text = Encode.CharEncode(origString, EncodeChars, EncodeType.UrlEncode);
                    textEncAmp.Text = Encode.CharEncode(origString, EncodeChars, EncodeType.HtmlEncode);
                }
                else
                {
                    textEncAmpHash.Text = Encode.FullEncode(origString, EncodeType.AmpHash);
                    textEncURLUTF8.Text = Encode.FullEncode(origString, EncodeType.UrlEncodeUTF8);
                    textEncAmpHex.Text = Encode.FullEncode(origString, EncodeType.AmpHex);
                    textEncURL.Text = Encode.FullEncode(origString, EncodeType.UrlEncode);
                    textEncAmp.Text = System.Web.HttpUtility.HtmlEncode(origString);
                }

            }
            else
            {
                textEncAmpHash.Text = "";
                textEncMD5.Text = "";
                textEncURL.Text = "";
                textEncURLUTF8.Text = "";
                textEncAmp.Text = "";
                textEncAmpHash.Text = "";
                textEncAmpHex.Text = "";
                textEncEscape.Text = "";

                textDecAmp.Text = "";
                textDecFull.Text = "";
                textDecEscape.Text = "";
            }
        }

    }
}
