namespace HiRezApi.Common
{
    using System;

    public interface ITimeStampProvider
    {
        DateTime ProvideTime();
    }
}