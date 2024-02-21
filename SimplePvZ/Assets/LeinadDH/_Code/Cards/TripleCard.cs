using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class TripleCard : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _shootOrigins;

        [SerializeField] private float _coolDown;
        [SerializeField] private float _range;
        [SerializeField] private LayerMask _layerMask;

        private bool _canShoot = true;

        private void Start()
        {
            Invoke("ResetCoolDown", _coolDown);
        }

        private void Update()
        {
            if (!_canShoot) return;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _range, _layerMask);

            if (hit.collider)
            {
                for (int i = 0; i < _shootOrigins.Length; i++)
                {
                    Shoot(_shootOrigins[i]);
                }
            }
        }

        private void ResetCoolDown()
        {
            _canShoot = true;
        }

        private void Shoot(Transform shootOrigin)
        {
            _canShoot = false;
            Invoke("ResetCoolDown", _coolDown);
            
            Shoot instance = ObjectPooler.DequeueObject<Shoot>("Shoot");
            instance.gameObject.SetActive(true);
            instance.transform.position = shootOrigin.position;
        }
    }
}