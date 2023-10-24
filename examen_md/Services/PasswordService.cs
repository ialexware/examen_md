using examen_md.Services.Interface;

namespace examen_md.Services
{
    public class PasswordService : IPasswordService
    {
        public PasswordService() { }

        public object FindLongestPassword(string passwords)
        {
            // Inicializar la longitud máxima y la palabra más larga
            int maxLength = -1;
            string longestWord = string.Empty;
            if (!string.IsNullOrEmpty(passwords))
            {
                // La cadena S se puede dividir en palabras dividiéndola y eliminando los espacios
                string[] words = passwords.Split();
                // Recorrer cada palabra y verificar si es una contraseña válida
                foreach (string word in words)
                {
                    if (IsValidPassword(word))
                    {
                        // Actualizar la longitud máxima y la palabra más larga si es necesario
                        if (word.Length > maxLength)
                        {
                            maxLength = word.Length;
                            longestWord = word;
                        }
                    }
                }
            }
            // Devuelve la longitud de la palabra más larga de la cadena que es una contraseña válida 
            // de lo contrario devuelve -1
            return new { longestWord, maxLength };
        }

        private static bool IsValidPassword(string word)
        {
            // a) Debe contener solo caracteres alfanuméricos (a−z, A−Z, 0−9);
            bool onlyleetersAndNumeric = word.All(char.IsLetterOrDigit);
            if (onlyleetersAndNumeric)
            {
                // Contar el número de letras y dígitos en la palabra
                int letters = word.Where(char.IsLetter).ToArray().Length;
                int digits = word.Where(char.IsDigit).ToArray().Length;

                // b) Debe haber un número par de letras;
                // c) Debe haber un número impar de dígitos.
                return (letters % 2 == 0 && digits % 2 == 1) ? true : false;
            }

            return false;
        }

    }
}
