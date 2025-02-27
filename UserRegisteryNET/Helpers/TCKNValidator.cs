namespace UserRegisteryNET.Helpers
{
    public static class TCKNValidator
    {
        public static bool IsValidTCKN(string tckn)
        {
            if (string.IsNullOrWhiteSpace(tckn) || tckn.Length != 11 || !long.TryParse(tckn, out _))
                return false;

            int[] digits = tckn.Select(c => c - '0').ToArray();

            // First digit must not be 0
            if (digits[0] == 0)
                return false;

            // Checksum Algorithm
            int oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int evenSum = digits[1] + digits[3] + digits[5] + digits[7];

            int tenthDigit = ((oddSum * 7) - evenSum) % 10;
            if (tenthDigit != digits[9])
                return false;

            int totalSum = oddSum + evenSum + digits[9];
            int eleventhDigit = totalSum % 10;

            return digits[10] == eleventhDigit;
        }
    }
}