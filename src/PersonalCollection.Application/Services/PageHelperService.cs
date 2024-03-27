using PersonalCollection.Application.Interfaces.Services;
using PersonalCollection.Application.Models.Dto;
using System.Reflection;
using System.Text;
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
            const int minFontSize = 12, maxFontSize = 30;
            return Scale(tag.Count, minCount, maxCount, minFontSize, maxFontSize);
        }

        //https://blazor.radzen.com/export-excel-csv
        public Stream GetFileStream(IQueryable query)
        {
            const string separator = ",";
            var columns = GetProperties(query.ElementType);
            var sb = new StringBuilder();
            foreach (var item in query)
            {
                sb.AppendLine(string.Join(separator, columns.Select(column => $"{GetValue(item, column.Key)}".Trim()).ToArray()));
            }
            return new MemoryStream(UTF8Encoding.Default.GetBytes($"{string.Join(separator, columns.Select(c => c.Key))}{Environment.NewLine}{sb}"));
        }

        private static object GetValue(object target, string name)
        {
            return target.GetType().GetProperty(name).GetValue(target);
        }

        private static IEnumerable<KeyValuePair<string, Type>> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead).Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType));
        }

        private double Scale(int value, int min, int max, int minScale, int maxScale)
        {
            if (min != max) return minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            else return (maxScale + minScale) / 2;
        }
    }
}
