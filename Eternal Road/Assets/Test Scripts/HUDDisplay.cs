//Final Round: Eternal Road
//Last Editor: Manu Moral

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Unity3DMiniGames
{
    public class HUDDisplay : MonoBehaviour
    {
        [SerializeField] Image _skillsBTN, _changeLaneBTN;
        [SerializeField] TextMeshProUGUI _skillBTNText;
        [SerializeField] Color32 _pressedBTNColor, _staticBTNColor;
        [SerializeField] Sprite[] _skillImgsBTN;

        public void PushChangeLaneBTN(bool on)
        {
            if (on) _changeLaneBTN.color = _pressedBTNColor;
            else _changeLaneBTN.color = _staticBTNColor;
        }

        public void DisplaySkillBTN(int id)
        {
            if (id == 0) //Gum
            {
                //_skillsBTN.sprite = _skillImgsBTN[id];
                _skillBTNText.text = "Jump";
            }
            else if (id == 1) //Stone
            {
                //_skillsBTN.sprite = _skillImgsBTN[id];
                _skillBTNText.text = "Rush";
            }
            else if (id == 2) //Plasticine
            {
                //_skillsBTN.sprite = _skillImgsBTN[id];
                _skillBTNText.text = "Shrink";
            }
            else if (id == 3) //Balloon
            {
                //_skillsBTN.sprite = _skillImgsBTN[id];
                _skillBTNText.text = "Levitate";
            }
        }
    }
}


