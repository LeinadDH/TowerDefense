using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class SimpleCard : MonoBehaviour
    {
        [SerializeField] private Transform _shootOrigin;
        [SerializeField] private float _coolDown;
        [SerializeField] private float _range;
        [SerializeField] private LayerMask _layerMask;

        private bool _canShoot = true;
        private GameObject _target;

        private void Start()
        {
            Invoke("ResetCoolDown", _coolDown);
        }

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _range, _layerMask);

            if (hit.collider)
            {
                _target = hit.collider.gameObject;
                Shoot();
            }
        }
        
        private void ResetCoolDown()
        {
            _canShoot = true;
        }

        private void Shoot()
        {
            if (!_canShoot) return;
            _canShoot = false;
            Invoke("ResetCoolDown", _coolDown);
            
            Shoot instance = ObjectPooler.DequeueObject<Shoot>("Shoot");
            instance.gameObject.SetActive(true);
            instance.transform.position = _shootOrigin.position;
        }
    }
}