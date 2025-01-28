using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKPaciente_R : MonoBehaviour
{
    public Transform cabeza;
    public Transform controlIzq;
    public Transform controlDer;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtWeight(1);
        animator.SetLookAtPosition(cabeza.position);

        float reach = animator.GetFloat("Mano_Der");
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, reach);
        animator.SetIKPosition(AvatarIKGoal.RightHand, controlDer.position);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, reach);
        animator.SetIKRotation(AvatarIKGoal.RightHand, controlDer.rotation);


        float reach_ = animator.GetFloat("Mano_Izq");
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, reach_);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, controlIzq.position);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, reach_);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, controlIzq.rotation);
    }
}
