package com.epam.belysheva_oksana.java.lesson5.Exception;

/**
 * BelyshevaOA 531
 * lesson4
 * Ошибка удаления ингредиента которого нет в салате
 */
public class VegetableIsNotExistException extends Exception {
    public VegetableIsNotExistException(String message) {
        super(message);
    }
}
