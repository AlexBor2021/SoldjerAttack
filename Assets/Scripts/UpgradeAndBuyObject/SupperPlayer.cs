using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupperPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _panelSuperPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _panelSuperPlayer.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _panelSuperPlayer.SetActive(false);
        }
    }
}
