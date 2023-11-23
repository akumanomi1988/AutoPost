using AutoPost.VideoUploader.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoUploader.Interfaces
{
    public interface IAuthenticationProvider
    {
            Task<object> GetCredentialsAsync();
       
    }
}
