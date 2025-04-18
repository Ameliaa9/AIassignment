using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        [SerializeField] private Image crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            // Debug: Show if ray is fired
            Debug.DrawRay(transform.position, fwd * rayLength, Color.green);

            // Raycast without layer mask for simplicity
            if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
            {
                Debug.Log("Raycast hit something!");  // Debug: Did ray hit anything?

                if (hit.collider.CompareTag(interactableTag)) // Ensure the object has the "InteractiveObject" tag
                {
                    Debug.Log("Raycast hit interactive object: " + hit.collider.name);  // Debug: Verify what object is hit

                    if (!doOnce)
                    {
                        crosshair.color = Color.red;  // Change crosshair to red when hit
                        doOnce = true;
                    }

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        KeyItemController raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        if (raycastedObject != null)
                        {
                            raycastedObject.ObjectInteraction();
                            Debug.Log("Key picked up and door unlocked");  // Confirm the interaction
                        }
                    }
                }
            }
            else
            {
                if (doOnce)
                {
                    crosshair.color = Color.white;  // Reset crosshair if nothing is hit
                    doOnce = false;
                }
            }
        }
    }
}