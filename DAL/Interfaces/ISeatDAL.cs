using Entities.Entities;

namespace DAL.Interfaces
{

    public interface ISeatDAL : IDALGeneric<TblSeat>
    {
        bool Post(int id);
    }
}
