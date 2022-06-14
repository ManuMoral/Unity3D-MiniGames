//Unity Exercises
//Editor: Manu Moral

using UnityEngine;

namespace UnityLessons
{
    public class MethodsExercises : MonoBehaviour
    {
        [SerializeField] int _task, _num1, _num2;
        [SerializeField] string _word, _sentence;
        string word = "";
        string[] words;
        int wordCount;
        [SerializeField] int[] _untidyNumbers;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (_task)
                {
                    case 1: //Sum
                        Debug.Log("The sum of both is:: " + Sum(_num1, _num2));
                        break;
                    case 2: //Multiply
                        Debug.Log("The result of multiplying both is: " + Multiply(_num1, _num2));
                        break;
                    case 3: //HardCore Multiply
                        Debug.Log("The result of multiplying both is: " + HardcoreMultiply(_num1, _num2));
                        break;
                    case 4: //Power of num1
                        Debug.Log("The result of raising the first number to the second is: " + PowerOfNum1(_num1, _num2));
                        break;
                    case 5: //Separate the sentence in an Array of words
                        SeparateWords();
                        break;
                    case 6: //Repeat de _word to _num1 Times
                        Debug.Log("The word " + _word + " is repeated " + _num1 + " times: " + RepeatString(_word, _num1));
                        break;
                    case 7: //Prime number?
                        IsPrime(_num1);
                        break;
                    case 8: //Even or Odd
                        IsEven(_num1);
                        break;
                    case 9:
                        OrganizeArray(_untidyNumbers);
                        break;
                    default:
                        break;
                }
            }
        }

        int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        int HardcoreMultiply(int num1, int num2)
        {
            int result = 0;

            for (int i = 0; i < num1; i++)
            {
                result += num2;
            }

            return result;
        }

        int PowerOfNum1(int num1, int num2)
        {
            int result = num1;

            for (int i = 0; i < num2 - 1; i++)
            {
                result *= num1;
            }

            return result;
        }

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

        string RepeatString(string word, int times)
        {
            string result = " ";

            for (int i = 0; i < times; i++)
            {
                result += word;
                result += " ";
            }

            return result;
        }

        void IsPrime(int number)
        {
            int divCount = 0;

            for (int i = 1; i < number + 1; i++)
            {
                if (number % i == 0)
                {
                    divCount++;
                }
            }

            if (divCount <= 2) Debug.Log("The number " + number + " is Prime.");
            else Debug.Log("The number " + number + " is not Prime.");
        }


        private bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                Debug.Log("The number " + number + " is Even");
                return true;
            }
            else
            {
                Debug.Log("The number " + number + " is Odd");
                return false;
            }
        }

        private void OrganizeArray(int[] untidyNumbers)
        {
            int currentNumber = 0;
            int currentHighestNumber = 0;
            int currentLowestNumber = 0;
            for (int i = 0; i < untidyNumbers.Length; i++)
            {
                currentNumber = untidyNumbers[i];
                if (untidyNumbers[i] < currentLowestNumber)
                {
                    currentLowestNumber = untidyNumbers[i];
                }
                else if (untidyNumbers[i] > currentHighestNumber)
                {
                    currentHighestNumber = untidyNumbers[i];
                }
                else
                {
                    currentNumber = untidyNumbers[i];
                }

                //Seguir

            }


        }
    }

}
