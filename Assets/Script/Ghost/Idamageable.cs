﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idamageable
{
    int Health{get; set;}
    void Damage(int damage);
}
