using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : Quest
{
    public override void Enter()
    {

    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTrigerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            QuestClear();
    }
}
