namespace template_clean_arq_api.Application.Abstraction
{
    public interface IPasswordService
    {
        Task<string> Hash(string password);
        Task<string> HashFast(string password);
        Task<bool> Verify(string password, string hash);
    }
}
