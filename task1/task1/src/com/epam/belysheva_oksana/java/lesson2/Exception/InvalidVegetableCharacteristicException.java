package com.epam.belysheva_oksana.java.lesson2.Exception;

/**
 * BelyshevaOA 531
 * lesson2
 * Для хранения ингредиентов салата используется массив
 */
public class InvalidVegetableCharacteristicException extends Exception {
    public InvalidVegetableCharacteristicException(String message) {
        super(message);
    }
}
