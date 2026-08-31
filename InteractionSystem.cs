using UnityEngine;

public interface IInteractable {
    string Prompt {get;}
    void Interact(GameObject player);
}

public class InteractionSystem:MonoBehaviour {
    public Camera viewCamera;
    public float range=2.5f;

    public void TryInteract(){
        if(!viewCamera)return;
        Ray r=new Ray(viewCamera.transform.position,viewCamera.transform.forward);
        if(Physics.Raycast(r,out RaycastHit h,range)){
            var x=h.collider.GetComponentInParent<IInteractable>();
            if(x!=null)x.Interact(gameObject);
        }
    }
}
