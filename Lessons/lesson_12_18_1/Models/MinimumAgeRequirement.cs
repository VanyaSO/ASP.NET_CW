using Microsoft.AspNetCore.Authorization;

namespace lesson_12_18_1.Models;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int MinimumAge { get; }
 
 
    public MinimumAgeRequirement(int minimumAge)
    {
        MinimumAge = minimumAge;
    }
}