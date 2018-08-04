package com.epam.belysheva_oksana.java.lesson3;

import com.epam.belysheva_oksana.java.lesson3.Type.Course;
import com.epam.belysheva_oksana.java.lesson3.Type.Curriculum;
import com.epam.belysheva_oksana.java.lesson3.Type.Student;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * BelyshevaOA 531
 * lesson 3
 */
public class Main {
    public static void main(String[] args) throws ParseException {
        Main app = new Main();
        app.start();
    }

    private void start() throws ParseException {
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd.MM.yyyy");

        Course technologyJavaServlets = new Course("Технология Java Servlets", 16);
        Course strutsFramework = new Course("Struts Framework", 24);
        Course reviewTechnologyJava = new Course("Обзор технологий Java", 8);
        Course libraryJFCSwing = new Course("Библиотека JFC/Swing", 16);
        Course technologyJDBC = new Course("Технология JDBC", 5);

        Course[] courses1 = new Course[2];
        courses1[0] = technologyJavaServlets;
        courses1[1] = strutsFramework;

        Course[] courses2 = new Course[3];
        courses2[0] = reviewTechnologyJava;
        courses2[1] = libraryJFCSwing;
        courses2[2] = technologyJavaServlets;

        Curriculum J2EE_Developer = new Curriculum("J2EE_Developer", courses1);
        Curriculum Java_Developer = new Curriculum("Java_Developer", courses2);

        Student firstStudent = new Student("Ivan Ivanov", J2EE_Developer, simpleDateFormat.parse("23.02.2018"));
        Student secondStudent = new Student("Petr Petrov", Java_Developer, simpleDateFormat.parse("23.02.2018"));

        ArrayList<Student> students = new ArrayList<>();
        students.add(firstStudent);
        students.add(secondStudent);

        int choice;
        System.out.println("Enter command:\n" +
                "0 - short report\n" +
                "1 - full report");
        Scanner scanner = new Scanner(System.in);
        choice = scanner.nextInt();

        switch (choice) {
            case 0: {
                for (Student currentStudent :
                        students) {
                    System.out.println(currentStudent.getNameStudent());
                    System.out.println(currentStudent.getCurriculumStudend().getNameCurriculum());
                    currentStudent.isFinishStudy();
                    System.out.println();
                }
                break;
            }
            case 1: {
                for (Student currentStudent :
                        students) {
                    System.out.println(currentStudent.getNameStudent());
                    System.out.println("Time working: 10-18");
                    System.out.println(currentStudent.getCurriculumStudend().getNameCurriculum());
                    currentStudent.amountDayAndHours();
                }
                break;
            }
            default:
                break;
        }


    }
}
