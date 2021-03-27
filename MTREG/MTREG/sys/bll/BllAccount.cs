/*************************************************************************************
    * CLR版本：       2.0.50727.4984
    * 类 名 称：       BllAccount
    * 机器名称：       DELL-PC
    * 命名空间：       MTLIS.sys.bll
    * 文 件 名：       BllAccount
    * 创建时间：       2013/5/18 16:41:45
    * 作    者：       郑月
    * 说    明：       用户管理
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.db;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTHIS.sys.bll
{
    /// <summary>
    /// 用户管理
    /// </summary>
   public class BllAccount
   {
       string sql;
       //添加保存
       public int add(string name, string nickname, string pincode, string pwd, int role, int dept) 
       {
           sql = "insert into lis_account"
               +"( name"
               +", nickname"
               +", pincode"
               +", passwd"
               +", role_id"
               +", depart_id"              
               +", isused)"
               +" values"
               +"("  +DataTool.addFieldBraces( name.Trim()) 
               + "," +DataTool.addFieldBraces( nickname.Trim())
               + "," +DataTool.addFieldBraces( pincode.Trim())
               + "," +DataTool.addFieldBraces( pwd.Trim())
               + "," +DataTool.addFieldBraces( role.ToString())
               + "," +DataTool.addFieldBraces( dept.ToString())
               + "," +DataTool.addFieldBraces( "1")
               + ")";
           int r=BllMain.Db.Update(sql);
           return r;
       }

       //修改保存
       public int modify(int id, string name, string nickname, string pincode, int role, int depart, DataTable dt, string hiscode)
       {
           sql = "update lis_account set name='" + name.Trim() + "',nickname='" + nickname.Trim() + "', pincode='"
               + pincode.Trim() + "', role_id=" + role + ",depart_id='" + depart + "', hiscode = " + int.Parse(hiscode) + " where id=" + id;
           int r = BllMain.Db.Update(sql);
           foreach (DataRow row in dt.Rows)
           {
               DataTable table = this.findAccountById(int.Parse(row[1].ToString()));
               string isused = table.Rows[0]["isused"].ToString();
               string isused2 = row[6].ToString();
               
               if (!isused.Equals(isused2))
               {
                   sql = "update lis_account set isused='" + DataTool.BoolStrValue(isused2) + "'  where id=" + row[1].ToString();
                   BllMain.Db.Update(sql); 
               }
               string ispower = table.Rows[0]["power"].ToString();
               string ispower2 = row[8].ToString();
               if (!ispower.Equals(ispower2))
               {
                   sql = "update lis_account set power='" + DataTool.BoolStrValue(ispower2) + "'  where id=" + row[1].ToString();
                   BllMain.Db.Update(sql);
               }
               
           }
           return r;
       }

       /// <summary>
       /// 查数据
       /// </summary>
       /// <returns></returns>
       public DataTable getData()
       {
          string sql=" select a.name"
                +", a.id" 
                +", a.nickname"
                +", a.pincode"
                +", (select name from lis_role where id=a.role_id) as role_name"
                +", (select name from lis_depart where id=a.depart_id) as dept_name"
                +", a.isused"
                +", a.passwd"
                +", a.power"
                +", a.hiscode"
                +"  from lis_account a ";
           return BllMain.Db.Select(sql).Tables[0];
       }

       //根据id查询
       public DataTable findAccountById(int id)
       {
           sql = "select * from acc_account where id=" + id;
           return BllMain.Db.Select(sql).Tables[0];
       }

       //重置密码
       public int setPwd(string pwd, int id)
       {
           sql = "update acc_account set passwd=" + DataTool.addFieldBraces( pwd.Trim()) + " where id=" + id;
           return BllMain.Db.Update(sql);
       }
       //查询旧密码正确
       public bool selectoldpwd(string pwd, int id)
       {
           sql = "select * from lis_account where passwd = '" + pwd + "' and id = '" + id + "'";
           DataTable dt = BllMain.Db.Select(sql).Tables[0];
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       // 判断登录账号是否重复
       public bool checkUniqueName(string name)
       {
           sql = "select count(*) from lis_account account where account.name='" + name + "'";
           DataTable dt = BllMain.Db.Select(sql.ToString()).Tables[0];
           if (dt.Rows.Count > 0)
           {
               int result = int.Parse(BllMain.Db.Select(sql.ToString()).Tables[0].Rows[0][0].ToString());
               if (result > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           else
           {
               return false;
           }

       }

       /// <summary>
       ///  删除账号  add ytc
       /// </summary>
       /// <param name="dict_id"></param>
       public void deleteAccount(string account_id)
       {
           sql = string.Format("delete from lis_account where id={0}", account_id);
           BllMain.Db.Update(sql);

       }
      
   }
}
