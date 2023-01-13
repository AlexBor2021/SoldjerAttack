using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    public bool IsCollect = false;

    public void Moving(Transform parent)
    {
        transform.SetParent(parent);
        transform.DOJump(parent.position, 3f, 1, 0.2f).OnComplete(DeleteObject);
    }

    private void DeleteObject()
    {
        gameObject.SetActive(false);
    }
}
