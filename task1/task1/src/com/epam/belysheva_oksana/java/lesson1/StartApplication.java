package com.epam.belysheva_oksana.java.lesson1;

import com.epam.belysheva_oksana.java.lesson1.task1.StartWorkingWithArray;
import com.epam.belysheva_oksana.java.lesson1.task2.StartWorkingWithString;
import com.epam.belysheva_oksana.java.lesson1.task3.Calculator;

import java.util.Scanner;

class StartApplication {

    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter number task:\n" +
                "1 - Work with withArray integer\n" +
                "2 - Work with strings and words\n" +
                "3 - Calculator");
        int choice = scanner.nextInt();

        switch (choice) {
            case 1: {
                StartWorkingWithArray app = new StartWorkingWithArray();
                app.startApplication();
                break;
            }


            case 2: {
                StartWorkingWithString app = new StartWorkingWithString();
                app.startApplication();
                break;
            }


            case 3: {
                Calculator app = new Calculator();
                app.startApplication();
                break;
            }

            default:
                break;
        }
    }
}
