using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace ReverseMarketPlace.Common.Extensions
{
    /// <summary>
    /// Extensions for Enum
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the value of description attribute for one enum value
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Value of description attribute</returns>
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Gets the value of display attribute for one enum value
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Value of display attribute</returns>
        public static string GetDisplay(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<DisplayAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
