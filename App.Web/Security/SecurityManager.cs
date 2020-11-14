using System.Security.Cryptography;
using System.Text;

namespace App.Web.Security
{
    public class SecurityManager
    {
         private HashAlgorithm _hashAlgorithm;

        public SecurityManager(HashAlgorithm hashAlgorithm)
        {
            this._hashAlgorithm = hashAlgorithm;
        }

         public string CriptografaSenha(string senha)
        {
            var encodingValor = Encoding.UTF8.GetBytes(senha);
            var senhaEncriptada = _hashAlgorithm.ComputeHash(encodingValor);
            var sb = new StringBuilder();
            foreach (var caracter in senhaEncriptada)
            {
                sb.Append(caracter.ToString("X2"));
            }
            
            return sb.ToString();
        }

        public bool ValidaSenha(string senhaDigitada, string senhaCadastrada)
        {
            return CriptografaSenha(senhaDigitada) == senhaCadastrada;
            //return senhaDigitada== senhaCadastrada;
        }
    }
}
