using PersonalCollection.Application.Models.Dto;

namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IPageHelperService
    {
        public string GetLocalTime(DateTime dateTime, int timeZoneOffset);
        public string GetTagSearchHref(string tagName);
        public double GetFontSizeForTag(TagWithUsedCountDto tag, int minCount, int maxCount);

    }
}
