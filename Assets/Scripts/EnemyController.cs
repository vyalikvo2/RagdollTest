using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject BasePelvis;
    
    private bool _isAlive = true;
    private RagdollController _ragdoll;
    
    private Rigidbody _baseRigidBody;
    
    // -----------------------------------------------------------------------------
    void Start()
    {
        _ragdoll = GetComponent<RagdollController>();

        _baseRigidBody = BasePelvis.GetComponent<Rigidbody>();
        _baseRigidBody.useGravity = false;
    }
    
    // -----------------------------------------------------------------------------
    public void Hit(Vector3 force, Vector3 pos, Rigidbody rigidBody)
    {
        if (!_isAlive) return;
        _isAlive = false;
        
        _baseRigidBody.useGravity = true;
        _ragdoll.SetRagdollPhysicsActive(true);

        rigidBody.AddForceAtPosition(force, pos, ForceMode.Impulse);
    }
}
