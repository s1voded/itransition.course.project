using PersonalCollection.Application.Interfaces.Services;
using PersonalCollection.Application.Models.Dto;
using static PersonalCollection.Domain.Constants;

namespace PersonalCollection.Application.Services
{
    public class PageHelperService: IPageHelperService
    {
        public string GetLocalTime(DateTime dateTime, int timeZoneOffset) => dateTime.Subtract(TimeSpan.FromMinutes(timeZoneOffset)).ToString();

        public string GetTagSearchHref(string tagName)
        {
            return $"/{NavSearch}?{ParameterSearchTag}={tagName}";
        }

        public double GetFontSizeForTag(TagWithUsedCountDto tag, int minCount, int maxCount)
        {
            int minFontSize = 12, maxFontSize = 30;
            return Scale(tag.Count, minCount, maxCount, minFontSize, maxFontSize);
        }

        private double Scale(int value, int min, int max, int minScale, int maxScale)
        {
            if (min != max) return minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            else return (maxScale + minScale) / 2;
        }
    }
}
