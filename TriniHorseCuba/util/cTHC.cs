using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class cTHC
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

    public string NombreMes(int iNumeroMes, string idioma)
    {
        //parámetro idioma puede ser "es" o "en"
        string NombreCompletoMes = new DateTime(DateTime.Now.Year, iNumeroMes, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture(idioma));
        string sNombreMesCorto = NombreCompletoMes.Substring(0,3);

        return sNombreMesCorto;
    }

    public string NombreDia(int iNumeroDia, string idioma)
    {
        //parámetro idioma puede ser "es" o "en"
        string DiaES = "";
        string DiaEN = "";
        string Dia = "";
        
        switch (iNumeroDia)
        {
            case 1:
                DiaES = "lunes";
                DiaEN = "monday";
                break;
            case 2:
                DiaES = "martes";
                DiaEN = "tuesday";
                break;
            case 3:
                DiaES = "miercoles";
                DiaEN = "wednesday";
                break;
            case 4:
                DiaES = "jueves";
                DiaEN = "thursday";
                break;
            case 5:
                DiaES = "viernes";
                DiaEN = "friday";
                break;
            case 6:
                DiaES = "sabado";
                DiaEN = "saturday";
                break;
            case 7:
                DiaES = "domingo";
                DiaEN = "sunday";
                break;
        }

        switch (idioma)
        {
            case "es":
                Dia = DiaES;
                break;
            case "en":
                Dia = DiaEN;
                break;
        }

        return Dia.Substring(0,3) + ".";
    }

    public int NumeroDia(string sNombreDia)
    {
        int Dia = 0;

        switch (sNombreDia)
        {
            case "lunes":
            case "monday":
                Dia = 1;
                break;
            case "martes":
            case "tuesday":
                Dia = 2;
                break;
            case "miercoles":
            case "wednesday":
                Dia = 3;
                break;
            case "jueves":
            case "thursday":
                Dia = 4;
                break;
            case "viernes":
            case "friday":
                Dia = 5;
                break;
            case "sabado":
            case "saturday":
                Dia = 6;
                break;
            case "domingo":
            case "sunday":
                Dia = 7;
                break;
        }

        return Dia;
    }

    public string claseMsj(string Etiqueta)
    {
        string Clase = "";

        switch (Etiqueta)
        {
            case "primary":
                Clase = "alert alert-primary";
                break;
            case "secondary":
                Clase = "alert alert-secondary";
                break;
            case "success":
                Clase = "alert alert-success";
                break;
            case "danger":
                Clase = "alert alert-danger";
                break;
            case "warning":
                Clase = "alert alert-warning";
                break;
            case "info":
                Clase = "alert alert-info";
                break;
            case "light":
                Clase = "alert alert-light";
                break;
            case "dark":
                Clase = "alert alert-dark";
                break;
            default:
                break;
        }

        return Clase;
    }
}