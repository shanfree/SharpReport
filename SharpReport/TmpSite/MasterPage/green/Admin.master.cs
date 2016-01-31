using System;
using System.Web.UI.WebControls;
using Shanfree.Portal.BLL;
using Shanfree.Portal.Model;
using System.Configuration;
using Shanfree.Framework.Utility;

public partial class MasterPage_Admin : System.Web.UI.MasterPage
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
            TreeNodeInfo<MenuInfo> tree = new CommonMenu().GetMenuTree(MenuInfo.DEFAULT_PARENT_ID, false);
            mMain.Items.Clear();
            BindTree(tree, mMain);
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
            string url = node.STInstance.Url;
            MenuItem item = new MenuItem(name, id);
            string scriptFormat = @"../../{0}?mID={1}";
            item.NavigateUrl = string.Format(scriptFormat, url, id);
            if (node.STInstance.IsExtendUrl)
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
            string url = node.STInstance.Url;
            MenuItem item = new MenuItem(name, id);
            string scriptFormat = @"../../{0}?mID={1}";
            item.NavigateUrl = string.Format(scriptFormat, url, id);
            if (node.STInstance.IsExtendUrl)
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
