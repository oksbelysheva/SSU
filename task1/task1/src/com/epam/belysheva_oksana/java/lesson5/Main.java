package com.epam.belysheva_oksana.java.lesson5;

import com.epam.belysheva_oksana.java.lesson5.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson5.Exception.VegetableAlreadyExistException;
import com.epam.belysheva_oksana.java.lesson5.Exception.VegetableIsNotExistException;
import com.epam.belysheva_oksana.java.lesson5.Vegetable.Beans;
import com.epam.belysheva_oksana.java.lesson5.Vegetable.Vegetable;
import com.epam.belysheva_oksana.java.lesson5.Vegetable.WayForEating;

import java.util.Set;

/*
BelyshevaOA 531
lesson5
В качестве коллекций используется Set для хранянения ингредиентов салата в VegetableSalad

lesson4
Используются собственные обработчики исключений в package Exception
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

        System.out.println(salad.toString());

        try {
            salad.removeIngredient(beans1);
        } catch (VegetableIsNotExistException e) {
            System.out.println(e.getMessage());
        }

        showCharacteristicsSalad(salad);

        Set<Vegetable> vegetableSet = salad.getVegetableByCalories(5, 7);

        for (Vegetable vegetable :
                vegetableSet) {
            System.out.println(vegetable.getName() + " " + vegetable.getCalories() + " calories");
        }
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
