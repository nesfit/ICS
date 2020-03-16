using System;

namespace WebCalculator.Models
{
    public static class ApplicationVersion
    {
        public static Version Current { get; } = typeof(ApplicationVersion).Assembly.GetName().Version;
    }
}
