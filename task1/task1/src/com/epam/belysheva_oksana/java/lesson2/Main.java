package com.epam.belysheva_oksana.java.lesson2;

import com.epam.belysheva_oksana.java.lesson2.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson2.Exception.VegetableAlreadyExistException;
import com.epam.belysheva_oksana.java.lesson2.Exception.VegetableIsNotExistException;
import com.epam.belysheva_oksana.java.lesson2.Vegetable.Beans;
import com.epam.belysheva_oksana.java.lesson2.Vegetable.Vegetable;
import com.epam.belysheva_oksana.java.lesson2.Vegetable.WayForEating;

/**
 * BelyshevaOA 531
 * lesson2
 * Для хранения ингредиентов салата используется массив
 */
public class Main {
    public static void main(String[] args) {
        VegetableSalad salad = new VegetableSalad("Unknowing sald");
        Beans beans1 = createBeans("beans1", 1, 2, 3, WayForEating.BOIL);
        Beans beans2 = createBeans("beans2", 4, 5, 6, WayForEating.FRY);
        Beans beans3 = createBeans("beans3", 7, 8, 9, WayForEating.FRESH);

        addVegetableToSalad(salad, beans1, (double) 10);
        addVegetableToSalad(salad, beans2, (double) 1);
        addVegetableToSalad(salad, beans3, (double) 3);

        salad.getVegetableByCalories(1, 7);

        System.out.println(salad.toString());

        try {
            salad.removeIngredient(beans1);
        } catch (VegetableIsNotExistException e) {
            System.out.println(e.getMessage());
        }

        showCharacteristicsSalad(salad);

    }

    private static void showCharacteristicsSalad(VegetableSalad salad) {
        System.out.println("Full calories: " + salad.getSumCalories());
        System.out.println("Full protein: " + salad.getSumProteins());
        System.out.println("Full carbohydrates: " + salad.getSumCarbohydrates());
    }

    public static Beans createBeans(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) {
        try {
            return new Beans(name, calories, protein, carbohydrates, wayForEating);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    public static void addVegetableToSalad(VegetableSalad newSalad, Vegetable vegetable, Double weight) {
        try {
            newSalad.addIngredient(vegetable, weight);
        } catch (VegetableAlreadyExistException e) {
            System.out.println(e.getMessage());
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }
    }
}
