using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class CheckBloodType
    {
        /*Blutgruppe mit Bitmasken überprüfen
        Blutgruppe A 001
        Blutgruppe B 010
        Rhesus +     100
        Kompatibel, wenn der Empfänger die gleichen Merkmale hat wie der Spender oder mehr.
        */

        [Flags]
        public enum BloodAntigens
        {
            None = 0,
            A = 1 << 0,
            B = 1 << 1,
            RhPositive = 1 << 2,
        }

        private static readonly Dictionary<string, BloodAntigens> BloodMap = new Dictionary<string, BloodAntigens>(StringComparer.OrdinalIgnoreCase)
        {
            { "O-", BloodAntigens.None },
            { "O+", BloodAntigens.RhPositive },
            { "A-", BloodAntigens.A },
            { "A+", BloodAntigens.A | BloodAntigens.RhPositive },
            { "B-", BloodAntigens.B },
            { "B+", BloodAntigens.B | BloodAntigens.RhPositive },
            { "AB-", BloodAntigens.A | BloodAntigens.B },
            { "AB+", BloodAntigens.A | BloodAntigens.B | BloodAntigens.RhPositive }
        };

        public static bool IsCompatible(string recipientInput, string donorInput)
        {
            if (BloodMap.TryGetValue(donorInput, out var donor) &&
            BloodMap.TryGetValue(recipientInput, out var recipient))
            {
                return (donor & ~recipient) == 0;
            }
            return false;
        }
    }
}