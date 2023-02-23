using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User
{
    public interface ISecurity
    {
        byte[] EncryptStringToBytes(string? plainText);
        string? DecryptStringFromBytes(byte[] cipherText);
        bool IsPasswordValid(string? pass);
        string? GeneratePassword();
        bool IsEmail(string? username);
    }
}
