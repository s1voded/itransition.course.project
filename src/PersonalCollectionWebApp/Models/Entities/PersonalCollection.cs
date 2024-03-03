using Microsoft.Extensions.Hosting;
using PersonalCollectionWebApp.Data;
using System.Reflection.Metadata;

namespace PersonalCollectionWebApp.Models.Entities
{
    public class PersonalCollection
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Required foreign key property
        public ApplicationUser User { get; set; } = null!; // Required reference navigation to principal
        public int? ThemeId { get; set; }
        public Theme? Theme { get; set; }
        public ICollection<Item> Items { get; } = []; // Collection navigation containing dependents
        public string Name { get; set; }
        public string Description { get; set; }
        public CustomFieldsSettings? CustomFieldsSettings { get; set; }
    }

    public class CustomFieldsSettings
    {
        #region custom-string
        public bool CustomString1Enable { get; set; }
        public string? CustomString1Name { get; set; }
        public bool CustomString2Enable { get; set; }
        public string? CustomString2Name { get; set; }
        public bool CustomString3Enable { get; set; }
        public string? CustomString3Name { get; set; }
        #endregion

        #region custom-int
        public bool CustomInt1Enable { get; set; }
        public string? CustomInt1Name { get; set; }
        public bool CustomInt2Enable { get; set; }
        public string? CustomInt2Name { get; set; }
        public bool CustomInt3Enable { get; set; }
        public string? CustomInt3Name { get; set; }
        #endregion

        #region custom-text
        public bool CustomText1Enable { get; set; }
        public string? CustomText1Name { get; set; }
        public bool CustomText2Enable { get; set; }
        public string? CustomText2Name { get; set; }
        public bool CustomText3Enable { get; set; }
        public string? CustomText3Name { get; set; }
        #endregion

        #region custom-bool
        public bool CustomBool1Enable { get; set; }
        public string? CustomBool1Name { get; set; }
        public bool CustomBool2Enable { get; set; }
        public string? CustomBool2Name { get; set; }
        public bool CustomBool3Enable { get; set; }
        public string? CustomBool3Name { get; set; }
        #endregion

        #region custom-date
        public bool CustomDate1Enable { get; set; }
        public string? CustomDate1Name { get; set; }
        public bool CustomDate2Enable { get; set; }
        public string? CustomDate2Name { get; set; }
        public bool CustomDate3Enable { get; set; }
        public string? CustomDate3Name { get; set; }
        #endregion
    }
}
