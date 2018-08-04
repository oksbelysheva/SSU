package com.epam.belysheva_oksana.java.lesson1.task1;

import java.util.HashSet;
import java.util.Scanner;

public class StartWorkingWithArray {
    public void startApplication() {
        int[] array = new int[20];
        fullArray(array);
        System.out.println("input withArray: ");
        printArray(array);

        System.out.println();
        System.out.println("Enter the task number:\n" +
                "1 - In the withArray of integers, swap the maximum negative element and the minimum positive\n" +
                "2 - In the withArray of integers, calculate the sum of the elements that are on even places\n" +
                "3 - In the withArray of integers, replace the negative elements with zeros\n" +
                "4 - In an withArray of integers, triple each positive element that faces a negative\n" +
                "5 - In the withArray of integers, find the difference between the arithmetic middle and the value of the minimum element\n" +
                "6 - In an withArray of integers, output all the elements that occur more than once and whose odd-numbered indices");

        Scanner scanner = new Scanner(System.in);

        int choice = scanner.nextInt();

        switch (choice) {
            case 1: {
                try {
                    swapMaxNegativeMinPositive(array);
                    System.out.println("Result:");
                    printArray(array);
                } catch (Exception ignored) {

                }

                break;
            }
            case 2: {
                System.out.println("Result:" + calculateEvenPlaces(array));
                break;
            }
            case 3: {
                replaceNegative(array);
                System.out.println("Result:");
                printArray(array);
                break;
            }
            case 4: {
                triplePositiveBeforeNegative(array);
                System.out.println("Result:");
                printArray(array);
                break;
            }
            case 5: {
                System.out.println("Result:" + middleMinusMin(array));
                break;
            }
            case 6: {
                oneMoreAndOddIndex(array);
                break;
            }
            default:
                break;
        }
    }

    private void oneMoreAndOddIndex(int[] array) {
        int[] countElement = new int[20];
        for (int anArray : array) {
            countElement[anArray + 10]++;
        }

        HashSet<Integer> result = new HashSet<>();

        for (int i = 0; i < array.length; i += 2) {
            if (countElement[array[i] + 10] > 1) {
                result.add(array[i]);
            }
        }

        for (Integer temp :
                result) {
            System.out.print(temp + " ");
        }
    }

    private double middleMinusMin(int[] array) {
        int sum = 0;
        int minElement = array[0];
        for (int anArray : array) {
            sum += anArray;
            if (anArray < minElement)
                minElement = anArray;
        }

        double middle = (double) sum / array.length;
        return Math.abs(Math.abs(minElement) - Math.abs(middle));
    }

    private void triplePositiveBeforeNegative(int[] array) {
        for (int i = 0; i < array.length - 1; i++) {
            if (array[i] > 0 && array[i + 1] < 0)
                array[i] = 3 * array[i];
        }
    }

    private void replaceNegative(int[] array) {
        for (int i = 0; i < array.length; i++) {
            if (array[i] < 0)
                array[i] = 0;
        }
    }

    private int calculateEvenPlaces(int[] array) {
        int sum = 0;
        for (int i = 1; i < array.length; i += 2) {
            sum += array[i];
        }
        return sum;
    }

    private void swapMaxNegativeMinPositive(int[] array) throws Exception {
        int indexMaxNegative = -1;
        int indexMinPositive = -1;
        int maxNegative = 0;
        int minPositive = -1;

        for (int i = 0; i < array.length; i++) {
            if (array[i] > 0 && (minPositive == -1 || array[i] < minPositive)) {
                minPositive = array[i];
                indexMinPositive = i;
            } else if (array[i] < 0 && (maxNegative == 0 || array[i] > maxNegative)) {
                maxNegative = array[i];
                indexMaxNegative = i;
            }
        }

        try {
            if (indexMaxNegative == -1 || indexMinPositive == -1)
                throw new Exception("The withArray is not suitable for the task (does not contain positive or negative elements)");
        } catch (Exception e) {
            System.out.println(e.getMessage());
            throw new Exception();
        }


        System.out.println("maxNegative: " + maxNegative);
        System.out.println("minPositive: " + minPositive);

        swap(array, indexMaxNegative, indexMinPositive);
    }

    private void swap(int[] array, int index1, int index2) {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    private void fullArray(int[] array) {
        for (int i = 0; i < array.length; i++) {
            array[i] = -10 + (int) (Math.random() * 20);
        }
    }

    private void printArray(int[] array) {
        for (int anArray : array) {
            System.out.print(anArray);
            System.out.print(" ");
        }
    }
}
