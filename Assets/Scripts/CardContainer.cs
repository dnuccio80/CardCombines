using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{

    public List<GameObject> objectsToAlign = new List<GameObject>();
    public Vector3 alignmentPosition = new Vector3(0, 0, 0);

    // Método para agregar un nuevo objeto a la lista y alinear todos los objetos
    public void AddAndAlignObject(GameObject newObj)
    {
        objectsToAlign.Add(newObj);
        AlignAllObjects();
    }

    private void Start()
    {
        AlignAllObjects();
    }


    // Método para alinear todos los objetos en la lista
    public void AlignAllObjects()
    {
        // Calcula la posición promedio de todos los objetos en la lista
        Vector3 averagePosition = alignmentPosition;
        foreach (GameObject obj in objectsToAlign)
        {
            averagePosition += obj.transform.position;
        }
        averagePosition /= objectsToAlign.Count;

        // Alinea todos los objetos a la posición promedio
        foreach (GameObject obj in objectsToAlign)
        {
            obj.transform.position = averagePosition;
        }
    }

}
