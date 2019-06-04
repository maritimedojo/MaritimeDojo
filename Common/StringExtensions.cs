namespace Common
{
    public static class StringExtensions
    {
        public static string GetWordFromText(this string input, int wordNumberToFind)
        {
            // TODO
            // Implement GetWordFromText extension method:
            // idea is to return a specific work of an input text. Words are separated by space (' ').
            // Examples:-
            // - GetWordFromText("one two three", 2)
            //   Should return "two"
            //
            // - GetWordFromText("one;two three", 2)
            //   Should return "three"
            //
            // - GetWordFromText("one", 1)
            //   Should return "one"
            //
            // #### Be aware of ####
            //
            // When input parameter 'wordNumberToFind' is less than 1, the method should throw ArgumentOutOfRangeException. 
            // When input text does not have enough words('GetWordFromText("one", 2)'), method should throw 'ArgumentException'. 
            // When input is null method should throw 'ArgumentNullException'.
            // 
            // The method should ignore all spaces at the beginning and at the end of the input text.

            return string.Empty;
        }

        public static string Reverse(this string input)
        {
            // TODO
            // Implement Reverse extension method:
            // idea is to return a reversed string of the passed input value.
            // Examples:-
            // - Reverse("one")
            //   Should return "eno"
            //
            // - Reverse("abcd dcba")
            //   Should return "abcd dcba"
            //
            // #### Be aware of ####
            //
            // When input is null method should throw 'ArgumentNullException'. 
            // Method should return empty string, if empty string is passed as an input parameter. 

            return string.Empty;
        }
    }
}