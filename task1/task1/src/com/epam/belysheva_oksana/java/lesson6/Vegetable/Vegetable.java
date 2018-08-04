package com.epam.belysheva_oksana.java.lesson6.Vegetable;

import java.io.Serializable;

/*
BelyshevaOA 531
lesson6
 */
public interface Vegetable extends Comparable<Vegetable>, Serializable {
    public String getName();

    public VegetableType getType();

    public WayForEating getWayForEating();

    public double getWeight();

    public void setWeight(double weight);

    public double getCalories();

    public double getProtein();

    public double getCarbohydrates();

    public String toString();
}