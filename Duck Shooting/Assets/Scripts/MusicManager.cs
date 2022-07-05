//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using UnityEngine.UI;

namespace Unity3DMiniGames
{
    public class MusicManager : MonoBehaviour
    {
        AudioSource _music;
        [SerializeField] Image _muteBtn;
        [SerializeField] Sprite[] _duckIcons;
        
        void Start()
        {
            _music = GetComponent<AudioSource>();
        }

        public void MuteMusic()
        {
            _music.mute = !_music.mute;
            SwitchMuteBtn();
        }

        void SwitchMuteBtn()
        {
            if (_music.mute) _muteBtn.sprite = _duckIcons[0];
            else _muteBtn.sprite = _duckIcons[1];
        }
    }
}

