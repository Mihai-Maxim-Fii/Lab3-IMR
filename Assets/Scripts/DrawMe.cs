using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK.Examples
{
    public class DrawMe : MonoBehaviour
    {
        

        protected virtual void OnEnable()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
        }

        private LineRenderer lineRenderer;
        private int positionCount = 0;
        bool Drawing = false;
        public VRTK_InteractableObject linkedObject;

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            if (Drawing)
            {
                Drawing = false;

            }
            else
            {
                //https://stackoverflow.com/questions/19236482/how-to-create-a-line-using-two-vector3-points-in-unity
                Drawing = true;
                lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
                lineRenderer.startWidth = 0.05f;
                lineRenderer.endWidth = 0.05f;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.SetPosition(0, gameObject.transform.position); //x,y and z position of the starting point of the line
                lineRenderer.SetPosition(1, gameObject.transform.position);
            }
        }
        void Update()
        {
            if (Drawing)
            {
                lineRenderer.SetPosition(lineRenderer.positionCount++, gameObject.transform.position);
            }
        }
    }
}
