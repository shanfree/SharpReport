using System;
using System.Collections;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.SharpMemberShip.Model;

namespace SharpReportWeb.Admin
{
    public partial class Register : WebBasePage
    {
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
                return DEFAULT_MENUID; ;
                // 正式的代码
                //return "15";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("用户注册", "请填写用户名、密码、所在部门。");
                    BindDepartment();
                }
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                Log(ex);
            }
        }

        void BindDepartment()
        {
            IList<DepartmentInfo> dList = new Department().GetList();
            ddlDepartment.DataSource = dList;
            ddlDepartment.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                string pwd = tbPws.Text;
                string departmentID = ddlDepartment.SelectedValue;
                //new User().Add(name, pwd, departmentID);
                this.ShowMsg("用户添加成功。");
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                Log(ex);
            }
        }
    }
}
