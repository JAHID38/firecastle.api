namespace RnD.API.Infrastructures.Auth
{
    public interface IJwtProvider
    {
        public string GenerateToken(string Email);
    }
}
