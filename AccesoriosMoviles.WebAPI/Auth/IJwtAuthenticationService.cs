using AccesoriosMoviles.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoriosMoviles.WebAPI.Auth
{
     public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
