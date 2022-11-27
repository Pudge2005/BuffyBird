using UnityEngine;

namespace Utils.Multilanguage
{
    [System.Serializable]
    public class MetaInfo
    {
        [SerializeField] private InternationalString _name;
        [SerializeField] private Texture2D _icon;
        [SerializeField] private Texture2D _preview;
    }
}
