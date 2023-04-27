using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace distrito7.core.Interfaces
{
    public interface ISecurityService
    {
        Task<string> Encrypt(string clearText);
        Task<string> Decrypt(string sencrypted);
    }
}