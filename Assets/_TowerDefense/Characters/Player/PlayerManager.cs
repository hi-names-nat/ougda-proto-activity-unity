using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace _TowerDefense.Player { 
    
    [RequireComponent(typeof(Camera))]
    public class PlayerManager : MonoBehaviour
    {
        //The player's camera. Labelled as SerializeField so we can set it in Unity.
        private Camera _playerCamera;

        //the object (tower) that the player currently has
        [SerializeField] private Placement heldObject = null;
        //the cost of the object currently being held, so we can
        //subtract it from mana if the player places it.
        private float _heldObjectCost = -1;

        //A reference to the player's healh and mana bar manager
        [SerializeField] private MeterUIManager meterUI;
        
        //The maximum mana that the player can have. Used to make units
        [SerializeField] private float maxMana = 100;
        //THe current mana the player has
        private float _currentMana;
        //The amount of mana the player is given per second
        [SerializeField] private float manaPerSecond = 5;
        
        //Awake is called during scene loading
        private void Awake()
        {
            _playerCamera = GetComponent<Camera>();
            _currentMana = maxMana;
        }

        // Update is called once per frame
        private void Update()
        {
            if (heldObject)
            {
                //using a variable here for efficiency
                var position = (Vector2)_playerCamera.ScreenToWorldPoint(Input.mousePosition);
                position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y));
                heldObject.transform.position = position;
                
                if (Input.GetMouseButtonDown(0) && heldObject.isInValidSpot) //The mouse has been clicked.
                {
                    //spend the mana
                    _currentMana -= _heldObjectCost;
                    
                    //place the object
                    heldObject.PlaceObject();
                    heldObject = null;
                    
                    meterUI.SetMagicMeter(_currentMana / maxMana);
                }
                else if (Input.GetKey(KeyCode.Escape))
                {
                    Destroy(heldObject.gameObject);
                }
            }
            
            GainMana();
        }

        private void GainMana()
        {
            _currentMana += Mathf.Min(manaPerSecond * Time.deltaTime, maxMana);
            meterUI.SetMagicMeter(_currentMana / maxMana);
        }

        //We call this to get the object under the cursor
        private GameObject GetObjectUnderCursor()
        {
            //Get a ray from the mouse to what it's over on the screen
            Ray MouseLocation = _playerCamera.ScreenPointToRay(Input.mousePosition);
            
            //We cast a ray from the mouse position. Stuff about that is stored in hitInfo.
            Physics.Raycast(MouseLocation, out var hitInfo);
            
            //send back the GameObject that we got, or null if we didn't get anything
            return hitInfo.collider != null ? hitInfo.collider.gameObject : null;
        }

        //This is the function that the create unit button calls to create our unit (tower) and attach it to the 
        //player manager
        public void CreateAndAttachUnit(GameObject unitToCreate, float manaCost)
        {
            if (heldObject != null)
            {
                return;
            }

            if (_currentMana < manaCost)
            {
                return;
            }

            var newObject = Object.Instantiate(unitToCreate, null);
            _heldObjectCost = manaCost;
            heldObject = newObject.GetComponent<Placement>();

        }
    }
}
