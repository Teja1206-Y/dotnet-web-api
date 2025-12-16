using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace Officeworkflows.Maui.Services
{
    public class SecureStorageService
    {
        private const string TokenKey = "jwt_token";
        private const string RoleKey = "jwt_role";

        public static Task SaveToken(string token)
        {
            return SecureStorage.Default.SetAsync(TokenKey, token);
        }
        public static bool HasToken()
        {
            var token = SecureStorage.GetAsync("jwt_token").Result;
            return !string.IsNullOrEmpty(token);
        }


        public static async Task<string?> GetToken()
        {
            return await SecureStorage.Default.GetAsync(TokenKey);
        }

        public static Task SaveRole(string role)
        {
            return SecureStorage.Default.SetAsync(RoleKey, role);
        }

        public static async Task<string> GetRole()
        {
            return await SecureStorage.Default.GetAsync(RoleKey) ?? "";
        }

        public static void ClearToken()
        {
            SecureStorage.Default.Remove(TokenKey);
            SecureStorage.Default.Remove(RoleKey);
        }
    }
}
