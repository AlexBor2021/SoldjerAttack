using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Box : MonoBehaviour
{
    [SerializeField] private int _valueMoney;
    [SerializeField] private Animator _animator;
    [SerializeField] private Money _prefabMoney;
    [SerializeField] private AudioSource _openSourse;
    [SerializeField] private ParticleSystem _destroyBox;

    private Coroutine _creareMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool("Player", true);
            _openSourse.Play();
            _creareMoney = StartCoroutine(CreateMoney());
        }
    }

    private IEnumerator CreateMoney()
    {
        while (_valueMoney != 0)
        {
            Vector3 point = new Vector3(transform.position.x + Random.RandomRange(0, 3), transform.position.y, transform.position.z + Random.RandomRange(0, 3));
            var money = Instantiate(_prefabMoney, transform.position, Quaternion.identity);
            money.transform.DOJump(point, 3f, 1, 0.2f);
            _valueMoney--;
            yield return new WaitForSeconds(0.2f);
        }
        OffObject();
        yield return null;
    }

    private void OffObject()
    {
        StopCoroutine(_creareMoney);
        Instantiate(_destroyBox, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
