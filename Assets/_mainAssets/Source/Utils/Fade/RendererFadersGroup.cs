using System;
using System.Collections;
using UnityEngine;

namespace Utils.Fade
{
    public class RendererFadersGroup : MonoBehaviour, IFader
    {
        private Coroutine _fadingCo;
        private RendererFader[] _faders;


        private RendererFader[] Faders
        {
            get
            {
                _faders ??= GetComponentsInChildren<RendererFader>();
                return _faders;
            }
        }


        public void FadeOut(float time)
        {
            FadeInternal(time, 0);
        }

        public void FadeIn(float time)
        {
            FadeInternal(time, 1);
        }

        private void FadeInternal(float time, float target)
        {
            if (_fadingCo != null)
            {
                StopCoroutine(_fadingCo);
            }

            _fadingCo = StartCoroutine(Fade(time, target));
        }

        private IEnumerator Fade(float time, float target)
        {
            target = Math.Clamp(target, 0, 1);
            float a = 1f - target;


            for (float t = 0; ;)
            {
                t += Time.deltaTime / time;

                if (t > 1f)
                    t = 1f;

                float alpha = Mathf.Lerp(a, target, t);

                foreach (var f in Faders)
                {
                    f.SetAlpha(alpha);
                }

                if (t == 1f)
                    yield break;

                yield return null;
            }
        }
    }
}
