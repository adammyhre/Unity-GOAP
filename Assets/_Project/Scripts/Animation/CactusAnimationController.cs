using UnityEngine;

public class CactusAnimationController : AnimationController {
    protected override void SetLocomotionClip() {
        locomotionClip = Animator.StringToHash("Locomotion");
    }
    
    protected override void SetAttackClip() {
        attackClip = Animator.StringToHash("Cactus_Attack01");
    }
    
    protected override void SetSpeedHash() {
        speedHash = Animator.StringToHash("Speed");
    }
}