package com.epam.belysheva_oksana.java.lesson5.Exception;

/**
 * BelyshevaOA 531
 * lesson4
 * Ошибка ввода неправильных характеристик ингредиентов (проверяется на отрицательные значения)
 */
public class InvalidVegetableCharacteristicException extends Exception {
    public InvalidVegetableCharacteristicException(String message) {
        super(message);
    }
}
