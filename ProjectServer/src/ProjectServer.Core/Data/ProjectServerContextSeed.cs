using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectServer.Core.Data
{
    public class ProjectServerContextSeed
    {
        public static async Task SeedAsync(ProjectServerContext projectServerContext)
        {
            if (!projectServerContext.Users.Any())
            {
                projectServerContext.Users.AddRange(GetPreconfiguredUsers());
                await projectServerContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<IdentityUser> GetPreconfiguredUsers()
        {
            return new List<IdentityUser>()
            {
                new IdentityUser() { UserName = "user1", NormalizedUserName = "USER1", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456a", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user2", NormalizedUserName = "USER2", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456b", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user3", NormalizedUserName = "USER3", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456c", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user4", NormalizedUserName = "USER4", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456d", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user5", NormalizedUserName = "USER5", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456e", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user6", NormalizedUserName = "USER6", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456f", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user7", NormalizedUserName = "USER7", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456g", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user8", NormalizedUserName = "USER8", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456h", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user9", NormalizedUserName = "USER9", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456j", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
                new IdentityUser() { UserName = "user10", NormalizedUserName = "USER10", EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAENZLYrblYrmmtL1D8DXTIgRAyItUp2C0JuCjYai0ye+r3uLLFF0AsBWw52TogykoZw==", SecurityStamp = "IZ3X7AO2D57SSEQCZBVYC273AYLJAOEQ", ConcurrencyStamp = "0a312df0-78b6-42e0-87a0-16aa2644456k", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false, AccessFailedCount = 0 },
            };
        }
    }
}
