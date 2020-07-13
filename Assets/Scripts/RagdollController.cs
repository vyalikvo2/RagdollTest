using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private bool _isRigidBodyActive = false;
    Collider[] _rigidBodyColliders;
    Rigidbody[] _rigidBodies;

    private Collider _unactiveCollider; // collider then ragdoll unactive
    private Rigidbody _unactiveRigidBody;// rigidBody then ragdoll unactive
    
    // -----------------------------------------------------------------------------
    void Start()
    {
        _rigidBodyColliders = gameObject.GetComponentsInChildren<Collider>();
        _rigidBodies = gameObject.GetComponentsInChildren<Rigidbody>();
        
        SetRagdollPhysicsActive(false, true);
    }
    
    // -----------------------------------------------------------------------------
    public void SetRagdollPhysicsActive(bool isActive, bool isInit = false)
    {
        if (!isInit && _isRigidBodyActive == isActive ) return;
        _isRigidBodyActive = isActive;
        
        for (int i = 0; i < _rigidBodyColliders.Length; i++)
        {
            _rigidBodies[i].isKinematic = !isActive;
        }
        for (int i = 0; i < _rigidBodyColliders.Length; i++)
        {
            _rigidBodyColliders[i].isTrigger = !isActive;
        }
    }

}
