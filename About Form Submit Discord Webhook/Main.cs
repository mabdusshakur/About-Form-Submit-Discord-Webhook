using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace About_Form_Submit_Discord_Webhook
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private static byte[] sendData(string endPoint, NameValueCollection data)
        {
            using(WebClient wc = new WebClient())
            {
                return wc.UploadValues(endPoint, data);
            }
        }

        private static void sendToDiscord(string url, string message, string botname)
        {
            sendData(url, new NameValueCollection()
            {
                {
                    "username",
                    botname
                },
                {
                    "content",
                    message
                }
            });
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            string url = "";
            string Name = name_tb.Text;
            string email = email_tb.Text;
            string Phoen = phone_tb.Text;

            bool developer = false ;
            bool copy_paster = false;

            if (developer_cb.Checked) { developer = true; cp_cb.Checked = false; }
            if(cp_cb.Checked ) { copy_paster = true; developer_cb.Checked = false; }


            var sendData = "Name : " + Name + "\nEmail : " + email + "\nPhoen : " + Phoen + "\n ```Developer : " + developer + "\nCopy Paster : " + copy_paster + "```";
            sendToDiscord(url,sendData,"User Information Form");
        }
    }
}
