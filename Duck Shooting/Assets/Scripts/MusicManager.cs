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
            if (GameManager.Instance.m_isSoundOff)
            {
                _music.mute = true;
                _muteBtn.sprite = _duckIcons[0];
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                MuteMusic();
            }
        }

        public void MuteMusic()
        {
            _music.mute = !_music.mute;

            if (GameManager.Instance.m_isSoundOff)
            {
                GameManager.Instance.m_isSoundOff = false;
            }
            else
            {
                GameManager.Instance.m_isSoundOff = true;
            }

            SwitchMuteBtn();
        }

        public void StopTheMusic()
        {
            _music.Stop();
        }

        public void PauseMusic()
        {
            _music.Pause();
        }

        public void PlayMusic()
        {
            _music.Play();
        }

        void SwitchMuteBtn()
        {
            if (_music.mute) _muteBtn.sprite = _duckIcons[0];
            else _muteBtn.sprite = _duckIcons[1];
        }
    }
}

