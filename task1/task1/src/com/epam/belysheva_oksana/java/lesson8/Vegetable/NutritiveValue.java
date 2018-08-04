package com.epam.belysheva_oksana.java.lesson8.Vegetable;

import com.epam.belysheva_oksana.java.lesson8.Exception.InvalidVegetableCharacteristicException;

/*
BelyshevaOA 531
lesson8
 */
public class NutritiveValue {
    private double calories;
    private double carbohydrates;
    private double protein;

    public NutritiveValue(double calories, double carbohydrates, double protein) throws InvalidVegetableCharacteristicException {
        if (calories < 0) {
            throw new InvalidVegetableCharacteristicException("Cannot create vegetable with " + calories + " kcal");
        } else if (protein < 0) {
            throw new InvalidVegetableCharacteristicException("Cannot create vegetable with " + protein + " proteins");
        } else if (carbohydrates < 0) {
            throw new InvalidVegetableCharacteristicException("Cannot create vegetable with "
                    + carbohydrates + " carbohydrates");
        }
        this.calories = calories;
        this.carbohydrates = carbohydrates;
        this.protein = protein;
    }

    public double getCalories() {
        return calories;
    }

    public double getCarbohydrates() {
        return carbohydrates;
    }

    public double getProtein() {
        return protein;
    }

    public void setCalories(double calories) {
        this.calories = calories;
    }

    public void setCarbohydrates(double carbohydrates) {
        this.carbohydrates = carbohydrates;
    }

    public void setProtein(double protein) {
        this.protein = protein;
    }

    public String toString() {
        return "Nutritive value{" +
                "calories=" + calories +
                ", carbohydrates=" + carbohydrates +
                ", protein=" + protein +
                '}';
    }
}
