using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttackZone : MonoBehaviour
{
    [SerializeField] private GameObject _buttonAttak;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _buttonAttak.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _buttonAttak.SetActive(false);
        }
    }
}
