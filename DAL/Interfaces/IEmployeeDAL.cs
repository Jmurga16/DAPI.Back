using System;
using Entities.Entities;
namespace DAL.Interfaces
{
	public interface IEmployeeDAL : IDALGeneric<TblEmployee>
	{
        bool ChangePassword(int id, string password);
    }
}

