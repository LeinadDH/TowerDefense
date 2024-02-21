using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class DoubleCard : MonoBehaviour
    {
        [SerializeField] private Transform _shootOrigin;
        [SerializeField] private float _coolDown;
        [SerializeField] private float _range;
        [SerializeField] private LayerMask _layerMask;

        private bool _canShoot = true;
        private GameObject _target;

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _range, _layerMask);

            if (hit.collider)
            {
                _target = hit.collider.gameObject;
                if (_canShoot)
                {
                    Shoot();
                    _canShoot = false;
                    Invoke("ResetCanShoot", _coolDown);
                }
            }
        }

        private void Shoot()
        {
            ShootBullet();
            Invoke("ShootBullet", 0.5f);
        }

        private void ShootBullet()
        {
            Shoot instance = ObjectPooler.DequeueObject<Shoot>("Shoot");
            instance.gameObject.SetActive(true);
            instance.transform.position = _shootOrigin.position;
        }

        private void ResetCanShoot()
        {
            _canShoot = true;
        }
    }
}