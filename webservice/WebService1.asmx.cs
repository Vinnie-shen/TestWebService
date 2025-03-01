using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace webservice
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "localhost")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloStranger()
        {
            return "Hello！I am ShenchuanChao. Nice to meet you!";
        }

        [WebMethod]
        public string SendMail(string emailfrom,string To,string emailstmp,int port,string emailusername,string emailpassword,string emailnickname,string Subject,string bodys)
        {
            string From = emailfrom;            
            string SmtpServer = emailstmp; // 发送邮件服务器
            string sendusername = emailusername; //自己邮箱的名称
            string senduserpwd = emailpassword; //自己邮箱的密码
            System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
            mail.From = "\"" + emailnickname + "\"" + From + "";
            mail.To = To;
            mail.Subject = Subject;
            mail.Body = bodys;
            mail.BodyFormat = System.Web.Mail.MailFormat.Html;
            mail.BodyEncoding = System.Text.Encoding.UTF8; //邮件内容编码

            System.Web.Mail.SmtpMail.SmtpServer = SmtpServer; // 发送邮件服务器
            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", port);
            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //是否需要验证，一般是要的
            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", sendusername); //自己邮箱的用户名
            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", senduserpwd); //自己邮箱的密码
            try
            {
                System.Web.Mail.SmtpMail.Send(mail);
                return "客户询单邮件发送成功" ;
            }
            catch (Exception ex)
            {
                return "客户询单邮件发送失败" + ex;
            }

           
        }
    }
}
