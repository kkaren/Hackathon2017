using UnityEngine;
using System.Collections;

public interface IEnemyState {
    void execute();

    void enter(Enemy enemy);

    void exit();

    void OnTriggerEnter(Collider2D other);
}
