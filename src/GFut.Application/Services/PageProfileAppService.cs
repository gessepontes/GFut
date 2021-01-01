using GFut.Application.Interfaces;
using System;

namespace GFut.Application.Services
{
    public class PageProfileAppService : IPageProfileAppService
    {
        public PageProfileAppService()
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
