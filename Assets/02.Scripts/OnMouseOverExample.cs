using UnityEngine;
public class OnMouseOverExample : MonoBehaviour
{
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached,
     
    Debug.Log("Mouse is over GameObject.");
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this
        
    Debug.Log("Mouse is no longer on GameObject.");
    }
}