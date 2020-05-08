﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCollisionHandler : MonoBehaviour
{
    [Header(" --- Setup ---")]
    [SerializeField] private ScoreUI m_scoreUI;
    
    [Header(" --- Gameplay ---")]
    [Tooltip("How much the player gets for one piece of cargo")]
    [SerializeField] private int m_scorePerCargo = 10;
    public void OnTriggerEnter(Collider other)
    {
        //check if the Trigger Participant is the Player and if he has a PlayerCargo Component 
        if (other.CompareTag("Player") && other.transform.parent.GetComponent<PlayerCargo>() is PlayerCargo cargo)
        {
            //add score to the 
            int cargoAmount = cargo.SpaceOccupied;
            m_scoreUI.AddScore(cargoAmount * m_scorePerCargo);
            //clear all cargo
            cargo.ClearCargo();
            
        }
    }
}
