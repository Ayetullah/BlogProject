using BlogP.Web.Models;

namespace BlogP.Web.ResultMessages
{
    public static class Messages
    {
        public static string GetToastMessage(string title, ProcessType type)
        {
            switch (type)
            {
                case ProcessType.Add:
                    return $"{title} başarılı bir şekilde eklenmiştir.";
                case ProcessType.Update:
                    return $"{title} başarılı bir şekilde güncellenmiştir.";
                case ProcessType.Delete:
                    return $"{title} başarılı bir şekilde silinmiştir.";
                default:
                    return $"İşlem başarılı bir şekilde gerçekleşmiştir.";
            }
        }
    }
}
