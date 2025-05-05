using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectsOnClick : MonoBehaviour
{
    public List<GameObject> objectsToActivate;

    private void OnMouseDown()
    {
        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
