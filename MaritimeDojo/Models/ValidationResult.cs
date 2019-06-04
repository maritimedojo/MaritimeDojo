using System;

namespace MaritimeDojo.Models
{
    public enum ValidationResult
    {
        Default = 0,
        MoreThanOneDay = 1,
        ToBeforeFrom = 2,
        OutsideWorkingHours = 4,
        TooLong = 8,
        Conflicting = 16,
        LecturerDoesNotExist = 32,
        HallDoesNotExist = 64,
        Ok = 128
    }
}