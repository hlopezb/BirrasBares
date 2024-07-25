using System;
using System.Collections.Generic;
using System.Linq;

namespace BirrasBares.Enums
{
    public enum DiaSemana
    {
        Lunes = 1,
        Martes = 2,
        Miércoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sábado = 6,
        Domingo = 7
    }

    public static class DiasSemanaHelper
    {
        public static IEnumerable<DiaSemana> GetAllDias()
        {
            return Enum.GetValues(typeof(DiaSemana)).Cast<DiaSemana>();
        }

        public static string GetNombreDia(DiaSemana dia)
        {
            return dia.ToString();
        }

        public static string GetNombreDia(int numeroDia)
        {
            if (Enum.IsDefined(typeof(DiaSemana), numeroDia))
            {
                return ((DiaSemana)numeroDia).ToString();
            }
            throw new ArgumentOutOfRangeException(nameof(numeroDia), "Número de día no válido");
        }

        public static int GetNumeroDia(DiaSemana dia)
        {
            return (int)dia;
        }

        public static DiaSemana GetDiaSemana(int numeroDia)
        {
            if (Enum.IsDefined(typeof(DiaSemana), numeroDia))
            {
                return (DiaSemana)numeroDia;
            }
            throw new ArgumentOutOfRangeException(nameof(numeroDia), "Número de día no válido");
        }

        public static DiaSemana GetDiaSemana(string nombreDia)
        {
            if (Enum.TryParse<DiaSemana>(nombreDia, true, out var dia))
            {
                return dia;
            }
            throw new ArgumentException("Nombre de día no válido", nameof(nombreDia));
        }
    }
}