using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Contracts.CrossCutting
{
    public interface IHashGenerator
    {
        byte[] GetRandomSalt();
        string GetHash(string input, byte[] salt);
    }
}
