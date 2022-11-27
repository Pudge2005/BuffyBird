using System;
using System.Collections;
using UnityEngine;

namespace Utils.Unsorted
{
    public sealed class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
#if UNITY_EDITOR
        [SerializeField] private bool _calculateOffset;
#endif
        [SerializeField] private bool _blockX;
        [SerializeField] private bool _blockY;
        [SerializeField] private bool _blockZ;

        private Transform _tr;


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_calculateOffset)
            {
                _calculateOffset = false;
                _offset = transform.position - _target.position;
                UnityEditor.EditorUtility.SetDirty(this);
            }
        }
#endif

        private void Awake()
        {
            _tr = transform;
        }

        private void Update()
        {
            Vector3 targetP = _target.position + _offset;
            Vector3 newP = _tr.position;

            if (!_blockX)
                newP.x = targetP.x;

            if (!_blockY)
                newP.y = targetP.y;

            if (!_blockZ)
                newP.z = targetP.z;

            _tr.position = newP;
        }
    }

}