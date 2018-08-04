package com.epam.belysheva_oksana.java.lesson5.Exception;

/**
 * BelyshevaOA 531
 * lesson4
 * Ошибка попытки добавления элемента который уже есть в салате
 */
public class VegetableAlreadyExistException extends Exception {
    public VegetableAlreadyExistException(String message) {
        super(message);
    }
}
