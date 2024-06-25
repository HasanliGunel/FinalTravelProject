namespace Business.BaseMessages
{
    public static class UIMessages 
    {
        public const string ADDED_MESSAGE = "Məlumat Uğurla əlavə edildi";
        public const string UPDATE_MESSAGE = "Məlumat Uğurla yeniləndi";
        public const string Deleted_MESSAGE = "Məlumat Uğurla Silindi";

        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} boş ola bilməz";
        }

        public static string GetMinLengthMessage(int length, string propName)
        {
            return $"{propName} {length} simvoldan aşağı ola bilməz!";
        }
        public static string GetMaxLengthMessage(int length, string propName)
        {
            return $"{propName} {length} simvoldan yuxarı ola bilməz!";
        }
    }
}
