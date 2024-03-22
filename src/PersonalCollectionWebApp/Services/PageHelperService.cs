using PersonalCollection.Application.Models;
using PersonalCollection.Domain.Entities;
using static PersonalCollection.Domain.Constants;

namespace PersonalCollectionWebApp.Services
{
    public class PageHelperService
    {
        public string GetLocalTime(DateTime dateTime, int timeZoneOffset) => dateTime.Subtract(TimeSpan.FromMinutes(timeZoneOffset)).ToString();

        public string? GetReactionUserName(ApplicationUser? user, string deletedUserName) => user != null ? user.UserName : deletedUserName;

        public string GetTagSearchHref(string tagName)
        {
            return $"/{NavSearch}?{ParameterSearchTag}={tagName}";
        }

        public string GetFontSizeForTag(TagDto tag, int minCount, int maxCount)
        {
            var minFontSize = 12;
            var maxFontSize = 30;

            var fontSize = Scale(tag.Count, minCount, maxCount, minFontSize, maxFontSize);
            return $"font-size: {fontSize}px;";
        }

        private double Scale(int value, int min, int max, int minScale, int maxScale)
        {
            if (min != max) return minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            else return (maxScale + minScale) / 2;
        }
    }
}
