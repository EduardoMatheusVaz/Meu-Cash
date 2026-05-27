using System.Globalization;
using System.Text;

namespace MeuCash.Core.Extensions
{
    public static class StringExtensions
    {
        //Eu vou retornar uma nova string com os valores da passada no parametro
        //Em seguida vou deixa-la toda em minusculo, separar os acentos dos caracteres
        //E vou filtrar cada caractere da string, conferindo o tipo, se é letra, numero, simbolo
        //Nisso, vou manter somente os caracteres que forem diferentes de caracteres diacríticos separados
        //E como o Where me retorna um array de char, eu converto o array de char em uma string
        public static string NormalizaTextos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return new string(texto
                .ToLower()
                .Normalize(NormalizationForm.FormD)
                .Where(x => char.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark)
                .ToString());
        }

    }
}
