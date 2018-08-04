package com.epam.belysheva_oksana.java.lesson5.Vegetable;

/*
BelyshevaOA 531
lesson5
В качестве коллекций используется Set для хранянения ингредиентов салата в VegetableSalad

lesson4
Используются собственные обработчики исключений в package Exception
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