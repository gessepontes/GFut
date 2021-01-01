using GFut.Application.Interfaces;
using System;

namespace GFut.Application.Services
{
    public class PageAppService : IPageAppService
    {
        public PageAppService()
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
