using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _move = "Move";

    public void SetMove(bool move)
    {
        _animator.SetBool(_move, move);
    }
}
