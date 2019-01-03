namespace WebovaAplikace.Common.Authentication.Interfaces
{
    public interface IEmployeeSecurity
    {
        bool Login(string email, string pass);
    }
}