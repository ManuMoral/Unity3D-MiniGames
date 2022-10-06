//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _bonusIcons;
        [SerializeField] GameObject _plusTime, _flashPanel;
        [SerializeField] float _redBonusTime;

        void Start()
        {
            BalloonEvent.SetBonus += SetBalloonBonus;
            _flashPanel.SetActive(false);
        }

        void Update()
        {
            HideBonusIcons();
        }

        void SetBalloonBonus(int id)
        {
            //Show Visual feedback on Screen

            if (id == 0 && !GameManager.Instance.m_isGameOver)
            {
                //Red Bonus 
                _bonusIcons[0].SetActive(true);
                StartCoroutine(DelaySetSpeedShootBonusOn());
                StartCoroutine(HideRedBonusIcon());
            }
            else if (id == 1 && !GameManager.Instance.m_isGameOver)
            {
                //Green Bonus
                _bonusIcons[1].SetActive(true);
                _plusTime.SetActive(true);
                StartCoroutine(HideGreenBonusIcon());
            }
            else if (id == 2 && !GameManager.Instance.m_isGameOver)
            {
                //Yellow Bonus 
                _bonusIcons[2].SetActive(true);
                StartCoroutine(HideYellowBonusIcon());
            }
            else if (id == 3 && !GameManager.Instance.m_isGameOver)
            {
                //Purple Bonus 
                _bonusIcons[3].SetActive(true);
                _flashPanel.SetActive(true);
                Invoke(nameof(HideFlashPanel), .1f);
                StartCoroutine(HidePurpleBonusIcon());
            }
        }

        void HideBonusIcons()
        {
            if (GameManager.Instance.m_isGameOver)
            {
                for (int i = 0; i < _bonusIcons.Length; i++)
                {
                    _bonusIcons[i].SetActive(false);
                }
            }
        }

        void HideFlashPanel()
        {
            _flashPanel.SetActive(false);
        }

        IEnumerator DelaySetSpeedShootBonusOn()
        {
            yield return new WaitForSeconds(.5f);
            GameManager.Instance.m_speedShootBonusOn = true;
        }

        IEnumerator HideRedBonusIcon()
        {
            yield return new WaitForSeconds(_redBonusTime);
            GameManager.Instance.m_speedShootBonusOn = false;
            _bonusIcons[0].SetActive(false);
        }

        IEnumerator HideGreenBonusIcon()
        {
            yield return new WaitForSeconds(2.5f);
            _plusTime.SetActive(false);
            _bonusIcons[1].SetActive(false);
        }

        IEnumerator HideYellowBonusIcon()
        {
            yield return new WaitForSeconds(4f);
            _bonusIcons[2].SetActive(false);
        }

        IEnumerator HidePurpleBonusIcon()
        {
            yield return new WaitForSeconds(4f);
            _bonusIcons[3].SetActive(false);
        }

        private void OnDestroy()
        {
            BalloonEvent.SetBonus -= SetBalloonBonus;
        }
    }
}

