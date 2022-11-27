using System.Collections;
using UnityEngine;

namespace Utils.Fade
{
    public class RendererFader : MonoBehaviour, IFader
    {
        [SerializeField] private Renderer _renderer;

        private Coroutine _fadingCo;
        private Material _mat;


        private void Start()
        {
            _mat = _renderer.material;
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
            float a = _mat.color.a;
            float b = target;

            for (float t = 0; ;)
            {
                t += Time.deltaTime / time;

                if (t > 1f)
                    t = 1f;

                SetAlpha(Mathf.Lerp(a, b, t));

                if (t == 1f)
                    yield break;

                yield return null;
            }
        }


        internal void SetAlpha(float v)
        {
            var c = _mat.color;
            c.a = v;
            _mat.color = c;
        }
    }
}
