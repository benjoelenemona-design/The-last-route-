using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController:MonoBehaviour {
    public Transform cameraTransform;
    public float moveSpeed=3.2f, rotationSpeed=12f;
    public Vector2 mobileInput;
    public bool useTilt;
    CharacterController cc; float vertical;

    void Awake(){cc=GetComponent<CharacterController>();}
    public void SetMoveInput(Vector2 v){mobileInput=v;}

    void Update(){
        Vector2 input=mobileInput;
        if(Keyboard.current!=null){
            Vector2 k=Vector2.zero;
            if(Keyboard.current.wKey.isPressed)k.y++;
            if(Keyboard.current.sKey.isPressed)k.y--;
            if(Keyboard.current.aKey.isPressed)k.x--;
            if(Keyboard.current.dKey.isPressed)k.x++;
            if(k.sqrMagnitude>0)input=k.normalized;
        }
        if(useTilt && SystemInfo.supportsAccelerometer)
            input+=new Vector2(Input.acceleration.x,Input.acceleration.y*.25f);

        Vector3 f=Vector3.ProjectOnPlane(cameraTransform.forward,Vector3.up).normalized;
        Vector3 r=Vector3.ProjectOnPlane(cameraTransform.right,Vector3.up).normalized;
        Vector3 d=f*input.y+r*input.x;
        if(d.sqrMagnitude>1)d.Normalize();
        if(d.sqrMagnitude>.01f)
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(d),rotationSpeed*Time.deltaTime);
        vertical+=Physics.gravity.y*Time.deltaTime;
        if(cc.isGrounded)vertical=-1;
        cc.Move((d*moveSpeed+Vector3.up*vertical)*Time.deltaTime);
    }
}
