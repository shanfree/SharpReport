using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
using BLL = SIRC.Framework.SharpMemberShip.BLL;

namespace SharpReportWeb.MasterPage
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected string HOME_PAGE
        {
            get
            {
                return ConfigurationManager.AppSettings["HostName"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string guid = Request.QueryString["guid"];
                if (string.IsNullOrEmpty(guid) == false)
                {
                    //UserInfo uInfo = new BLL.User().GetUserInfoByGuid(guid);
                    //TreeNodeInfo<MenuInfo> tree = new BLL.Menu().GetTreeByUserID(uInfo.ID);
                    //mMain.Items.Clear();
                    //BindTree(tree, mMain);
                }
            }

        }
        /// <summary>
        /// 生成栏目树
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="mMain"></param>
        private void BindTree(TreeNodeInfo<MenuInfo> tree, Menu mMain)
        {
            foreach (TreeNodeInfo<MenuInfo> node in tree.SubNodeList)
            {
                string name = node.STInstance.Name;
                string id = node.STInstance.ID;
                string url = node.STInstance.URL;
                MenuItem item = new MenuItem(name, id);
                string scriptFormat = @"../{0}?mID={1}";
                item.NavigateUrl = string.Format(scriptFormat, url, id);
                if (node.STInstance.Target == "blank")
                {
                    item.NavigateUrl = "http://" + url;
                    item.Target = "_blank";
                }
                mMain.Items.Add(item);
                if (node.Count != 0)
                {
                    BindTree(node, item);
                }
            }
        }
        /// <summary>
        /// 生成栏目树
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="parentItem"></param>
        private void BindTree(TreeNodeInfo<MenuInfo> tree, MenuItem parentItem)
        {
            foreach (TreeNodeInfo<MenuInfo> node in tree.SubNodeList)
            {
                string name = node.STInstance.Name;
                string id = node.STInstance.ID;
                string url = node.STInstance.URL;
                MenuItem item = new MenuItem(name, id);
                string scriptFormat = @"../{0}?mID={1}";
                item.NavigateUrl = string.Format(scriptFormat, url, id);
                if (node.STInstance.Target == "blank")
                {
                    item.NavigateUrl = "http://" + url;
                    item.Target = "_blank";
                }
                parentItem.ChildItems.Add(item);
                if (node.Count != 0)
                {
                    BindTree(node, item);
                }
            }
        }
    }
}
