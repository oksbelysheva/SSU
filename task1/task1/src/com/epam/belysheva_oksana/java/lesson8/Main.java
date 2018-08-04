package com.epam.belysheva_oksana.java.lesson8;

import com.epam.belysheva_oksana.java.lesson8.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson8.Exception.VegetableAlreadyExistException;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.NutritiveValue;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.TypeVegetable.*;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.Vegetable;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.Color;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.Taste;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.VisualParametrs;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.Vitamins;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.WayForEating;
import com.epam.belysheva_oksana.java.lesson8.XML.XMLHelper;

import java.util.Scanner;

/*
BelyshevaOA 531
lesson8
 */
public class Main {
    public static void main(String[] args) {
        Vitamins vitaminsPea = new Vitamins(38, 0, 0, 2, 40);
        VisualParametrs visualParametrsPea = new VisualParametrs(Color.GREEN, Taste.SWEET);
        NutritiveValue nutritiveValuePea = null;
        try {
            nutritiveValuePea = new NutritiveValue(81, 14.45, 5.42);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
            return;
        }
        Beans pea = createBeans("pea", nutritiveValuePea, WayForEating.FRESH, vitaminsPea, visualParametrsPea);
        Root root = createRoot("root", nutritiveValuePea, WayForEating.FRESH, vitaminsPea, visualParametrsPea);
        Cauline cauline = createCauline("cauline", nutritiveValuePea, WayForEating.FRESH, vitaminsPea, visualParametrsPea);
        Tuberous tuberous = createTuberous("tuberous", nutritiveValuePea, WayForEating.FRESH, vitaminsPea, visualParametrsPea);
        Bulbous bulbous = createBulbous("bulbous", nutritiveValuePea, WayForEating.FRESH, vitaminsPea, visualParametrsPea);

        Scanner scanner = new Scanner(System.in);
        System.out.println("1 - write vegetable to XML\n" +
                "2 - read vegetable XML");
        int choice = scanner.nextInt();
        XMLHelper xmlHelper = new XMLHelper();
        switch (choice) {
            case 1: {
                System.out.println("Enter path for serialization vegetable");
                xmlHelper.vegetableWriteToXML(bulbous, scanner.next());
                break;
            }
            case 2: {
                try {
                    System.out.println("Enter path for serialization vegetable");
                    Vegetable vegetable = xmlHelper.getNewVegetable(scanner.next());
                    System.out.println(vegetable);
                } catch (Exception e) {
                    e.printStackTrace();
                }
                break;
            }
            default:
                break;
        }
    }

    private static Bulbous createBulbous(String name, NutritiveValue nutritiveValue,
                                         WayForEating wayForEating, Vitamins vitamins, VisualParametrs visualParametrs) {
        try {
            return new Bulbous(name, nutritiveValue, wayForEating, vitamins, visualParametrs);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Root createRoot(String name, NutritiveValue nutritiveValue,
                                   WayForEating wayForEating, Vitamins vitamins, VisualParametrs visualParametrs) {
        try {
            return new Root(name, nutritiveValue, wayForEating, vitamins, visualParametrs);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Cauline createCauline(String name, NutritiveValue nutritiveValue,
                                         WayForEating wayForEating, Vitamins vitamins, VisualParametrs visualParametrs) {
        try {
            return new Cauline(name, nutritiveValue, wayForEating, vitamins, visualParametrs);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Tuberous createTuberous(String name, NutritiveValue nutritiveValue,
                                           WayForEating wayForEating, Vitamins vitamins, VisualParametrs visualParametrs) {
        try {
            return new Tuberous(name, nutritiveValue, wayForEating, vitamins, visualParametrs);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static Beans createBeans(String name, NutritiveValue nutritiveValue,
                                     WayForEating wayForEating, Vitamins vitamins, VisualParametrs visualParametrs) {
        try {
            return new Beans(name, nutritiveValue, wayForEating, vitamins, visualParametrs);
        } catch (InvalidVegetableCharacteristicException e) {
            System.out.println(e.getMessage());
        }

        return null;
    }

    private static void showCharacteristicsSalad(VegetableSalad salad) {
        System.out.println("Full calories: " + salad.getSumCalories());
        System.out.println("Full protein: " + salad.getSumProteins());
        System.out.println("Full carbohydrates: " + salad.getSumCarbohydrates());
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
