using System;
using SIRC.Framework.SharpMemberShip;
using System.Web;
using System.Configuration;
using System.IO;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;

namespace SharpReportWeb.Pages
{
    public partial class ViewImage : WebBasePage
    {
        #region 权限验证
        /// <summary>
        /// 该页面登录后访问
        /// </summary>
        public override bool CanRediect
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 栏目ID,用于权限验证
        /// </summary>
        public override string MenuID
        {
            get
            {
                // TODO:测试时不进行权限验证
                return DEFAULT_MENUID;
                // 正式的代码
                //return "1";
            }
        }
        /// <summary>
        /// 权限验证失败时，跳转到登录页
        /// </summary>
        protected override void RediretToLoginPage()
        {
            Response.Redirect("Login.aspx", true);
        }
        #endregion

        #region 属性
        /// <summary>
        ///发票实体ID
        /// </summary>
        protected string InvoiceID
        {
            get
            {
                return GetViewState("InvoiceID");
            }
            set
            {
                ViewState["InvoiceID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string invoiceID = GetRequest("id");
                if (string.IsNullOrEmpty(invoiceID))
                {
                    ShowMsg("未指定发票，无法显示扫描图片。");
                    return;
                }
                this.InvoiceID = invoiceID;
                InvoiceInfo vInfo = new Invoice().GetByID(invoiceID);
                if (string.IsNullOrEmpty(vInfo.URL) == false)
                {
                    imagePhoto.ImageUrl = "~/UserImg/" + vInfo.URL;
                }
            }
        }

        #region 保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceInfo iInfo = GetiInfoFromPage();
                if (iInfo != null)
                {
                    new Invoice().Update(iInfo.ID, iInfo.URL);
                }
                ShowMsg("操作成功！");
            }
            catch (ArgumentException ae)
            {
                this.ShowMsg(ae.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }

        #region 获取页面值
        private InvoiceInfo GetiInfoFromPage()
        {
            InvoiceInfo iInfo = new Invoice().GetByID(this.InvoiceID);
            HttpPostedFile upFile = flImage.PostedFile;
            int fileLength = upFile.ContentLength;
            if (fileLength <= 0)
            {
                throw new ArgumentException("操作失败，无法获取图片内容！");
            }
            if (upFile.ContentType != "image/pjpeg")
            {
                throw new ArgumentException("操作失败，上传文件格式不正确！");
            }
            int imageSize = 80;
            if (fileLength > imageSize * 1024)
            {
                throw new ArgumentException("操作失败，上传的图片超过" + imageSize + "K！");
            }
            //无子目录
            string path = GetPhysicalPath(string.Empty);
            if (!string.IsNullOrEmpty(iInfo.ID)) //说明做更新操作,先删除再更新
            {
            }
            string fileName = string.Format("{0}_{1}.jpg", iInfo.ID, iInfo.Number);
            path = path + "/" + fileName;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            upFile.SaveAs(path);
            imagePhoto.ImageUrl = "~/UserImg/" + fileName;
            iInfo.URL = fileName;
            return iInfo;
        }

        #region 返回对应的物理路径,如果不存在则创建
        /// <summary>
        /// 返回对应的物理路径,如果不存在则创建
        /// </summary>
        /// <returns></returns>
        protected string GetPhysicalPath(string folderName)
        {
            string path = Server.MapPath("~/UserImg/") + folderName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return Server.MapPath("~/UserImg/") + folderName;

        }
        #endregion

        #endregion

        #endregion
    }
}
