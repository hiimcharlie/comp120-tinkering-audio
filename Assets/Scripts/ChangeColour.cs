using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
   
    
    public void change_colour()
    {
        //GetComponent<UnityEngine.UI.Image>().color = Color.green;

        foreach (GameObject dynamicColourObject in DynamicColourObject.list)
            dynamicColourObject.GetComponent<Renderer>().sharedMaterial.color = Color.red;

    }
    
}
