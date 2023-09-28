using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace twoChapter.IServices
{
    public interface ILogOnRepository
    {
        dynamic VerifyCode();
    }
}
