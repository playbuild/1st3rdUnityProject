using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagalbe
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagalbe
{
    public UICondition uiCondition;
    PlayerController controller;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }
    //Awake�� ����� getcomponent�� �߰��ϸ� ������ ȣ���� ��Ȳ���� ��
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0f)
        {
            Die();
        }


    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void SpeedUp(float amount)
    {
        controller.moveSpeed += (amount);

        Invoke("SpeedReturn" , 10f);
    }

    public void SpeedReturn()
    {
        controller.moveSpeed = controller.baseSpeed;
        //movespeed���� ���� ���·� ������
    }

    public void Die()
    {
        Die();
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }
}
