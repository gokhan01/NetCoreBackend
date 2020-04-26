using System.Runtime.Serialization;

namespace NetCoreBackend.BLL.Constants
{
    internal static class Messages
    {
        internal static string Added = "Kaydedildi";
        internal static string Updated = "Güncellendi";
        internal static string Deleted = "Silindi";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "Şifre hatalı";
        internal static string SuccessfulLogin = "Sisteme giriş başarılı";
        internal static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        internal static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        internal static string AccessTokenCreated = "Access Token oluşturuldu";
        internal static string AuthorizationDenied = "Yetkiniz yok";
    }
}
