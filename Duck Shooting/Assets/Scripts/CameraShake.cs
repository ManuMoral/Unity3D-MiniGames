//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class CameraShake : MonoBehaviour
    {
        private void Start()
        {
            BalloonEvent.SetBonus += PlayShake;
        }

        void PlayShake(int id)
        {
            if (id == 0) StartCoroutine(Shake(.15f,.4f));
            else if (id == 1) StartCoroutine(Shake(.05f, .3f));
            else if (id == 2) StartCoroutine(Shake(.1f, .4f));
            else if (id == 3) StartCoroutine(Shake(.15f, .3f));
        }

        public IEnumerator Shake(float dur, float magnitude)
        {
            Vector3 originalPos = transform.localPosition;

            float elapsed = 0;

            while (elapsed < dur)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
        }

        private void OnDestroy()
        {
            BalloonEvent.SetBonus -= PlayShake;
        }
    }
}


