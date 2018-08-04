package com.epam.belysheva_oksana.java.lesson5.Vegetable;

import com.epam.belysheva_oksana.java.lesson5.Exception.InvalidVegetableCharacteristicException;

/*
BelyshevaOA 531
lesson5
В качестве коллекций используется Set для хранянения ингредиентов салата в VegetableSalad

lesson4
Используются собственные обработчики исключений в package Exception
 */
public class Bulbous implements Vegetable {
    private static VegetableType vegetableType = VegetableType.BULBOUS;

    private String name;
    private double kcalPer100g;
    private double carbohydratesPer100g;
    private double proteinPer100g;
    private double weight = 100;

    private WayForEating wayForEating;

    public Bulbous() {
    }

    public Bulbous(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) throws InvalidVegetableCharacteristicException {
        if (name.length() == 0 || name.replace(" ", "").length() == 0)
            throw new InvalidVegetableCharacteristicException("Cannot create vegeteble with name " + name);

        this.name = name;

        if (calories < 0) {
            throw new InvalidVegetableCharacteristicException("Cannot create vegetable with " + calories + " kcal");
        } else if (protein < 0) {
            throw new InvalidVegetableCharacteristicException("Cannot create vegetable with " + protein + " proteins");
        } else if (carbohydrates < 0) {
            throw new InvalidVegetableCharacteristicException("Cannot create vegetable with "
                    + carbohydrates + " carbohydrates");
        }

        this.kcalPer100g = calories;
        this.carbohydratesPer100g = carbohydrates;
        this.proteinPer100g = protein;
        this.wayForEating = wayForEating;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public double getWeight() {
        return weight;
    }

    @Override
    public void setWeight(double weight) {
        this.weight = weight;
    }

    @Override
    public VegetableType getType() {
        return vegetableType;
    }

    @Override
    public WayForEating getWayForEating() {
        return wayForEating;
    }

    @Override
    public double getCalories() {
        return kcalPer100g;
    }

    @Override
    public double getProtein() {
        return proteinPer100g;
    }

    @Override
    public double getCarbohydrates() {
        return carbohydratesPer100g;
    }

    @Override
    public int compareTo(Vegetable o) {
        if (this.getCalories() > o.getCalories()) {
            return 1;
        }

        if (this.getCalories() < o.getCalories()) {
            return -1;
        }

        return 0;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null || obj.getClass() != this.getClass()) {
            return false;
        }

        Beans o = (Beans) obj;

        return this.name.equals(o.getName()) && this.getCalories() == o.getCalories() &&
                this.getProtein() == o.getProtein() && this.getCarbohydrates() == o.getCarbohydrates();
    }

    @Override
    public String toString() {
        return (name + " : " + "category : " + vegetableType + "\n"
                + getCalories() + "kcal\n" + getProtein() + " protein\n"
                + getCarbohydrates() + " carbohydrates");
    }
}
