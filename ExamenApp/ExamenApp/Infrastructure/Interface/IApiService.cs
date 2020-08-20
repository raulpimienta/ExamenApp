using Fusillade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenApp.Infrastructure.Interface
{
    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
