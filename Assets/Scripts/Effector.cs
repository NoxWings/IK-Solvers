using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour {
    #region public variables
    public Transform ikTarget = null;
    public int chainLength = 2;
    #endregion

    private List<Bone> bones = new List<Bone>();
    private float maxLength = 0;

    void Start() {
        this.bones.Clear();
        Transform current = this.transform;

        for (int i = 0; i < chainLength; i++) {
            if (current.parent == null)
                break;

            Bone b = new Bone(current.parent, current);
            this.maxLength += b.vector.magnitude;
            this.bones.Add(b);

            current = current.parent;
        }
        this.bones.Reverse();
    }

    void Update () {
        if (IsTargetWithinMaxLength())
            FabrikSolver();
        else
            SimpleSolver();
    }

    private bool IsTargetWithinMaxLength() {
        Vector3 startPos = this.bones[0].transform.position;
        Vector3 endPos = ikTarget.position;
        float targetDistance = Vector3.Distance(startPos, endPos);
        return (targetDistance <= maxLength);
    }

    private void FabrikSolver() {
    }

    private void SimpleSolver() {
    }
}
