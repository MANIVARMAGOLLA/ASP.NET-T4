using DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentDAL
{
    public class departmentDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        SqlDataReader sqlDataReaderObj;
        public departmentDAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }
        public int InsertTheNewDataIntoHumanResourcesDepartment(departmentDTO newObj)
        {
            try
            {
                //SQL COnnection
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["AdvWorksDBConnStr"].ConnectionString;
                //SQL Command
                sqlCmdObj.CommandText = @"InsertTheDataIntoHumanResourcesDepartment";
                sqlCmdObj.CommandType = CommandType.StoredProcedure;
                sqlCmdObj.Connection = sqlConObj;
                //Input Parameter defintion
                sqlCmdObj.Parameters.AddWithValue("@IP1", newObj.Name);
                sqlCmdObj.Parameters.AddWithValue("@IP2", newObj.GroupName);
                sqlCmdObj.Parameters.AddWithValue("@IP3", newObj.ModifiedDate);
                //Return Value
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                sqlCmdObj.Parameters.Add(prmReturn);

                //OPen COnnection
                sqlConObj.Open();
                //Anything other than SELECT/INSERT/UPDATE/DELETE we use Execute Non Query
                sqlCmdObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
