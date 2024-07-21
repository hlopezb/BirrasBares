
namespace BirrasBares.Utilities
{
    /// <summary>
    /// Proporciona métodos de utilidad para operaciones con cadenas de texto.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Devuelve una subcadena segura de la cadena de entrada, evitando excepciones de índice fuera de rango.
        /// </summary>
        /// <param name="input">La cadena de entrada de la cual se extraerá la subcadena.</param>
        /// <param name="maxLength">La longitud máxima de la subcadena a devolver.</param>
        /// <returns>
        /// Una subcadena de la entrada original con una longitud máxima especificada.
        /// Si la entrada es null o vacía, devuelve una cadena vacía.
        /// Si la longitud de la entrada es menor o igual que maxLength, devuelve la entrada completa.
        /// De lo contrario, devuelve una subcadena desde el inicio hasta maxLength.
        /// </returns>
        /// <remarks>
        /// Este método es útil para truncar cadenas de forma segura, especialmente
        /// cuando se trabaja con límites de longitud en campos de base de datos o en la interfaz de usuario.
        /// </remarks>
        /// <example>
        /// <code>
        /// string result = StringUtils.SafeSubstring("Hello, World!", 5);
        /// // result será "Hello"
        /// 
        /// string result2 = StringUtils.SafeSubstring("Short", 10);
        /// // result2 será "Short"
        /// 
        /// string result3 = StringUtils.SafeSubstring(null, 5);
        /// // result3 será una cadena vacía ""
        /// </code>
        /// </example>
        public static string SafeSubstring(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.Length <= maxLength ? input : input.Substring(0, maxLength);
        }
    }
}