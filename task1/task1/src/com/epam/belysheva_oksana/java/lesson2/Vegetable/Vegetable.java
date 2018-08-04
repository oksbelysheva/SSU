package com.epam.belysheva_oksana.java.lesson2.Vegetable;

/**
 * BelyshevaOA 531
 * lesson2
 * Для хранения ингредиентов салата используется массив
 */
public interface Vegetable extends Comparable<Vegetable> {
    public String getName();

    public VegetableType getType();

    public WayForEating getWayForEating();

    public double getWeight();

    public void setWeight(double weight);

    public double getCalories();

    public double getProtein();

    public double getCarbohydrates();
}
