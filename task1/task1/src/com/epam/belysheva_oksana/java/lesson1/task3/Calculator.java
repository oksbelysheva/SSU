package com.epam.belysheva_oksana.java.lesson1.task3;

import java.util.Scanner;

public class Calculator {

    private int a, b;

    public void startApplication() {
        String choice;

        try {
            Scanner scanner = new Scanner(System.in);
            System.out.println("Enter first number");
            a = Integer.parseInt(scanner.nextLine());
            System.out.println("Enter operation");
            choice = scanner.nextLine().trim();
            System.out.println("Enter second number");
            b = Integer.parseInt(scanner.nextLine());
        } catch (Exception e) {
            System.out.println("Error: input options doesn't correct");
            return;
        }


        switch (choice.charAt(0)) {
            case '*': {
                System.out.println("Result: ");
                System.out.println(multiply());
                break;
            }
            case '-': {
                System.out.println("Result: ");
                System.out.println(diff());
                break;
            }
            case '+': {
                System.out.println("Result: ");
                System.out.println(add());
                break;
            }
            case '/': {
                System.out.println("Result: ");
                System.out.println(divide());
                break;
            }
            default:
                break;
        }

    }

    private int multiply() {
        return this.a * this.b;
    }

    private double divide() {
        return (double) this.a / this.b;
    }

    private int add() {
        return this.a + this.b;
    }

    private int diff() {
        return this.a - this.b;
    }
}
