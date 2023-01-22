using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _TowerDefense.Player { 
    public class PlayerInteraction : MonoBehaviour
    {
        //The player's camera. Labelled as SerializeField so we can set it in Unity.
        [SerializeField] private Camera PlayerCamera;

        [SerializeField] private Placement heldObject = null;
        
        //Awake is called during scene loading
        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            if (heldObject)
            {
                //using a variable here for efficiency
                var position = (Vector2)PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
                position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y));
                heldObject.transform.position = position;
                
                if (Input.GetMouseButtonDown(0) && heldObject.isInValidSpot) //The mouse has been clicked.
                {
                    heldObject.PlaceObject();
                    heldObject = null;
                }
                else if (Input.GetKey(KeyCode.Escape))
                {
                    Destroy(heldObject.gameObject);
                }
            }
        }

        //We call this to get the object under the cursor
        private GameObject GetObjectUnderCursor()
        {
            //Get a ray from the mouse to what it's over on the screen
            Ray MouseLocation = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            
            //We cast a ray from the mouse position. Stuff about that is stored in hitInfo.
            Physics.Raycast(MouseLocation, out var hitInfo);
            
            //send back the GameObject that we got, or null if we didn't get anything
            return hitInfo.collider != null ? hitInfo.collider.gameObject : null;
        }

        public void CreateAndAttachUnit(GameObject unitToCreate)
        {
            if (heldObject != null)
            {
                return;
            }
            
            var newObject = Object.Instantiate(unitToCreate, null);
            heldObject = newObject.GetComponent<Placement>();
        }
    }
}
