package com.epam.belysheva_oksana.java.lesson2;

import com.epam.belysheva_oksana.java.lesson2.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson2.Exception.VegetableAlreadyExistException;
import com.epam.belysheva_oksana.java.lesson2.Exception.VegetableIsNotExistException;
import com.epam.belysheva_oksana.java.lesson2.Vegetable.Vegetable;
import javafx.util.Pair;

import java.lang.reflect.Array;
import java.util.HashSet;
import java.util.Set;

/**
 * BelyshevaOA 531
 * lesson2
 * Для хранения ингредиентов салата используется массив
 */
public class VegetableSalad {
    private Vegetable[] compositionOfTheSalad;
    private String nameSalad;

    public VegetableSalad(String nameSalad) {
        this.nameSalad = nameSalad;
        this.compositionOfTheSalad = new Vegetable[0];
    }

    public Vegetable[] getComposition() {
        return compositionOfTheSalad;
    }

    public void setComposition(Vegetable[] compositionOfTheSalad) {
        this.compositionOfTheSalad = compositionOfTheSalad;
    }

    public void addIngredient(Vegetable vegetable, double weight) throws VegetableAlreadyExistException, InvalidVegetableCharacteristicException {
        if (vegetable == null || getVegetableByName(vegetable.getName()) != null) {
            throw new VegetableAlreadyExistException("Vegetable is null or already exist in company!");
        }
        if (weight <= 0) {
            throw new InvalidVegetableCharacteristicException("Cannot vegetable with weight " + weight);
        } else {
            vegetable.setWeight(weight);
            Vegetable[] temp = new Vegetable[compositionOfTheSalad.length];
            System.arraycopy(compositionOfTheSalad, 0, temp, 0, compositionOfTheSalad.length);
            compositionOfTheSalad = new Vegetable[compositionOfTheSalad.length + 1];
            System.arraycopy(temp, 0, compositionOfTheSalad, 0, temp.length);
            compositionOfTheSalad[compositionOfTheSalad.length - 1] = vegetable;
        }
    }

    public void removeIngredient(Vegetable vegetable) throws VegetableIsNotExistException {
        if (vegetable == null || getVegetableByName(vegetable.getName()) == null) {
            throw new VegetableIsNotExistException("Vegetable is null or isn't exist in salad!");
        } else {
            for (int i = 0; i < compositionOfTheSalad.length; i++) {
                if (compositionOfTheSalad[i].getName().equals(vegetable.getName())) {
                    Vegetable[] temp = new Vegetable[compositionOfTheSalad.length - 1];
                    System.arraycopy(compositionOfTheSalad, 0, temp, 0, i);
                    System.arraycopy(compositionOfTheSalad, i + 1, temp, 0, compositionOfTheSalad.length - i - 1);
                    compositionOfTheSalad = new Vegetable[compositionOfTheSalad.length - 1];
                    System.arraycopy(temp, 0, compositionOfTheSalad, 0, compositionOfTheSalad.length);
                    System.out.println("Succes remove " + vegetable.getName());
                    return;
                }
            }
        }
    }

    private Vegetable getVegetableByName(String name) {
        for (Vegetable vegetable :
                compositionOfTheSalad) {
            if (vegetable.getName().equals(name))
                return vegetable;
        }
        return null;
    }

    public double getSumCalories() {
        double sum = 0;

        for (Vegetable vegetable : compositionOfTheSalad) {
            sum += (vegetable.getCalories() * vegetable.getWeight());
        }

        return sum;
    }

    public double getSumProteins() {
        double sum = 0;

        for (Vegetable vegetable : compositionOfTheSalad) {
            sum += (vegetable.getProtein() * vegetable.getWeight());
        }

        return sum;
    }

    public double getSumCarbohydrates() {
        double sum = 0;

        for (Vegetable vegetable : compositionOfTheSalad) {
            sum += (vegetable.getCarbohydrates() * vegetable.getWeight());
        }

        return sum;
    }

    public Vegetable[] getVegetableByCalories(double lowerBound, double upperBound) {
        Vegetable[] result = new Vegetable[0];

        for (Vegetable vegetable : compositionOfTheSalad) {
            if (vegetable.getCalories() >= lowerBound && vegetable.getCalories() <= upperBound) {
                Vegetable[] temp = new Vegetable[result.length];
                System.arraycopy(result, 0, temp, 0, result.length);
                result = new Vegetable[result.length + 1];
                System.arraycopy(temp, 0, result, 0, temp.length);
                result[result.length - 1] = vegetable;
            }
        }

        return result;
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        result.append("The salad name: " + nameSalad + "\n");

        result.append("\nIngredients of the salad: \n");
        for (int i = 0; i < 20; i++) {
            result.append("_");
        }
        result.append("\n");
        for (Vegetable currentVegetable : getComposition()) {
            result.append(currentVegetable.getName() + " " + currentVegetable.getWeight() +
                    "g " + currentVegetable.getWayForEating() + "\n");
        }
        for (int i = 0; i < 20; i++) {
            result.append("_");
        }
        result.append("\n");
        return result.toString();
    }

}
