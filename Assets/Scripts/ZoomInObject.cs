using UnityEngine;
using System.Collections; 

namespace DefaultNamespace
{
    // Object that I can zoom in at 
    public class ZoomInObject : MonoBehaviour, IInteractable
    {
        public float ZoomRatio = .5f; 
        
        // Zoom in on point
        public void Interact(Wachsbleiche _currentDisplay)
        {
            Camera.main.orthographicSize *= ZoomRatio; 
            Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
            
            // Only single zoom allowed
            gameObject.layer = 2; 
            _currentDisplay.CurrentState = Wachsbleiche.State.zoom; // change to zoom state 
            
            ConstraintCamera();
        }
        
        // Constraints of Zoom-Camera
        void ConstraintCamera()
        {
            var height = Camera.main.orthographicSize; // height of middle point of image to top of image
            var width = height * Camera.main.aspect; // aspect = width/height; width = middle of image to side of image 
            var cameraBounds = GameObject.Find("CameraBounds");

            if (Camera.main.transform.position.x + width > cameraBounds.transform.position.x + 
                cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
            {
                Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x 
                                                             + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 
                                                             - (Camera.main.transform.position.x + width),0f,0f);
            }
            if (Camera.main.transform.position.x - width < cameraBounds.transform.position.x -
                cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
            {
                Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x 
                                                              - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 
                                                              - (Camera.main.transform.position.x - width),0f,0f);
            } 
            if (Camera.main.transform.position.y + height > cameraBounds.transform.position.y +
                cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
            {
                Camera.main.transform.position += new Vector3(0f, cameraBounds.transform.position.y 
                                                              + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 
                                                              - (Camera.main.transform.position.y + height),0f);
            } 
            if (Camera.main.transform.position.y - height < cameraBounds.transform.position.y -
                cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
            {
                Camera.main.transform.position += new Vector3(0f, cameraBounds.transform.position.y 
                                                              - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 
                                                              - (Camera.main.transform.position.y - height),0f);
            } 


        }

    }
}