using UnityEngine;

namespace Game
{
    public class FadersTester : MonoBehaviour
    {
        [SerializeField] private RendererFadersGroup[] _rendererFadersGroups;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                foreach (var rfg in _rendererFadersGroups)
                {
                    rfg.FadeOut(2f);
                }
            }
        }
    }
}
