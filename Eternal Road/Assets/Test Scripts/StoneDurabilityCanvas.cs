//Final Round: Eternal Road
//Last Editor: Manu Moral

using UnityEngine;
using UnityEngine.UI;

namespace Unity3DMiniGames
{
    public class StoneDurabilityCanvas : MonoBehaviour
    {
        [SerializeField] Image[] _durSlots;
        [SerializeField] Color32 _availableColor, _notAvailableColor;

        private void Start()
        {
            for (int i = 0; i < _durSlots.Length; i++)
            {
                ChangeColor(_durSlots[i], true);
            }
        }

        public void DisplayDurability(int durability)
        {
            if (durability == 3)
            {
                ChangeColor(_durSlots[0], true);
                ChangeColor(_durSlots[1], true);
                ChangeColor(_durSlots[2], true);
            }
            else if(durability == 2)
            {

                ChangeColor(_durSlots[0], true);
                ChangeColor(_durSlots[1], true);
                ChangeColor(_durSlots[2], false);
            }
            else if (durability == 1)
            {
                ChangeColor(_durSlots[0], true);
                ChangeColor(_durSlots[1], false);
                ChangeColor(_durSlots[2], false);
            }
            else
            {
                ChangeColor(_durSlots[0], false);
                ChangeColor(_durSlots[1], false);
                ChangeColor(_durSlots[2], false);
            }
        }

        void ChangeColor(Image slot, bool on)
        {
            if (on) slot.color = _availableColor;
            else slot.color = _notAvailableColor;
        }

    }
}


