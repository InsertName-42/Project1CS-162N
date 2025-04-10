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
        Console.WriteLine("Please enter a word or phrase. Press the ENTER key when you're done.");
        string input = Console.ReadLine();
        //Turns input into individual words
        string[] words = input.Split(' ');
        StringBuilder pigLatinPhrase = new StringBuilder();
        //Applies method to each word
        foreach (string word in words){
            pigLatinPhrase.Append(PigLatin(word)).Append(" ");
        }
        Console.WriteLine("Pig Latin: " + pigLatinPhrase.ToString().Trim());
    }

    static bool IsVowel(char c){
        char lowerC = char.ToLower(c);
        return lowerC == 'a'|| lowerC == 'e' || lowerC == 'i' || lowerC == 'o' || lowerC == 'u';
    }

    static string PigLatin(string s){
        char punctuation = '\0';
        if (char.IsPunctuation(s[s.Length - 1])){
            punctuation = s[s.Length - 1];
            s = s.Substring(0, s.Length - 1);
        }

        bool isCapitalized = char.IsUpper(s[0]);
        s = s.ToLower();

        if (s.Length == 1){
            string result = IsVowel(s[0]) ? s + "way" : s + "ay";
            if (isCapitalized) result = char.ToUpper(result[0]) + result.Substring(1);
            if (punctuation != '\0') result += punctuation;
            return result;
        }

        int firstVowelIndex = -1;
        for (int i = 0; i < s.Length; i++){
            if (IsVowel(s[i])){
                firstVowelIndex = i;
                break;
            }
        }

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
}