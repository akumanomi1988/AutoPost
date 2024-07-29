using System;
using AutoMapper;
using AutoPost.Domain.Models;
using AutoPost.Presentation.Desktop.ViewModel;

namespace AutoPost.Presentation.Desktop
{
    public  class MapConfig:Profile
    {
        public MapConfig()
        {
                CreateMap<PostSettings, PostData>();
                CreateMap<PostData, PostSettings>();
        }
    }
}
