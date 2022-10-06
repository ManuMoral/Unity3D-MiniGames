//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class SubstractTimeFeedback : MonoBehaviour
    {
        bool isTouched;
        [SerializeField] GameObject _subsTimeIcon, _dmgOverlay;
        [SerializeField] TextMeshProUGUI _timeDrainCount;
        [SerializeField] TimerCD _timeCD;
        AudioSource _biteSound;
        
        private void Start()
        {
            isTouched = false;
            _biteSound = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("DracuDuck") && !isTouched && !GameManager.Instance.m_isGameOver)
            {
                isTouched = true;
                if (!GameManager.Instance.m_isSoundOff)_biteSound.Play();
                _dmgOverlay.SetActive(true);
                Invoke(nameof(HideDmgOverlay), .5f);
                Invoke(nameof(ShowTimeDrainFeedBack), .5f);
                StartCoroutine(WaitToHideVisualFeedback());
            }
        }

        void ShowTimeDrainFeedBack()
        {
            _timeDrainCount.text = "- " + _timeCD.m_totalTimeDrain.ToString() + " s";
            _subsTimeIcon.SetActive(true);
        }

        void HideDmgOverlay()
        {
            _dmgOverlay.SetActive(false);
        }

        IEnumerator WaitToHideVisualFeedback()
        {
            yield return new WaitForSeconds(2f);
            _subsTimeIcon.SetActive(false);
            _dmgOverlay.SetActive(false);
            isTouched = false;
        }
    }
}


