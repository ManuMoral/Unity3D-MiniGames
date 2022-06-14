//Practice: FizzBuzz Game
//Editor: Manu Moral

using UnityEngine;

public class FizzBuzz : MonoBehaviour
{
    [SerializeField] int _limit;
    [SerializeField] int _fizzMulti, _buzzMulti, _plusMulti,
        _fizzBuzzMulti, _fizzPlusMulti, _buzzPlusMulti, _fizzBuzzPlusMulti;
    int number;

    private void Start()
    {
        while (number < _limit)
        {
            number++;

            if (IsMultiOf(_fizzBuzzPlusMulti)) Debug.Log("FizzBuzzPlus");
            else if (IsMultiOf(_buzzPlusMulti)) Debug.Log("BuzzPlus");
            else if (IsMultiOf(_fizzPlusMulti)) Debug.Log("FizzPlus");
            else if (IsMultiOf(_fizzBuzzMulti)) Debug.Log("FizzBuzz");
            else if (IsMultiOf(_plusMulti)) Debug.Log("Plus");
            else if (IsMultiOf(_buzzMulti)) Debug.Log("Buzz");
            else if (IsMultiOf(_fizzMulti)) Debug.Log("Fizz");
            else Debug.Log(number);
        }

        bool IsMultiOf(int num)
        {
            if (number % num == 0) return true;
            else return false;
        }
    }
}
