using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DisplayDiff.Data;
using DisplayDiff.Models;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DisplayDiffContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DisplayDiffContext>>()))
        {
            // Look for any displays.
            if (context.Display.Any())
            {
                return;   // DB has been seeded
            }
            context.Display.AddRange(
                new Display
                {
                    Name = "G3223Q",
                    Company = "Dell",
                    VerticalResolution = 2160,
                    HorizontalResolution = 3840,
                    AdaptiveSync = "G-Sync Compatible",
                    PanelType = "IPS",
                    DiagonalLength = 32,
                    RefreshRate = 144,
                    FullSpecsURL = "https://www.dell.com/en-us/shop/dell-32-4k-uhd-gaming-monitor-g3223q/apd/210-bdbk/monitors-monitor-accessories"
                }
            );
            context.SaveChanges();
        }
    }
}

