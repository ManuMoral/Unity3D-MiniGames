//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class ReloadWeaponIcon : MonoBehaviour
    {
        [SerializeField] GameObject[] _gunIcons;
        [SerializeField] GunMov _gunMov;

        void Start()
        {
            _gunIcons[0].SetActive(true);
            _gunIcons[1].SetActive(false);
        }

        void Update()
        {
            SetReloadedWeaponIcon();
        }

        private void SetReloadedWeaponIcon()
        {
            if (_gunMov.IsRecharged())
            {
                _gunIcons[0].SetActive(true);
                _gunIcons[1].SetActive(false);
            }
            else
            {
                _gunIcons[0].SetActive(false);
                _gunIcons[1].SetActive(true);
            }
        }
    }
}


