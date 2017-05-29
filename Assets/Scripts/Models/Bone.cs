using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone {
    #region public properties
    public Transform transform { get; private set; }
    public Vector3 vector { get; private set; }
    #endregion

    public Bone(Transform boneInit, Transform boneEnd) {
        this.transform = boneInit;
        this.vector = boneEnd.position - boneInit.position;
    }
}
