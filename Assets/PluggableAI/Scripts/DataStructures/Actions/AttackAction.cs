using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController stateController)
    {
        RaycastHit hit;

        Debug.DrawRay(stateController.eyes.position, stateController.eyes.forward.normalized * stateController.enemyStats.attackRange, Color.red);
        if (Physics.SphereCast(stateController.eyes.position, stateController.enemyStats.lookSphereCastRadius, stateController.eyes.forward, out hit, stateController.enemyStats.attackRange)
            && hit.collider.CompareTag("Player"))
        {
            if (stateController.CheckIfCountDownElapsed(stateController.enemyStats.attackRate))
            {
                stateController.tankShooting.Fire(stateController.enemyStats.attackForce, stateController.enemyStats.attackRate);
            }
        }
    }
}
