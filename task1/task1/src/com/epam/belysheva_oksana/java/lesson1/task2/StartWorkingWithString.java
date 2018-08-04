package com.epam.belysheva_oksana.java.lesson1.task2;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Scanner;

public class StartWorkingWithString {
    public void startApplication() {
        System.out.println("Enter the task number:\n" +
                "1 - Enter n lines from the console, find the shortest and longest lines. Output the found lines and their length.\n" +
                "2 - Enter n lines from the console. Output to the console those lines that are longer than the average length, and also length.\n" +
                "3 - Enter n lines from the console. Output to the console those lines that are less than the average length, and also length.\n" +
                "4 - Enter n words from the console. Find a word in which the count of different characters is minimal. If there are several such words, find the first one.\n" +
                "5 - Enter n words from the console. Find the word in which all the letters are different. If there are several such words, find the first one.\n" +
                "6 - Enter n words from the console. Find the word consisting only of digits. If there are several such words, find the second one.");

        Scanner scanner = new Scanner(System.in);

        int choice = scanner.nextInt();

        switch (choice) {
            case 1: {
                ArrayList<String> inputStrings = enterString();
                findMinAndMaxLength(inputStrings);
                break;
            }
            case 2: {
                ArrayList<String> inputStrings = enterString();
                MoreThenMiddle(inputStrings);
                break;
            }
            case 3: {
                ArrayList<String> inputStrings = enterString();
                LessThenMiddle(inputStrings);
                break;
            }
            case 4: {
                ArrayList<String> inputWords = enterWords();
                System.out.println("Words:");
                printArray(inputWords);
                MinimumDifferentSymbols(inputWords);
                break;
            }
            case 5: {
                ArrayList<String> inputWords = enterWords();
                System.out.println("Words:");
                printArray(inputWords);
                AllDifferentSymbols(inputWords);
                break;
            }
            case 6: {
                ArrayList<String> inputWords = enterWords();
                System.out.println("Words:");
                printArray(inputWords);
                FirstOrSecondDigit(inputWords);
                break;
            }
            default:
                break;
        }
    }

    private void FirstOrSecondDigit(ArrayList<String> inputWords) {
        boolean flagFirst = false;
        int index = -1;
        for (int i = 0; i < inputWords.size(); i++) {
            if (!flagFirst && isDigit(inputWords.get(i))) {
                index = i;
                flagFirst = true;
            } else if (flagFirst && isDigit(inputWords.get(i))) {
                index = i;
                break;
            }
        }

        if (!flagFirst) {
            System.out.println("Error: Digit doesn't find!");
        } else {
            System.out.println("Answer:");
            System.out.println(inputWords.get(index));
        }
    }

    private boolean isDigit(String s) {
        if (s.length() == 0)
            return false;
        for (int i = 0; i < s.length(); i++) {
            if (!(s.charAt(i) >= '0' && s.charAt(i) <= '9')) {
                return false;
            }
        }
        return true;
    }

    private void AllDifferentSymbols(ArrayList<String> inputWords) {
        int index = 0;
        for (String inputWord : inputWords) {
            int tempLength = countDifferent(inputWord);
            if (tempLength == inputWord.length()) {
                index = 1;
                System.out.println("All different symbols:");
                System.out.println(inputWord);
                break;
            }
        }

        if (index == 0) {
            System.out.println("Error: Words with all different symbols doesn't find!");
        }
    }

    private void MinimumDifferentSymbols(ArrayList<String> inputWords) {
        int minimumDifferent = countDifferent(inputWords.get(0));
        int index = 0;
        for (int i = 1; i < inputWords.size(); i++) {
            int tempLength = countDifferent(inputWords.get(i));
            if (tempLength < minimumDifferent) {
                index = i;
                minimumDifferent = tempLength;
            }
        }
        System.out.println("Minimum different symbols:");
        System.out.println(inputWords.get(index));
    }

    private int countDifferent(String s) {
        HashSet<Character> differentSymbols = new HashSet<>();
        for (int i = 0; i < s.length(); i++) {
            differentSymbols.add(s.charAt(i));
        }
        return differentSymbols.size();
    }

    private void MoreThenMiddle(ArrayList<String> inputStrings) {
        ArrayList<Integer> lengthString = new ArrayList<>();
        int sum = 0;
        for (String currentString :
                inputStrings) {
            sum += currentString.length();
            lengthString.add(currentString.length());
        }

        double middle = (double) sum / inputStrings.size();

        System.out.println("Middle length: " + middle);

        for (int i = 0; i < lengthString.size(); i++) {
            if (lengthString.get(i) > middle)
                System.out.println(inputStrings.get(i) + " " + lengthString.get(i));
        }
    }

    private void LessThenMiddle(ArrayList<String> inputStrings) {
        ArrayList<Integer> lengthString = new ArrayList<>();
        int sum = 0;
        for (String currentString :
                inputStrings) {
            sum += currentString.length();
            lengthString.add(currentString.length());
        }

        double middle = (double) sum / inputStrings.size();

        System.out.println("Middle length: " + middle);

        for (int i = 0; i < lengthString.size(); i++) {
            if (lengthString.get(i) < middle)
                System.out.println(inputStrings.get(i) + " " + lengthString.get(i));
        }
    }

    private void findMinAndMaxLength(ArrayList<String> arrayList) {
        int maxLength = arrayList.get(0).length();
        int minLength = arrayList.get(0).length();
        int indexMaxLength = 0;
        int indexMinLength = 0;
        for (int i = 0; i < arrayList.size(); i++) {
            if (arrayList.get(i).length() > maxLength) {
                maxLength = arrayList.get(i).length();
                indexMaxLength = i;
            } else if (arrayList.get(i).length() < minLength) {
                minLength = arrayList.get(i).length();
                indexMinLength = i;
            }
        }

        System.out.println("Min length: " + minLength);
        System.out.println(arrayList.get(indexMinLength));

        System.out.println("Max length: " + maxLength);
        System.out.println(arrayList.get(indexMaxLength));
    }

    private ArrayList<String> enterString() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter n:");
        int n = Integer.parseInt(scanner.nextLine());

        ArrayList<String> stringArrayList = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            stringArrayList.add(scanner.nextLine());
        }

        return stringArrayList;
    }

    private ArrayList<String> enterWords() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter n:");
        int n = Integer.parseInt(scanner.nextLine());


        ArrayList<String> stringArrayList = new ArrayList<>(n);
        while (stringArrayList.size() < n) {
            String[] temp = (scanner.nextLine()).split(" ");
            String[] temp2;
            if (temp.length < n - stringArrayList.size())
                temp2 = new String[temp.length];
            else
                temp2 = new String[n - stringArrayList.size()];
            for (int i = 0; i < temp.length && i < n - stringArrayList.size(); i++) {
                temp2[i] = temp[i];
            }
            Collections.addAll(stringArrayList, temp2);
        }

        return stringArrayList;
    }

    private void printArray(ArrayList<String> array) {
        for (String anArray : array) {
            System.out.println(anArray);
        }
    }
}
