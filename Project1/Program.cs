using System;
//Allows StringBuilder
using System.Text;

public class Program
{
    // changing of the notes
    /*
Design and implement a program that converts a sentence entered by the user into pig latin.
    */
    public static void Main()
    {
        Console.WriteLine("Enter a word or phrase.");
        string input = Console.ReadLine();
        //Turns input into individual words
        string[] words = input.Split(' ');
        StringBuilder pigLatinPhrase = new StringBuilder();
        //Applies method to each word
        foreach (string word in words){
            pigLatinPhrase.Append(PigLatin(word)).Append(" ");
        }
        Console.WriteLine("Pig Latin: " + pigLatinPhrase.ToString().Trim());
        //Check for encoding
        Console.WriteLine("Would you like to encode? (yes/no)");
        string encodeChoice = Console.ReadLine().ToLower();
        if (encodeChoice == "yes")
        {
            //Get values
            Random random = new Random();
            int shift = random.Next(-10, 11);
            Console.WriteLine("Enter text to encode:");
            string encodeValue = Console.ReadLine();
            Console.WriteLine($"Using shift: {shift}");

            //Encode
            StringBuilder encryptedPhrase = new StringBuilder();
            string[] encodeWords = encodeValue.Split(' ');

            //Loop through
            foreach (string encodeWord in encodeWords){
                encryptedPhrase.Append(EncodeWord(encodeWord, shift)).Append(" ");
            }
            //Display
            Console.WriteLine("Encrypted Text: " + encryptedPhrase.ToString().Trim());
        }
    }

    static bool IsVowel(char c){
        //Finds vowls
        char lowerC = char.ToLower(c);
        return lowerC == 'a'|| lowerC == 'e' || lowerC == 'i' || lowerC == 'o' || lowerC == 'u';
    }

    static string PigLatin(string s){
        //Finds and stores punctiation
        char punctuation = '\0';
        if (char.IsPunctuation(s[s.Length - 1])){
            punctuation = s[s.Length - 1];
            s = s.Substring(0, s.Length - 1);
        }

        bool isCapitalized = char.IsUpper(s[0]);
        s = s.ToLower();
        //One character
        if (s.Length == 1){
            string result = IsVowel(s[0]) ? s + "way" : s + "ay";
            if (isCapitalized) result = char.ToUpper(result[0]) + result.Substring(1);
            if (punctuation != '\0') result += punctuation;
            return result;
        }
        //Finds first vowel
        int firstVowelIndex = -1;
        for (int i = 0; i < s.Length; i++){
            if (IsVowel(s[i])){
                firstVowelIndex = i;
                break;
            }
        }
        //Combines using logic
        string pigLatinWord;
        if (firstVowelIndex == 0){
            pigLatinWord = s + "way";
        }
        else if (firstVowelIndex == -1){
            pigLatinWord = s + "ay";
        }
        else{
            pigLatinWord = s.Substring(firstVowelIndex) + s.Substring(0, firstVowelIndex) + "ay";
        }

        if (isCapitalized){
            pigLatinWord = char.ToUpper(pigLatinWord[0]) + pigLatinWord.Substring(1);
        }

        if (punctuation != '\0'){
            pigLatinWord += punctuation;
        }
        return pigLatinWord;
    }
    public static string EncodeWord(string word, int shift)
    {
        StringBuilder encodedWord = new StringBuilder();
        //Encode via loop
        foreach (char c in word){
            if (char.IsLetter(c)){
                //Only letters
                char offset = char.IsUpper(c) ? 'A' : 'a';
                //Formula
                char encodedChar = (char)(((c - offset + shift) % 26 + 26) % 26 + offset);
                encodedWord.Append(encodedChar);
            }
            else{
                //Not a letter
                encodedWord.Append(c);
            }
        }
        return encodedWord.ToString();
    }
}
