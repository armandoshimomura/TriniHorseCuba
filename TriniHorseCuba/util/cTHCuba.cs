using TriniHorseCuba.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class cTHCuba
{
    public string Encriptar(string pTexto)
    {
        string Key = "<RSAKeyValue><Modulus>usUc+6vLgrWrQuJ9SP5UJDsdJagLNUKtCJOoacJdYEzGeksCB3avb68smCvW4IgUxPBYEidXSEA0HQ4h58kqdJ+VtsWmT2FFCBdAJnq22qeTbbVJswZseVqDWptFieVf1zFOQ8WNnnlMm5AbZNhnRYJ+XIHpOked6H7ABIIQ3tc=</Modulus><Exponent>AQAB</Exponent><P>9GBIJRPWQYa5wmwYXXyZSPMpCj0Ao72LLF2op03L1GtCzAcfWavM0QcfVLK+2LEPi2+oUTSA4SPoy2d6+jeYfw==</P><Q>w6dfjyKCcaQaEvtvra+GtLuWO80Bbq8PFtIev8UfZD160inNMIYomiifDcW5634e45re+iJGwVFu6TJz/gFNqQ==</Q><DP>l0ViY1E8N6OmKWuwSW5vlHCw3t2UH8ec9wGi/K1zlzIuTw25olBuoJXAFzXuXUR9UtrzXhEaFkOcPwz3Wxw/EQ==</DP><DQ>DCaK0rLL8w7D58Xhq6Go9fRoYhJbMmqAv2QRMMunJWyEAiVCbu8F+nznU82hvDQ66tulWVdjmYHbJ3RQq8ec8Q==</DQ><InverseQ>SIOiPZBxHdc+9GpDUmyijcXZ5/9Sr4o0XrhaUK1Itykdw+ztO3sWwHCi53PgZR+5n0OzkWZzzfjJuO3fGxdGMw==</InverseQ><D>djYcSg5KGMjzRLolofWXO/dOU28w6Nzyt+L9TTL/9tuhI/YlqqOsFnxBNW9J6YM34g5dL+BGlixMz7cKLrJcc62rdE4NF4zKeRjUCjN/EvZFD0LKhS1qXcFd3GXFRDj9CuraP0QKl82e5z7jR5jkh3aAcgrAVl/CdSH9SNSeJYE=</D></RSAKeyValue>";
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(Key);
        byte[] Value = Encoding.UTF8.GetBytes(pTexto);
        byte[] EncryptValue = rsa.Encrypt(Value, false);

        return Convert.ToBase64String(EncryptValue);
    }

    public string Desencriptar(string pTexto)
    {
        string Key = "<RSAKeyValue><Modulus>usUc+6vLgrWrQuJ9SP5UJDsdJagLNUKtCJOoacJdYEzGeksCB3avb68smCvW4IgUxPBYEidXSEA0HQ4h58kqdJ+VtsWmT2FFCBdAJnq22qeTbbVJswZseVqDWptFieVf1zFOQ8WNnnlMm5AbZNhnRYJ+XIHpOked6H7ABIIQ3tc=</Modulus><Exponent>AQAB</Exponent><P>9GBIJRPWQYa5wmwYXXyZSPMpCj0Ao72LLF2op03L1GtCzAcfWavM0QcfVLK+2LEPi2+oUTSA4SPoy2d6+jeYfw==</P><Q>w6dfjyKCcaQaEvtvra+GtLuWO80Bbq8PFtIev8UfZD160inNMIYomiifDcW5634e45re+iJGwVFu6TJz/gFNqQ==</Q><DP>l0ViY1E8N6OmKWuwSW5vlHCw3t2UH8ec9wGi/K1zlzIuTw25olBuoJXAFzXuXUR9UtrzXhEaFkOcPwz3Wxw/EQ==</DP><DQ>DCaK0rLL8w7D58Xhq6Go9fRoYhJbMmqAv2QRMMunJWyEAiVCbu8F+nznU82hvDQ66tulWVdjmYHbJ3RQq8ec8Q==</DQ><InverseQ>SIOiPZBxHdc+9GpDUmyijcXZ5/9Sr4o0XrhaUK1Itykdw+ztO3sWwHCi53PgZR+5n0OzkWZzzfjJuO3fGxdGMw==</InverseQ><D>djYcSg5KGMjzRLolofWXO/dOU28w6Nzyt+L9TTL/9tuhI/YlqqOsFnxBNW9J6YM34g5dL+BGlixMz7cKLrJcc62rdE4NF4zKeRjUCjN/EvZFD0LKhS1qXcFd3GXFRDj9CuraP0QKl82e5z7jR5jkh3aAcgrAVl/CdSH9SNSeJYE=</D></RSAKeyValue>";
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(Key);
        byte[] Value = Convert.FromBase64String(pTexto);
        byte[] DecryptValue = rsa.Decrypt(Value, false);

        return Encoding.UTF8.GetString(DecryptValue);
    }

    public List<BEPaginado> ObtenerPaginado(decimal TotalRegistros, decimal NroFilasXpagina, int NroPagina, string Tipo)
    {
        int Aux = -2;
        List<BEPaginado> lstDatos = new List<BEPaginado>();
        BEPaginado SimPrimero = new BEPaginado();
        BEPaginado SimAnterior = new BEPaginado();
        BEPaginado SimSiguiente = new BEPaginado();
        BEPaginado SimUltimo = new BEPaginado();

        decimal dcPaginas = TotalRegistros / NroFilasXpagina;
        int PaginasTotal = Convert.ToInt32(Math.Ceiling(dcPaginas));

        if (NroPagina <= 0) { NroPagina = 1; }
        if (NroPagina >= PaginasTotal) { NroPagina = PaginasTotal; }

        SimPrimero.Url = "1";
        SimPrimero.Valor = Tipo == "Adm" ? "Primera" : "<i class='fa fa-angle-double-left'></i>";

        SimAnterior.Url = (NroPagina - 1).ToString();
        SimAnterior.Valor = Tipo == "Adm" ? "Anterior" : "<i class='fa fa-angle-left'></i>";

        if (NroPagina == 1)
        {
            SimPrimero.Estilo = "disabled";
            SimAnterior.Estilo = "disabled";
        }

        lstDatos.Add(SimPrimero);
        lstDatos.Add(SimAnterior);

        // -------------------------------------
        // Creacion de la paginación - INI
        // -------------------------------------

        for (int i = 1; i <= 5; i++)
        {
            BEPaginado Pagina = new BEPaginado();
            int iPagina = NroPagina + Aux;

            if (iPagina < 1 || iPagina > PaginasTotal) { Pagina.Estilo = "d-none"; }
            if (iPagina == NroPagina) { Pagina.Estilo = "active"; }

            Pagina.Url = iPagina.ToString();
            Pagina.Valor = iPagina.ToString();

            lstDatos.Add(Pagina);

            Aux = Aux + 1;
        }

        // -------------------------------------
        // Creacion de la paginación - FIN
        // -------------------------------------

        SimSiguiente.Url = (NroPagina + 1).ToString();
        SimSiguiente.Valor = Tipo == "Adm" ? "Siguiente" : "<i class='fa fa-angle-right'></i>";

        SimUltimo.Url = PaginasTotal.ToString();
        SimUltimo.Valor = Tipo == "Adm" ? "Última" : "<i class='fa fa-angle-double-right'></i>";

        if (NroPagina == PaginasTotal)
        {
            SimSiguiente.Estilo = "disabled";
            SimUltimo.Estilo = "disabled";
        }

        lstDatos.Add(SimSiguiente);
        lstDatos.Add(SimUltimo);

        return lstDatos;
    }

    public DateTime FormatoUS(string Fecha)
    {
        string[] dato = Fecha.Split('/');
        string FechaUS = dato[1] + "/" + dato[0] + "/" + dato[2];

        return DateTime.Parse(FechaUS);
    }

    public string FormatoFecha(string FechaHora, string TipoFormato, string TipoRespuesta)
    {
        string sFechaCompleta = "";
        string sFecha = "";
        string sHora = "";

        if (FechaHora != "")
        {
            DateTime oDate = DateTime.Parse(FechaHora);

            string Dia = oDate.Day.ToString("00");
            string Mes = oDate.Month.ToString("00");
            string Año = oDate.Year.ToString();
            string Hora = oDate.Hour.ToString("00");
            string Minuto = oDate.Minute.ToString("00");
            string Segundo = ":00";

            sHora = Hora + ":" + Minuto + Segundo;

            switch (TipoFormato)
            {
                case "d/m/Y":
                    sFecha = Dia + "/" + Mes + "/" + Año;
                    break;
                case "YMD":
                    sFecha = Año + Mes + Dia;
                    break;
                case "Y-M-D":
                    sFecha = Año + "-" + Mes + "-" + Dia;
                    break;
                default:
                    break;
            }

            sFechaCompleta = sFecha + " " + sHora;
        }

        switch (TipoRespuesta)
        {
            case "F":
                return sFecha;                
            case "H":
                return sHora;                
            case "C":
                return sFechaCompleta;
        }

        return string.Empty;
    }
}