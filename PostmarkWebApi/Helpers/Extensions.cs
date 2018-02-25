using PostmarkWebApi.BusinessLogic;

namespace PostmarkWebApi.Helpers
{
    internal static class Extensions
    {
        public static bool IsSuccess(this ProcessingStatus status)
        {
            return status == ProcessingStatus.Success;
        }

        public static bool IsFail(this ProcessingStatus status)
        {
            return !IsSuccess(status);
        }
    }
}