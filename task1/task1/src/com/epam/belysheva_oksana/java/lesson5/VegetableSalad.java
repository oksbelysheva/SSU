package com.epam.belysheva_oksana.java.lesson5;

import com.epam.belysheva_oksana.java.lesson5.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson5.Exception.VegetableAlreadyExistException;
import com.epam.belysheva_oksana.java.lesson5.Exception.VegetableIsNotExistException;
import com.epam.belysheva_oksana.java.lesson5.Vegetable.Vegetable;
import javafx.util.Pair;

import java.util.HashSet;
import java.util.Set;

/*
BelyshevaOA 531
lesson5
В качестве коллекций используется Set для хранянения ингредиентов салата в VegetableSalad

lesson4
Используются собственные обработчики исключений в package Exception
 */
public class VegetableSalad {
    private Set<Vegetable> compositionOfTheSalad = new HashSet<>();
    private String nameSalad;

    public VegetableSalad(String nameSalad) {
        this.nameSalad = nameSalad;
        this.compositionOfTheSalad = new HashSet<>();
    }

    public Set<Vegetable> getComposition() {
        return compositionOfTheSalad;
    }

    public void setComposition(Set<Vegetable> compositionOfTheSalad) {
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
            compositionOfTheSalad.add(vegetable);
        }
    }

    public void removeIngredient(Vegetable vegetable) throws VegetableIsNotExistException {
        if (vegetable == null || getVegetableByName(vegetable.getName()) == null) {
            throw new VegetableIsNotExistException("Vegetable is null or isn't exist in salad!");
        } else {
            compositionOfTheSalad.remove(getVegetableByName(vegetable.getName()));
            System.out.println("Succes remove " + vegetable.getName());
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

    public Set<Vegetable> getVegetableByCalories(double lowerBound, double upperBound) {
        Set<Vegetable> result = new HashSet<Vegetable>();

        for (Vegetable vegetable : compositionOfTheSalad) {
            if (vegetable.getCalories() >= lowerBound && vegetable.getCalories() <= upperBound) {
                result.add(vegetable);
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
