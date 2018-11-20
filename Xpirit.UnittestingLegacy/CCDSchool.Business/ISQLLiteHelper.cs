using System.Data;

namespace CCDSchool.Business
{
    public interface ISqlLiteHelper
    {
        DataTable ExecuteQuery(string Query, string Conn);

        void ExecutegeneralQuery(string txtQuery, string Conn);
    }
}