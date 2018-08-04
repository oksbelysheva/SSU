package com.epam.belysheva_oksana.java.lesson6;

import com.epam.belysheva_oksana.java.lesson6.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson6.Exception.VegetableAlreadyExistException;
import com.epam.belysheva_oksana.java.lesson6.Exception.VegetableIsNotExistException;
import com.epam.belysheva_oksana.java.lesson6.Serialization.SerializationHelper;
import com.epam.belysheva_oksana.java.lesson6.Vegetable.*;
import com.epam.belysheva_oksana.java.lesson6.Vegetable.Type.*;

import java.util.Scanner;

/*
BelyshevaOA 531
lesson6
 */
public class Main {
    public static void main(String[] args) {
        VegetableSalad salad = new VegetableSalad("Unknowing sald");
        Beans pea = createBeans("pea", 1, 2, 3, WayForEating.BOIL);
        Root carrot = createRoot("carrot", 4, 5, 6, WayForEating.FRY);
        Cauline onion = createCauline("onion", 7, 8, 9, WayForEating.FRESH);

        addVegetableToSalad(salad, pea, (double) 10);
        addVegetableToSalad(salad, carrot, (double) 1);
        addVegetableToSalad(salad, onion, (double) 3);
        Scanner scanner = new Scanner(System.in);


        //Serialization
        System.out.println("1 - write salad\n" +
                "2 - read salad\n" +
                "3 - edit salad");
        int choice = scanner.nextInt();
        SerializationHelper serializationHelper = new SerializationHelper();
        switch (choice) {
            case 1: {
                System.out.println("Enter path for serialization salad");
                serializationHelper.serializeVegetableSalad(salad, scanner.next());
                break;
            }
            case 2: {
                System.out.println("Enter path for deserialization salad");
                VegetableSalad salad1 = serializationHelper.deserializeVegetableSalad(scanner.next());
                System.out.println(salad1);
                break;
            }
            case 3: {
                System.out.println("Enter path for deserialization salad");
                String path = scanner.next();
                VegetableSalad salad1 = serializationHelper.deserializeVegetableSalad(path);
                try {
                    salad1.removeIngredient(carrot);
                    System.out.println(salad1);
                    serializationHelper.serializeVegetableSalad(salad1, path);
                } catch (VegetableIsNotExistException e) {
                    e.printStackTrace();
                }
                break;
            }
            default:
                break;
        }

    }

    private static void showCharacteristicsSalad(VegetableSalad salad) {
        System.out.println("Full calories: " + salad.getSumCalories());
        System.out.println("Full protein: " + salad.getSumProteins());
        System.out.println("Full carbohydrates: " + salad.getSumCarbohydrates());
    }

    private static Beans createBeans(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) {
        try {
            return new Beans(name, calories, protein, carbohydrates, wayForEating);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Cauline createCauline(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) {
        try {
            return new Cauline(name, calories, protein, carbohydrates, wayForEating);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Root createRoot(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) {
        try {
            return new Root(name, calories, protein, carbohydrates, wayForEating);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Bulbous createBulbous(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) {
        try {
            return new Bulbous(name, calories, protein, carbohydrates, wayForEating);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Tuberous createTuberous(String name, double calories, double protein, double carbohydrates, WayForEating wayForEating) {
        try {
            return new Tuberous(name, calories, protein, carbohydrates, wayForEating);
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
