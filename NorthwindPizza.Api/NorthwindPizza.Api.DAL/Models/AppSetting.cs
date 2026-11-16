// <copyright file="AppSetting.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DAL.Models;

/// <summary>
/// This class represents the AppSetting database entity.
/// </summary>
public partial class AppSetting
{
    /// <summary>
    /// The primary key of the AppSetting entity.
    /// </summary>
    public int SettingId { get; set; }

    /// <summary>
    /// The relevant key of the application setting.
    /// </summary>
    public string SettingKey { get; set; } = string.Empty;

    /// <summary>
    /// The appropriate value of the application setting.
    /// </summary>
    public string? SettingValue { get; set; }
}
