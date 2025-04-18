using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool opendoor = false;
        [SerializeField] private bool rustykey = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (opendoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if (opendoor)
            {
                doorObject.PlayAnimation();
            }

            else if (rustykey)
            {
                _keyInventory.hasRustyKey = true;
                gameObject.SetActive(false);
            }
        }
    }

}