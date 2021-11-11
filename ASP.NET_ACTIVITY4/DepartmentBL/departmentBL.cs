using DepartmentDAL;
using DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentBL
{
    public class departmentBL
    {
        public int AddNewDepartment(departmentDTO newObj)
        {
            try
            {
                departmentDAL dalObj = new departmentDAL();
                int result = dalObj.InsertTheNewDataIntoHumanResourcesDepartment(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
