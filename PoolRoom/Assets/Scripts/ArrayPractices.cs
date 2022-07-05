//Practice: Array Exercises
//Editor: Manu Moral

using UnityEngine;

public class ArrayPractices : MonoBehaviour
{
    [SerializeField] bool _kata1,_kata2,_kata3;
    
    [SerializeField] string _sentence;
    string word = "";
    string[] words;
    int wordCount;

    [SerializeField] int _newNumber;

    void Start()
    {
        //8Kyu
        //Kata1. Convert a string to an array without use "Split":
        if (_kata1) SeparateWords();

        //Kata2. Determine if a number is even or odd:
        if (_kata2) IsEven(_newNumber);

        //Kata3. Convert a Boolean to a String:

    }

    //Kata1:
    private void SeparateWords()
    {
        _sentence += " ";

        for (int i = 0; i < _sentence.Length; i++)
        {
            if (_sentence[i] != ' ')
            {
                word += _sentence[i];
            }
            else
            {
                words = new string[wordCount + 1];
                words[wordCount] = word;
                Debug.Log("The word in the slot " + wordCount + " is: " + words[wordCount]);
                wordCount++;
                word = "";
            }

        }
    }

    //Kata2:
    private bool IsEven(int number)
    {
        if (number % 2 == 0)
        {
            Debug.Log(number + " is Even");
            return true;
        }
        else
        {
            Debug.Log(number + " is Odd");
            return false;
        }
    }
}
