using System;

namespace LeanKit.ReleaseManager.Models
{
    public interface IParsePlannedReleaseDate
    {
        DateTime ParsePlannedDate(NewReleaseViewModel release);
    }
}