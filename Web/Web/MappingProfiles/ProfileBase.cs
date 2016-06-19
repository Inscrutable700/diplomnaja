using AutoMapper;
using System;

namespace Web.MappingProfiles
{
    public abstract class ProfileBase : Profile
    {
        public override string ProfileName
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}