using UnityEngine;

namespace Utils.Shake
{
    [System.Serializable]
    public sealed class ShakeCurve2D
    {
        [Tooltip("Максимальное смещение по X (в юнитах)")]
        [SerializeField] private AnimationCurve _amplitudeX;
        [Tooltip("Максимальное смещение по Y (в юнитах)")]
        [SerializeField] private AnimationCurve _amplitudeY;

        [Tooltip("Частота смещений (смещений в секунду)")]
        [SerializeField] private AnimationCurve _frequency;


        public void Evaluate(float t, out Vector2 ampl, out float freq)
        {
            ampl.x = _amplitudeX.Evaluate(t);
            ampl.y = _amplitudeY.Evaluate(t);

            freq = _frequency.Evaluate(t);   
        }
    }

}