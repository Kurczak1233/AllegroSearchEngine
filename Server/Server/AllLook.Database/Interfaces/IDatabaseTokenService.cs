using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLook.Database.Interfaces
{
    public interface IDatabaseTokenService
    {
        public Token GetToken();
        public void AddToken(Token token) ;
        public void DropToken() ;
    }
}
