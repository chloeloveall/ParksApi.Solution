using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : IdentityDbContext
  {
    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options) { }
    
    public DbSet<Park> Parks { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, ParkName = "Yellowstone National Park", ParkState = "Wyoming", ParkDescription = "Yellowstone National Park is a nearly 3,500-sq.-mile wilderness recreation area atop a volcanic hot spot. Mostly in Wyoming, the park spreads into parts of Montana and Idaho too. Yellowstone features dramatic canyons, alpine rivers, lush forests, hot springs and gushing geysers, including its most famous, Old Faithful. It's also home to hundreds of animal species, including bears, wolves, bison, elk and antelope.", ParkCategory = "National" },
          new Park { ParkId = 2, ParkName = "Yosemite National Park", ParkState = "California", ParkDescription = "Yosemite National Park is in California’s Sierra Nevada mountains. It’s famed for its giant, ancient sequoia trees, and for Tunnel View, the iconic vista of towering Bridalveil Fall and the granite cliffs of El Capitan and Half Dome. In Yosemite Village are shops, restaurants, lodging, the Yosemite Museum and the Ansel Adams Gallery, with prints of the photographer’s renowned black-and-white landscapes of the area.", ParkCategory = "National" },
          new Park { ParkId = 3, ParkName = "Lake Sammamish State Park", ParkState = "Washington", ParkDescription = "Lake Sammamish State Park is a park at the south end of Lake Sammamish, in King County, Washington, United States. The park, which is administered by the Washington State Park System, covers an area of 512 acres and has 6,858 feet of waterfront; Issaquah Creek meets with Lake Sammamish within the park.", ParkCategory = "State" },
          new Park { ParkId = 4, ParkName = "Zion National Park", ParkState = "Utah", ParkDescription = "Zion National Park is a southwest Utah nature preserve distinguished by Zion Canyon’s steep red cliffs. Zion Canyon Scenic Drive cuts through its main section, leading to forest trails along the Virgin River. The river flows to the Emerald Pools, which have waterfalls and a hanging garden. Also along the river, partly through deep chasms, is Zion Narrows wading hike.", ParkCategory = "National" },
          new Park { ParkId = 5, ParkName = "Cape Lookout State Park", ParkState = "Oregon", ParkDescription = "Cape Lookout State Park is a state park on Cape Lookout in the U.S. state of Oregon. It is located in Tillamook County, south of the city of Tillamook, on a sand spit between Netarts Bay and the Pacific Ocean.", ParkCategory = "State" }
        );

        builder.Entity<Review>()
        .HasData(
          new Review { ReviewId = 1, Rating = 5, ReviewTitle = "I <3 Yellowstone", ReviewBody = "Yellowstone is cool. I'd like to visit again soon!", ParkId = 1 },
          new Review { ReviewId = 2, Rating = 1, ReviewTitle = "Yellowstone :(", ReviewBody = "Yellowstone is not cool. I would NOT like to visit again!", ParkId = 1 },
          new Review { ReviewId = 3, Rating = 3, ReviewTitle = "Pleasant Lake Experience", ReviewBody = "Lake Sammamish is nice, but not too exciting", ParkId = 3 },
          new Review { ReviewId = 4, Rating = 5, ReviewTitle = "Splendid Zion!", ReviewBody = "I absolutely loved Zion and can;t wait to go back! Summers are a bit hot, but the scenery is worth it.", ParkId = 4 }
        );
    }
  } 
}